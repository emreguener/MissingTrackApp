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
    public partial class ChangePasswordForm : Form
    {
        private readonly User _currentUser;
        private readonly IUserService _userService;

        private readonly IMissingPartService _partService;

        public ChangePasswordForm(User currentUser, IMissingPartService partService)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _partService = partService;
            _userService = new UserService();

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            if (_currentUser.Role == "Admin")
            {
                cmbUserSelection.Visible = true;
                txtBoxUserNewPassword.Visible = true;
                btnUserSave.Visible = true;
                LoadUsersIntoComboBox();
            }
            else
            {
                cmbUserSelection.Visible = false;
                txtBoxUserNewPassword.Visible = false;
                btnUserSave.Visible = false;
                lblSelectedUserChoice.Visible = false;
                lblUserChoice.Visible = false;
            }
        }


        private void LoadUsersIntoComboBox()
        {
            var allUsers = _userService.GetAllUsers(); // tüm kullanıcılar (User listesi)
            cmbUserSelection.DataSource = allUsers;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            txtBoxCurrentPassword.Focus();
            txtBoxCurrentPassword.UseSystemPasswordChar = true; // şifreyi gizle
            txtBoxNewPassword.UseSystemPasswordChar = true; // yeni şifreyi gizle
            txtBoxUserNewPassword.UseSystemPasswordChar = true; // admin için yeni şifreyi gizle
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtBoxCurrentPassword.Text;
            string newPassword = txtBoxNewPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Yeni şifre en az 6 karakter olmalıdır.");
                return;
            }

            bool result = _userService.ChangePassword(_currentUser.Id, currentPassword, newPassword);
            if (result)
            {
                MessageBox.Show("Şifre başarıyla güncellendi.");
                this.Close(); // formu kapat
            }
            else
            {
                MessageBox.Show("Mevcut şifre yanlış.");
            }
        }



        private void btnUserSave_Click(object sender, EventArgs e)
        {
            if (cmbUserSelection.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            string newPassword = txtBoxUserNewPassword.Text;
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                MessageBox.Show("Yeni şifre en az 6 karakter olmalıdır.");
                return;
            }

            User selectedUser = cmbUserSelection.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Geçerli bir kullanıcı seçilemedi.");
                return;
            }

            bool result = _userService.ChangePasswordAsAdmin(selectedUser.Id, newPassword);

            if (result)
            {
                MessageBox.Show($"'{selectedUser.Username}' kullanıcısının şifresi başarıyla güncellendi.");
            }
            else
            {
                MessageBox.Show("Şifre güncellenemedi.");
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


    }
}
