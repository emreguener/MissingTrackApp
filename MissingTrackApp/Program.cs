using System;
using System.Windows.Forms;
using MissingTrackApp.Services;
using MissingTrackApp.Interfaces;
using MissingTrackApp.Entities;
using MissingTrackApp.UI;

namespace MissingTrackApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUserService userService = new UserService();
            IMissingPartService partService = new MissingPartService();

            while (true)
            {
                using (var loginForm = new LoginForm(userService))
                {
                    var result = loginForm.ShowDialog(); // modal olarak loginForm açılır

                    if (result == DialogResult.OK && loginForm.LoggedInUser != null)
                    {
                        using (var mainForm = new MainForm(partService, loginForm.LoggedInUser))
                        {
                            var mainResult = mainForm.ShowDialog(); // modal olarak mainForm açılır
                            if (mainResult == DialogResult.Cancel)
                            {
                                // Geri butonuna basıldıysa tekrar login form'a dön 
                                continue; 
                            }
                            else
                            {
                                // Kullanıcı çıkmak istiyorsa uygulamayı kapat
                                break;
                            }
                        }
                    }
                    else
                    {
                        break; // Login başarısızsa uygulamadan çık
                    }
                }
            }

            Application.Exit();
        }
    }
}
