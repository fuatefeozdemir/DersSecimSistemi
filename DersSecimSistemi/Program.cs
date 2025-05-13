using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersSecimSistemi
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
                Application.Run(new MainForm(loginForm.LoginID, loginForm.FullName));
            }
            // Giriş başarısızsa veya iptal edilirse, hiçbir şey çalışmaz ve uygulama kapanır
        }
    }

}
