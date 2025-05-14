using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    public partial class SectionSelectionForm : Form
    {
        public int SelectedSectionID { get; private set; }

        // Şube bilgilerini tutacak liste
        private List<(int sectionID, string displayInfo)> sections;

        // Seçilen checkbox'ları tutan liste
        private List<CheckBox> sectionCheckBoxes = new List<CheckBox>();

        public SectionSelectionForm(List<(int sectionID, string displayInfo)> sections)
        {
            InitializeComponent();
            this.sections = sections;

            // FlowLayoutPanel'de her şube için checkbox oluşturulur
            foreach (var section in sections)
            {
                string displayText = section.sectionID.ToString();

                CheckBox checkBox = new CheckBox();
                checkBox.Text = displayText +" Şube";
                checkBox.Tag = section.sectionID;  // Tag alanına sectionID atanır
                checkBox.AutoSize = true;

                // Checkbox seçimi değiştiğinde yalnızca bir seçim yapılabilmesi için event ekle
                checkBox.CheckedChanged += SectionCheckBox_CheckedChanged;

                sectionCheckBoxes.Add(checkBox);
                flowLayoutPanelSections.Controls.Add(checkBox);
            }
        }

        // Yalnızca bir checkbox seçilmesini sağlamak için event
        private void SectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox changedBox = sender as CheckBox;

            if (changedBox.Checked)
            {
                // Diğer checkbox'ların seçimini kaldır
                foreach (var cb in sectionCheckBoxes)
                {
                    if (cb != changedBox)
                        cb.Checked = false;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            // Seçili bir checkbox olup olmadığını kontrol et
            var selectedCheckBox = sectionCheckBoxes.FirstOrDefault(cb => cb.Checked);

            if (selectedCheckBox != null)
            {
                // Seçilen şubenin SectionID'sini al
                SelectedSectionID = (int)selectedCheckBox.Tag;
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
