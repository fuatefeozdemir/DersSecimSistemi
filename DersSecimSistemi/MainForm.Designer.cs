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
            this.labelStudentInfo = new System.Windows.Forms.Label();
            this.panelSide = new System.Windows.Forms.Panel();
            this.btnGoToCourseSelection = new System.Windows.Forms.Button();
            this.btnGoToHome = new System.Windows.Forms.Button();
            this.labelGazi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.panelWarning = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageHome = new System.Windows.Forms.TabPage();
            this.pageCourseSelection = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelWarning.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageHome.SuspendLayout();
            this.pageCourseSelection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelHeader.Controls.Add(this.labelStudentInfo);
            this.panelHeader.Location = new System.Drawing.Point(180, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1084, 37);
            this.panelHeader.TabIndex = 0;
            // 
            // labelStudentInfo
            // 
            this.labelStudentInfo.AutoSize = true;
            this.labelStudentInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelStudentInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelStudentInfo.ForeColor = System.Drawing.Color.White;
            this.labelStudentInfo.Location = new System.Drawing.Point(844, 9);
            this.labelStudentInfo.Name = "labelStudentInfo";
            this.labelStudentInfo.Size = new System.Drawing.Size(72, 16);
            this.labelStudentInfo.TabIndex = 1;
            this.labelStudentInfo.Text = "StudentInfo";
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelSide.Controls.Add(this.btnGoToCourseSelection);
            this.panelSide.Controls.Add(this.btnGoToHome);
            this.panelSide.Controls.Add(this.labelGazi);
            this.panelSide.Controls.Add(this.pictureBox1);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(180, 681);
            this.panelSide.TabIndex = 1;
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
            this.labelWarning.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWarning.ForeColor = System.Drawing.Color.White;
            this.labelWarning.Location = new System.Drawing.Point(48, 29);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 22);
            this.labelWarning.TabIndex = 2;
            // 
            // panelWarning
            // 
            this.panelWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.panelWarning.Controls.Add(this.labelWarning);
            this.panelWarning.Location = new System.Drawing.Point(159, 94);
            this.panelWarning.Name = "panelWarning";
            this.panelWarning.Size = new System.Drawing.Size(677, 72);
            this.panelWarning.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageHome);
            this.tabControl.Controls.Add(this.pageCourseSelection);
            this.tabControl.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl.Location = new System.Drawing.Point(180, 37);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1084, 644);
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
            this.pageHome.Size = new System.Drawing.Size(1076, 635);
            this.pageHome.TabIndex = 0;
            this.pageHome.Text = "tabPage3";
            // 
            // pageCourseSelection
            // 
            this.pageCourseSelection.BackColor = System.Drawing.Color.White;
            this.pageCourseSelection.Controls.Add(this.labelInfo);
            this.pageCourseSelection.Controls.Add(this.label2);
            this.pageCourseSelection.Controls.Add(this.panel1);
            this.pageCourseSelection.Location = new System.Drawing.Point(4, 5);
            this.pageCourseSelection.Name = "pageCourseSelection";
            this.pageCourseSelection.Padding = new System.Windows.Forms.Padding(3);
            this.pageCourseSelection.Size = new System.Drawing.Size(1076, 635);
            this.pageCourseSelection.TabIndex = 1;
            this.pageCourseSelection.Text = "tabPage4";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 14);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 64);
            this.label2.TabIndex = 6;
            this.label2.Text = "Adı Soyadı\r\nÖğrenci No\r\nBölüm/Sınıf\r\nMüfredat";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelInfo.Location = new System.Drawing.Point(136, 48);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(54, 16);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "labelInfo";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
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
            this.panelSide.ResumeLayout(false);
            this.panelSide.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelWarning.ResumeLayout(false);
            this.panelWarning.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageHome.ResumeLayout(false);
            this.pageCourseSelection.ResumeLayout(false);
            this.pageCourseSelection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelStudentInfo;
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
    }
}