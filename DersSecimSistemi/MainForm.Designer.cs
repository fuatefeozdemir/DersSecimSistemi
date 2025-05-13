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
            this.labelCurriculum = new System.Windows.Forms.Label();
            this.labelStudentInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGoToCourseSelection = new System.Windows.Forms.Button();
            this.btnGoToHome = new System.Windows.Forms.Button();
            this.labelGazi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWarning = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelHeader.Controls.Add(this.labelCurriculum);
            this.panelHeader.Controls.Add(this.labelStudentInfo);
            this.panelHeader.Location = new System.Drawing.Point(180, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1084, 37);
            this.panelHeader.TabIndex = 0;
            // 
            // labelCurriculum
            // 
            this.labelCurriculum.AutoSize = true;
            this.labelCurriculum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelCurriculum.ForeColor = System.Drawing.Color.White;
            this.labelCurriculum.Location = new System.Drawing.Point(541, 12);
            this.labelCurriculum.Name = "labelCurriculum";
            this.labelCurriculum.Size = new System.Drawing.Size(80, 14);
            this.labelCurriculum.TabIndex = 4;
            this.labelCurriculum.Text = "labelCurriculum";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.btnGoToCourseSelection);
            this.panel1.Controls.Add(this.btnGoToHome);
            this.panel1.Controls.Add(this.labelGazi);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 681);
            this.panel1.TabIndex = 1;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.labelWarning);
            this.panel2.Location = new System.Drawing.Point(381, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 72);
            this.panel2.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Seçim Sistemi";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelStudentInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelGazi;
        private System.Windows.Forms.Button btnGoToCourseSelection;
        private System.Windows.Forms.Button btnGoToHome;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCurriculum;
    }
}