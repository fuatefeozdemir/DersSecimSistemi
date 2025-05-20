using System;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    public partial class LoginForm : Form
    {
        public string LoginID {get; private set;}
        public int StudentID {get; private set;}
        public string FullName {get; private set;}
        public int DepartmentID {get; private set;}
        public int ClassYear {get; private set;}

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = txtLoginID.Text;
            string password = txtPassword.Text;

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = "SELECT StudentID, FullName, DepartmentID, ClassYear FROM Students WHERE LoginID = @LoginID AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LoginID", loginID);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Giriş başarılı
                            StudentID = reader.GetInt32(0);
                            FullName = reader.GetString(1);
                            DepartmentID = reader.GetInt32(2);
                            ClassYear = reader.GetInt32(3);
                            LoginID = loginID;

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            labelWarning.Text = "Geçersiz giriş. Lütfen tekrar deneyin.";
                            SystemSounds.Exclamation.Play();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        //
        // Şifreyi göster seçeneğiyle şifrenin gizlenip gizlenmeyeceğini ayarlayan metot
        //
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
