using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using MissingTrackApp.Services;
using MissingTrackApp.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissingTrackApp
{
    public partial class RegisterForm : Form
    {
        private readonly IUserService _userService;
        private readonly IMissingPartService _partService;
        private readonly User _currentUser;

        public RegisterForm(IMissingPartService partService, IUserService userService, User currentUser)
        {
            InitializeComponent();
            _partService = partService;
            _userService = userService;
            _currentUser = currentUser;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şifre uzunluk kontrolü
            if (password.Length < 6)
            {
                MessageBox.Show("Şifre en az 6 karakter uzunluğunda olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Username = username,
                Role = role
            };

            int? userId = _userService.Register(user, password);

            if (userId.HasValue)
            {
                MessageBox.Show($"Kullanıcı başarıyla kaydedildi.\nKullanıcı ID: {userId.Value}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt başarısız. Kullanıcı adı zaten kullanılıyor olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Operator");
            cmbRole.SelectedIndex = 1;
            txtPassword.UseSystemPasswordChar = true; // şifreyi gizle
        }
    }
}
