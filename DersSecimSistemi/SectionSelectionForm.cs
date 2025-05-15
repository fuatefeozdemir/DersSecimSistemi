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

        private List<(string CourseCode, int SectionID, string InstructorName,int Quota, string Classroom, TimeSpan StartTime, TimeSpan EndTime, string Day)> sections;
        private List<RadioButton> sectionRadioButtons = new List<RadioButton>();

        public SectionSelectionForm(List<(string CourseCode, int SectionID, string InstructorName,int Quota, string Classroom, TimeSpan StartTime, TimeSpan EndTime, string Day)> sections)
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10); // Genel form fontu
            this.sections = sections;

            // ======= Başlık Paneli =======
            Panel headerPanel = new Panel();
            headerPanel.Width = 700;
            headerPanel.Height = 30;
            headerPanel.Margin = new Padding(2);
            headerPanel.BackColor = Color.LightGray;

            Label emptyLabel = new Label();
            emptyLabel.Width = 20;
            emptyLabel.Location = new Point(5, 6);

            Label sectionHeader = new Label();
            sectionHeader.Text = "Şube";
            sectionHeader.AutoSize = true;
            sectionHeader.Location = new Point(emptyLabel.Right + 1, 6);
            sectionHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label instructorHeader = new Label();
            instructorHeader.Text = "Öğretim Görevlisi";
            instructorHeader.AutoSize = true;
            instructorHeader.Location = new Point(sectionHeader.Right + 1, 6);
            instructorHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label dayHeader = new Label();
            dayHeader.Text = "Gün";
            dayHeader.AutoSize = true;
            dayHeader.Location = new Point(instructorHeader.Right + 55, 6);
            dayHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label timeHeader = new Label();
            timeHeader.Text = "Saat";
            timeHeader.AutoSize = true;
            timeHeader.Location = new Point(dayHeader.Right + 10, 6);
            timeHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label classHeader = new Label();
            classHeader.Text = "Sınıf";
            classHeader.AutoSize = true;
            classHeader.Location = new Point(timeHeader.Right + 10, 6);
            classHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            Label quotaHeader = new Label();
            quotaHeader.Text = "Kota";
            quotaHeader.AutoSize = true;
            quotaHeader.Location = new Point(classHeader.Right + 10, 6);
            quotaHeader.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            headerPanel.Controls.Add(emptyLabel);
            headerPanel.Controls.Add(sectionHeader);
            headerPanel.Controls.Add(instructorHeader);
            headerPanel.Controls.Add(dayHeader);
            headerPanel.Controls.Add(timeHeader);
            headerPanel.Controls.Add(classHeader);
            headerPanel.Controls.Add(quotaHeader);

            flowLayoutPanelSections.Controls.Add(headerPanel);
            // ======= Başlık Paneli Sonu =======

            int sectionNumber = 1;

            foreach (var section in sections)
            {
                Panel sectionPanel = new Panel();
                sectionPanel.Width = 700;
                sectionPanel.Height = 30;
                sectionPanel.Margin = new Padding(2);
                sectionPanel.BackColor = Color.Transparent;

                RadioButton radioButton = new RadioButton();
                radioButton.Tag = section.SectionID;
                radioButton.Width = 20;
                radioButton.Height = 20;
                radioButton.Location = new Point(5, 5);
                radioButton.CheckedChanged += RadioButton_CheckedChanged;

                Label courseLabel = new Label();
                courseLabel.Text = section.CourseCode + $"({sectionNumber})";
                courseLabel.AutoSize = true;
                courseLabel.Location = new Point(radioButton.Right + 1, 6);
                courseLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                Label instructorLabel = new Label();
                instructorLabel.Text = section.InstructorName;
                instructorLabel.AutoSize = true;
                instructorLabel.Location = new Point(courseLabel.Right + 1, 6);
                instructorLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                Label dayLabel = new Label();
                dayLabel.Text = section.Day;
                dayLabel.AutoSize = true;
                dayLabel.Location = new Point(instructorLabel.Right + 55, 6);
                dayLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                string timeRange = $"{section.StartTime:hh\\:mm} - {section.EndTime:hh\\:mm}";
                Label timeLabel = new Label();
                timeLabel.Text = timeRange;
                timeLabel.AutoSize = true;
                timeLabel.Location = new Point(dayLabel.Right + 10, 6);
                timeLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                Label classLabel = new Label();
                classLabel.Text = section.Classroom;
                classLabel.AutoSize = true;
                classLabel.Location = new Point(timeLabel.Right + 10, 6);
                classLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                Label quotaLabel = new Label();
                quotaLabel.Text = section.Quota.ToString();
                quotaLabel.AutoSize = true;
                quotaLabel.Location = new Point(classLabel.Right + 10, 6);
                quotaLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);
                quotaLabel.ForeColor = Color.Green;

                sectionPanel.Controls.Add(radioButton);
                sectionPanel.Controls.Add(courseLabel);
                sectionPanel.Controls.Add(instructorLabel);
                sectionPanel.Controls.Add(dayLabel);
                sectionPanel.Controls.Add(timeLabel);
                sectionPanel.Controls.Add(classLabel);
                sectionPanel.Controls.Add(quotaLabel);

                sectionRadioButtons.Add(radioButton);
                flowLayoutPanelSections.Controls.Add(sectionPanel);

                sectionNumber++;
            }

            buttonOK.Font = new Font("Segoe UI", 10);
            buttonCancel.Font = new Font("Segoe UI", 10);
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
                MessageBox.Show("Lütfen bir şube seçiniz.");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
