using System;
using System.Data.SqlClient;
using System.Media;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    public partial class LoginForm : Form
    {
        public string LoginID { get; private set; }
        public string FullName { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = txtLoginID.Text;
            string password = txtPassword.Text;

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = "SELECT COUNT(1) FROM [dbo].[Students] WHERE LoginID = @LoginID AND Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LoginID", loginID);
                    command.Parameters.AddWithValue("@Password", password);

                    int result = (int)command.ExecuteScalar();

                    if (result == 1)
                    {
                        // Kullanıcı adı ve şifresi doğru
                        string getUserQuery = "SELECT FullName FROM Students WHERE LoginID = @LoginID";
                        using (SqlCommand getUserCommand = new SqlCommand(getUserQuery, connection))
                        {
                            getUserCommand.Parameters.AddWithValue("@LoginID", loginID);
                            FullName = (string)getUserCommand.ExecuteScalar();
                            LoginID = loginID; // LoginID'yi de set et
                        }

                        // Başarılı giriş yapıldı, dialog result'ı OK yap
                        this.DialogResult = DialogResult.OK;
                        this.Close(); // LoginForm kapanır
                    }
                    else
                    {
                        labelWarning.Text = "Geçersiz giriş. Lütfen tekrar deneyin.";
                        SystemSounds.Exclamation.Play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}
