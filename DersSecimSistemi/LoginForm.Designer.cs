﻿namespace DersSecimSistemi
{
    partial class LoginForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtLoginID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.labelLoginID = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelGazi = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoginID
            // 
            this.txtLoginID.BackColor = System.Drawing.Color.White;
            this.txtLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginID.Font = new System.Drawing.Font("Arial", 10F);
            this.txtLoginID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.txtLoginID.Location = new System.Drawing.Point(171, 218);
            this.txtLoginID.Name = "txtLoginID";
            this.txtLoginID.Size = new System.Drawing.Size(234, 23);
            this.txtLoginID.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.txtPassword.Location = new System.Drawing.Point(171, 262);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(234, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnLogin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(99)))), ((int)(((byte)(106)))));
            this.btnLogin.Location = new System.Drawing.Point(220, 321);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 30);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // labelLoginID
            // 
            this.labelLoginID.AutoSize = true;
            this.labelLoginID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelLoginID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(79)))), ((int)(((byte)(118)))));
            this.labelLoginID.Location = new System.Drawing.Point(168, 200);
            this.labelLoginID.Name = "labelLoginID";
            this.labelLoginID.Size = new System.Drawing.Size(115, 16);
            this.labelLoginID.TabIndex = 3;
            this.labelLoginID.Text = "Öğrenci Numarası:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(79)))), ((int)(((byte)(118)))));
            this.labelPassword.Location = new System.Drawing.Point(168, 244);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(37, 16);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Şifre:";
            // 
            // labelGazi
            // 
            this.labelGazi.AutoSize = true;
            this.labelGazi.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelGazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.labelGazi.Location = new System.Drawing.Point(216, 153);
            this.labelGazi.Name = "labelGazi";
            this.labelGazi.Size = new System.Drawing.Size(150, 22);
            this.labelGazi.TabIndex = 6;
            this.labelGazi.Text = "Gazi Üniversitesi";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.labelWarning.Location = new System.Drawing.Point(191, 364);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 16);
            this.labelWarning.TabIndex = 7;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(99)))), ((int)(((byte)(106)))));
            this.chkShowPassword.Location = new System.Drawing.Point(171, 286);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(91, 18);
            this.chkShowPassword.TabIndex = 8;
            this.chkShowPassword.Text = "Şifreyi göster";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::DersSecimSistemi.Properties.Resources.Gazi_Üniversitesi_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(220, 10);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(140, 140);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 401);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.labelGazi);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLoginID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLoginID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ders Seçim Sistemi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginID;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label labelLoginID;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelGazi;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.CheckBox chkShowPassword;
    }
}

