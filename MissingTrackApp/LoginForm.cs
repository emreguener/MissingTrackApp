using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MissingTrackApp
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public User LoggedInUser { get; private set; }

        
        public LoginForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            // TEST İÇİN: Gerçek 1366x768 çözünürlükte aç
            //this.Size = new Size(1366, 768);
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.MaximumSize = new Size(1366, 768);
            //this.MinimumSize = new Size(1366, 768);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUserId.Focus();
            lblWarning.Text = "";
            txtPassword.UseSystemPasswordChar = true; // şifreyi gizle
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";

            if (!int.TryParse(txtUserId.Text.Trim(), out int userId))
            {
                lblWarning.Text = "Kullanıcı ID'si bir sayı olmalıdır.";
                lblWarning.ForeColor = Color.Red;
                return;
            }

            string password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(password))
            {
                lblWarning.Text = "Şifre gereklidir.";
                lblWarning.ForeColor = Color.Red;
                return;
            }

            User user = _userService.Authenticate(userId, password);
            if (user != null)
            {
                LoggedInUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblWarning.Text = "Geçersiz kullanıcı ID’si veya şifre.";
                lblWarning.ForeColor = Color.Red;
            }
        }

        // SHA256 hash helper (kullanılmazsa bile silme, Designer bozulmasın)
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
