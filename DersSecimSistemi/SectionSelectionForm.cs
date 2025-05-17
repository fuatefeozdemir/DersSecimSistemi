using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace DersSecimSistemi
{
    public partial class SectionSelectionForm : Form
    {
        public int SelectedSectionID { get; private set; }

        private List<(string CourseCode, int SectionID, string InstructorName, int Quota, string Classroom, TimeSpan StartTime, TimeSpan EndTime, string Day)> sections;
        private List<RadioButton> sectionRadioButtons = new List<RadioButton>();

        public SectionSelectionForm(
            List<(string CourseCode, int SectionID, string InstructorName, int Quota, string Classroom, TimeSpan StartTime, TimeSpan EndTime, string Day)> sections,
            int studentID,
            int courseID)
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10);
            this.sections = sections;

            PopulateSectionsUI();

            buttonOK.Font = new Font("Segoe UI", 10);
            buttonCancel.Font = new Font("Segoe UI", 10);
        }

        private void PopulateSectionsUI()
        {
            flowLayoutPanelSections.Controls.Clear();
            sectionRadioButtons.Clear();

            // --- Başlık Paneli ---
            Panel headerPanel = new Panel();
            headerPanel.Width = flowLayoutPanelSections.Width - 25;
            headerPanel.Height = 30;
            headerPanel.Margin = new Padding(0, 0, 0, 5);
            headerPanel.BackColor = Color.LightGray;

            Font headerFont = new Font("Segoe UI", 9, FontStyle.Bold);
            int headerY = 6;

            Label emptyLabel = new Label();
            emptyLabel.Width = 20;
            emptyLabel.Location = new Point(5, headerY);
            headerPanel.Controls.Add(emptyLabel);

            Label sectionHeader = new Label();
            sectionHeader.Text = "Şube";
            sectionHeader.AutoSize = true;
            sectionHeader.Location = new Point(emptyLabel.Right + 1, headerY);
            sectionHeader.Font = headerFont;
            headerPanel.Controls.Add(sectionHeader);

            Label instructorHeader = new Label();
            instructorHeader.Text = "Öğretim Görevlisi";
            instructorHeader.AutoSize = true;
            instructorHeader.Location = new Point(90, headerY);
            instructorHeader.Font = headerFont;
            headerPanel.Controls.Add(instructorHeader);

            Label dayHeader = new Label();
            dayHeader.Text = "Gün";
            dayHeader.AutoSize = true;
            dayHeader.Location = new Point(250, headerY);
            dayHeader.Font = headerFont;
            headerPanel.Controls.Add(dayHeader);

            Label timeHeader = new Label();
            timeHeader.Text = "Saat";
            timeHeader.AutoSize = true;
            timeHeader.Location = new Point(340, headerY);
            timeHeader.Font = headerFont;
            headerPanel.Controls.Add(timeHeader);

            Label classHeader = new Label();
            classHeader.Text = "Sınıf";
            classHeader.AutoSize = true;
            classHeader.Location = new Point(470, headerY);
            classHeader.Font = headerFont;
            headerPanel.Controls.Add(classHeader);

            Label quotaHeader = new Label();
            quotaHeader.Text = "Kontenjan";
            quotaHeader.AutoSize = true;
            quotaHeader.Location = new Point(560, headerY);
            quotaHeader.Font = headerFont;
            headerPanel.Controls.Add(quotaHeader);

            flowLayoutPanelSections.Controls.Add(headerPanel);

            // --- Şube Detay Panelleri ---
            int sectionDisplayNumber = 1;
            Font itemFont = new Font("Segoe UI", 8, FontStyle.Regular);
            int itemY = 6;


            // Her şube için panel satırı oluştur
            foreach (var section in sections)
            {
                Panel sectionPanel = new Panel();
                sectionPanel.Width = flowLayoutPanelSections.Width - 25;
                sectionPanel.Height = 30;
                sectionPanel.Margin = new Padding(0, 0, 0, 2);
                sectionPanel.BackColor = Color.Transparent;

                // RadioButton oluştur
                RadioButton radioButton = new RadioButton();
                radioButton.Tag = section.SectionID;
                radioButton.Width = 20;
                radioButton.Height = 20;
                radioButton.Location = new Point(5, itemY);
                radioButton.CheckedChanged += RadioButton_CheckedChanged;
                sectionRadioButtons.Add(radioButton);
                sectionPanel.Controls.Add(radioButton);

                Label courseLabel = new Label();
                courseLabel.Text = $"{section.Item1}({sectionDisplayNumber})";
                courseLabel.AutoSize = true;
                courseLabel.Location = new Point(radioButton.Right + 1, itemY);
                courseLabel.Font = itemFont;
                sectionPanel.Controls.Add(courseLabel);

                Label instructorLabel = new Label();
                instructorLabel.Text = section.Item3;
                instructorLabel.AutoSize = true;
                instructorLabel.Location = new Point(90, itemY);
                instructorLabel.Font = itemFont;
                sectionPanel.Controls.Add(instructorLabel);

                Label dayLabel = new Label();
                dayLabel.Text = section.Item8;
                dayLabel.AutoSize = true;
                dayLabel.Location = new Point(250, itemY);
                dayLabel.Font = itemFont;
                sectionPanel.Controls.Add(dayLabel);

                Label timeLabel = new Label();
                string timeRange = $"{section.Item6:hh\\:mm} - {section.Item7:hh\\:mm}";
                timeLabel.Text = timeRange;
                timeLabel.AutoSize = true;
                timeLabel.Location = new Point(340, itemY);
                timeLabel.Font = itemFont;
                sectionPanel.Controls.Add(timeLabel);

                Label classLabel = new Label();
                classLabel.Text = section.Item5;
                classLabel.AutoSize = true;
                classLabel.Location = new Point(470, itemY); 
                classLabel.Font = itemFont;
                sectionPanel.Controls.Add(classLabel);

                Label quotaLabel = new Label();
                quotaLabel.Text = section.Item4.ToString();
                quotaLabel.AutoSize = true;
                quotaLabel.Location = new Point(560, itemY);
                quotaLabel.Font = itemFont;
                quotaLabel.ForeColor = Color.Green;
                sectionPanel.Controls.Add(quotaLabel);

                flowLayoutPanelSections.Controls.Add(sectionPanel);

                sectionDisplayNumber++;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton changedButton = sender as RadioButton;
            if (changedButton.Checked)
            {
                foreach (var rb in sectionRadioButtons)
                {
                    if (rb != changedButton)
                        rb.Checked = false;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var selected = sectionRadioButtons.FirstOrDefault(rb => rb.Checked);
            if (selected != null)
            {
                SelectedSectionID = (int)selected.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir şube seçiniz.", "Şube Seçimi Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}