using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersSecimSistemi
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Giriş başarılıysa MainForm'u başlat
                    Application.Run(new MainForm(loginForm.StudentID, loginForm.LoginID, loginForm.FullName, loginForm.DepartmentID, loginForm.ClassYear));
                }
                // Giriş başarısızsa veya iptal edilirse, hiçbir şey çalışmaz ve uygulama kapanır
            }
        }
    }
}
