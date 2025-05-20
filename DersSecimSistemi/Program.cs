using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // LoginForm'dan kullanıcı bilgilerini al
                        int studentID = loginForm.StudentID;
                        string loginID = loginForm.LoginID;
                        string fullName = loginForm.FullName;
                        int departmentID = loginForm.DepartmentID;
                        int classYear = loginForm.ClassYear;

                        loginForm.Dispose();

                        using (MainForm mainForm = new MainForm(studentID, loginID, fullName, departmentID, classYear))
                        {
                            mainForm.ShowDialog();

                            if (mainForm.DialogResult == DialogResult.OK)
                            {
                                // MainForm'dan "Çıkış Yap" sinyali geldi, döngü devam edecek (LoginForm tekrar açılacak)
                                mainForm.Dispose();
                            }
                            else
                            {
                                // MainForm OK dışında bir DialogResult ile kapandı (örn: X tuşu)
                                // Uygulama çıkış sinyali, döngüyü sonlandır
                                mainForm.Dispose();
                                break;
                            }
                        }
                    }
                    else
                    {
                        // LoginForm OK dışında bir DialogResult ile kapandı (örn: kullanıcı Giriş formunu kapattı)
                        // Uygulama çıkış sinyali, döngüyü sonlandır
                        loginForm.Dispose();
                        break;
                    }
                }
            }
        }
    }
}