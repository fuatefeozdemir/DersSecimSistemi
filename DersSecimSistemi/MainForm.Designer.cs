namespace DersSecimSistemi
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelStudentInfo = new System.Windows.Forms.Label();
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnGoToSchedule = new System.Windows.Forms.Button();
            this.btnGoToCourseSelection = new System.Windows.Forms.Button();
            this.btnGoToHome = new System.Windows.Forms.Button();
            this.labelGazi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.panelWarning = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageHome = new System.Windows.Forms.TabPage();
            this.pageCourseSelection = new System.Windows.Forms.TabPage();
            this.btnSaveSelections = new System.Windows.Forms.Button();
            this.flowLayoutPanelSelectedSections = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanelCourses = new System.Windows.Forms.FlowLayoutPanel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pageSchedule = new System.Windows.Forms.TabPage();
            this.dataGridViewSchedule = new System.Windows.Forms.DataGridView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelWarning.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.pageCourseSelection.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panelProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.labelStudentInfo);
            this.panelHeader.Location = new System.Drawing.Point(180, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1084, 37);
            this.panelHeader.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DersSecimSistemi.Properties.Resources.profile_picture;
            this.pictureBox2.Location = new System.Drawing.Point(796, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // labelStudentInfo
            // 
            this.labelStudentInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStudentInfo.AutoSize = true;
            this.labelStudentInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStudentInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.labelStudentInfo.Location = new System.Drawing.Point(834, 10);
            this.labelStudentInfo.Name = "labelStudentInfo";
            this.labelStudentInfo.Size = new System.Drawing.Size(118, 18);
            this.labelStudentInfo.TabIndex = 7;
            this.labelStudentInfo.Text = "labelStudentInfo";
            this.labelStudentInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelSide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSide.Controls.Add(this.btnGoToSchedule);
            this.panelSide.Controls.Add(this.btnGoToCourseSelection);
            this.panelSide.Controls.Add(this.btnGoToHome);
            this.panelSide.Controls.Add(this.labelGazi);
            this.panelSide.Controls.Add(this.pictureBox1);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(180, 761);
            this.panelSide.TabIndex = 1;
            // 
            // btnGoToSchedule
            // 
            this.btnGoToSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToSchedule.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoToSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(208)))));
            this.btnGoToSchedule.Location = new System.Drawing.Point(2, 214);
            this.btnGoToSchedule.Name = "btnGoToSchedule";
            this.btnGoToSchedule.Size = new System.Drawing.Size(175, 30);
            this.btnGoToSchedule.TabIndex = 5;
            this.btnGoToSchedule.Text = "Ders Programı";
            this.btnGoToSchedule.UseVisualStyleBackColor = true;
            this.btnGoToSchedule.Click += new System.EventHandler(this.btnGoToSchedule_Click);
            // 
            // btnGoToCourseSelection
            // 
            this.btnGoToCourseSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToCourseSelection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoToCourseSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(208)))));
            this.btnGoToCourseSelection.Location = new System.Drawing.Point(3, 178);
            this.btnGoToCourseSelection.Name = "btnGoToCourseSelection";
            this.btnGoToCourseSelection.Size = new System.Drawing.Size(175, 30);
            this.btnGoToCourseSelection.TabIndex = 4;
            this.btnGoToCourseSelection.Text = "Ders Kayıt";
            this.btnGoToCourseSelection.UseVisualStyleBackColor = true;
            this.btnGoToCourseSelection.Click += new System.EventHandler(this.btnGoToCourseSelection_Click);
            // 
            // btnGoToHome
            // 
            this.btnGoToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToHome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGoToHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(199)))), ((int)(((byte)(208)))));
            this.btnGoToHome.Location = new System.Drawing.Point(3, 142);
            this.btnGoToHome.Name = "btnGoToHome";
            this.btnGoToHome.Size = new System.Drawing.Size(175, 30);
            this.btnGoToHome.TabIndex = 3;
            this.btnGoToHome.Text = "Ana Sayfa";
            this.btnGoToHome.UseVisualStyleBackColor = true;
            this.btnGoToHome.Click += new System.EventHandler(this.btnGoToHome_Click);
            // 
            // labelGazi
            // 
            this.labelGazi.AutoSize = true;
            this.labelGazi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.labelGazi.Location = new System.Drawing.Point(34, 90);
            this.labelGazi.Name = "labelGazi";
            this.labelGazi.Size = new System.Drawing.Size(104, 16);
            this.labelGazi.TabIndex = 2;
            this.labelGazi.Text = "Gazi Üniversitesi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::DersSecimSistemi.Properties.Resources.Gazi_Üniversitesi_logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(50, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWarning.ForeColor = System.Drawing.Color.White;
            this.labelWarning.Location = new System.Drawing.Point(16, 9);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 18);
            this.labelWarning.TabIndex = 2;
            // 
            // panelWarning
            // 
            this.panelWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.panelWarning.Controls.Add(this.labelWarning);
            this.panelWarning.Location = new System.Drawing.Point(0, 3);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(1080, 39);
            this.panelWarning.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageHome);
            this.tabControl.Controls.Add(this.pageCourseSelection);
            this.tabControl.Controls.Add(this.pageSchedule);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(180, 37);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1084, 724);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 5;
            // 
            // pageHome
            // 
            this.pageHome.BackColor = System.Drawing.Color.White;
            this.pageHome.Controls.Add(this.panelWarning);
            this.pageHome.Location = new System.Drawing.Point(4, 5);
            this.pageHome.Name = "pageHome";
            this.pageHome.Padding = new System.Windows.Forms.Padding(3);
            this.pageHome.Size = new System.Drawing.Size(1076, 715);
            this.pageHome.TabIndex = 0;
            this.pageHome.Text = "tabPage3";
            // 
            // pageCourseSelection
            // 
            this.pageCourseSelection.BackColor = System.Drawing.Color.White;
            this.pageCourseSelection.Controls.Add(this.btnSaveSelections);
            this.pageCourseSelection.Controls.Add(this.flowLayoutPanelSelectedSections);
            this.pageCourseSelection.Controls.Add(this.panel2);
            this.pageCourseSelection.Controls.Add(this.flowLayoutPanelCourses);
            this.pageCourseSelection.Controls.Add(this.labelInfo);
            this.pageCourseSelection.Controls.Add(this.label2);
            this.pageCourseSelection.Controls.Add(this.panel1);
            this.pageCourseSelection.Location = new System.Drawing.Point(4, 5);
            this.pageCourseSelection.Name = "pageCourseSelection";
            this.pageCourseSelection.Padding = new System.Windows.Forms.Padding(3);
            this.pageCourseSelection.Size = new System.Drawing.Size(1076, 715);
            this.pageCourseSelection.TabIndex = 1;
            this.pageCourseSelection.Text = "tabPage4";
            // 
            // btnSaveSelections
            // 
            this.btnSaveSelections.Location = new System.Drawing.Point(872, 500);
            this.btnSaveSelections.Name = "btnSaveSelections";
            this.btnSaveSelections.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSelections.TabIndex = 9;
            this.btnSaveSelections.Text = "Kesinleştir";
            this.btnSaveSelections.UseVisualStyleBackColor = true;
            this.btnSaveSelections.Click += new System.EventHandler(this.btnSaveSelections_Click);
            // 
            // flowLayoutPanelSelectedSections
            // 
            this.flowLayoutPanelSelectedSections.Location = new System.Drawing.Point(404, 117);
            this.flowLayoutPanelSelectedSections.Name = "flowLayoutPanelSelectedSections";
            this.flowLayoutPanelSelectedSections.Size = new System.Drawing.Size(543, 377);
            this.flowLayoutPanelSelectedSections.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(3, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 28);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seçilmesi Gereken Dersler";
            // 
            // flowLayoutPanelCourses
            // 
            this.flowLayoutPanelCourses.Location = new System.Drawing.Point(10, 117);
            this.flowLayoutPanelCourses.Name = "flowLayoutPanelCourses";
            this.flowLayoutPanelCourses.Size = new System.Drawing.Size(356, 377);
            this.flowLayoutPanelCourses.TabIndex = 6;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelInfo.Location = new System.Drawing.Point(119, 32);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(54, 16);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "labelInfo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 48);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adı Soyadı\r\nÖğrenci No\r\nMüfredat";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 28);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Öğrenci Bilgileri";
            // 
            // pageSchedule
            // 
            this.pageSchedule.BackColor = System.Drawing.Color.White;
            this.pageSchedule.Controls.Add(this.dataGridViewSchedule);
            this.pageSchedule.Location = new System.Drawing.Point(4, 5);
            this.pageSchedule.Name = "pageSchedule";
            this.pageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.pageSchedule.Size = new System.Drawing.Size(1076, 715);
            this.pageSchedule.TabIndex = 2;
            this.pageSchedule.Text = "pageSchedule";
            // 
            // dataGridViewSchedule
            // 
            this.dataGridViewSchedule.AllowUserToAddRows = false;
            this.dataGridViewSchedule.AllowUserToDeleteRows = false;
            this.dataGridViewSchedule.AllowUserToResizeColumns = false;
            this.dataGridViewSchedule.AllowUserToResizeRows = false;
            this.dataGridViewSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSchedule.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSchedule.Name = "dataGridViewSchedule";
            this.dataGridViewSchedule.ReadOnly = true;
            this.dataGridViewSchedule.Size = new System.Drawing.Size(1070, 709);
            this.dataGridViewSchedule.TabIndex = 6;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.White;
            this.panelProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProfile.Controls.Add(this.btnLogout);
            this.panelProfile.Location = new System.Drawing.Point(970, 37);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(287, 153);
            this.panelProfile.TabIndex = 7;
            this.panelProfile.Visible = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(28, 105);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(241, 43);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Çıkış Yap";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.panelProfile);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Seçim Sistemi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelWarning.ResumeLayout(false);
            this.panelWarning.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.pageCourseSelection.ResumeLayout(false);
            this.pageCourseSelection.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panelProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelGazi;
        private System.Windows.Forms.Button btnGoToCourseSelection;
        private System.Windows.Forms.Button btnGoToHome;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Panel panelWarning;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageHome;
        private System.Windows.Forms.TabPage pageCourseSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCourses;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSelectedSections;
        private System.Windows.Forms.Button btnSaveSelections;
        private System.Windows.Forms.TabPage pageSchedule;
        private System.Windows.Forms.Button btnGoToSchedule;
        private System.Windows.Forms.DataGridView dataGridViewSchedule;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label labelStudentInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLogout;
    }
}