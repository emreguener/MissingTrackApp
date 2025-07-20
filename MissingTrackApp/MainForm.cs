using MissingTrackApp.Entities;
using MissingTrackApp.Interfaces;
using MissingTrackApp.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MissingTrackApp.UI
{
    public partial class MainForm : Form
    {
        private readonly IMissingPartService _partService;
        private readonly User _currentUser;
        private readonly LoginForm _loginForm;
        private bool _isBackClicked = false;
        private bool _isExitClicked = false;

        public MainForm(IMissingPartService partService, User currentUser)
        {
            // TEST İÇİN: Gerçek 1366x768 çözünürlükte aç
            //this.Size = new Size(1366, 768);
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.MaximumSize = new Size(1366, 768);
            //this.MinimumSize = new Size(1366, 768);
            
            
            InitializeComponent();
            _partService = partService;
            _currentUser = currentUser;

            if (_currentUser.Role == "Admin")
                btnRegisterUser.Visible = true;
            else
                btnRegisterUser.Visible = false;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            lblWelcome.Text = $"Hoş Geldiniz, {_currentUser.Username}!";
            lblRole.Text = $"Rol: {_currentUser.Role}";
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            maskedSerialStart.Focus();
            lblResult.Text = "";
            // Sayısal giriş zorlaması
            maskedSerialStart.KeyPress += NumericOnly_KeyPress;
            maskedSerialEnd.KeyPress += NumericOnly_KeyPress;
            maskedMissingCode.KeyPress += NumericOnly_KeyPress;
        }


        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            string serialEnd = maskedSerialEnd.Text.Trim();
            string missingCode = maskedMissingCode.Text.Trim();

            // Validasyonlar (daha servise geçmeden hızlıca)
            maskedSerialStart.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string serialStart = maskedSerialStart.Text;

            if (serialStart.Length != 16 || !serialStart.StartsWith("3"))
            {
                lblResult.Text = "Seri başlangıcı 16 haneli olmalı ve 3 ile başlamalıdır.";
                lblResult.ForeColor = Color.Red;
                return;
            }

            if (serialEnd.Length != 4 || !int.TryParse(serialEnd, out _))
            {
                lblResult.Text = "Seri bitişi 4 haneli bir sayı olmalıdır.";
                lblResult.ForeColor = Color.Red;
                return;
            }

            if (missingCode.Length != 8 || !int.TryParse(missingCode, out _))
            {
                lblResult.Text = "Eksik parça kodu 8 haneli bir sayı olmalıdır.";
                lblResult.ForeColor = Color.Red;
                return;
            }

            try
            {
                _partService.AddMissingParts(serialStart, serialEnd, missingCode, _currentUser.Id);

                int startNo = int.Parse(serialStart.Substring(12, 4));
                int endNo = int.Parse(serialEnd);
                int recordCount = endNo - startNo + 1; // eksik parça sayısı dB'ye kaydedilen kayıt sayısı

                lblResult.Text = $"{recordCount} adet eksik parça başarıyla eklendi.";
                lblResult.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Hata: {ex.Message}";
                lblResult.ForeColor = Color.Red;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            maskedSerialStart.Clear();
            maskedSerialEnd.Clear();
            maskedMissingCode.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            _isExitClicked = true;
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel; // MainForm'dan çıkış (geri)
            //this.Close();
            _isBackClicked = true;
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isBackClicked)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.Abort; // Exit veya çarpı
            }
        }

        

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                IUserService userService = new UserService();
                using (RegisterForm registerForm = new RegisterForm(_partService, userService, _currentUser))
                {
                    this.Hide();
                    registerForm.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt formu açılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var changePasswordForm = new ChangePasswordForm(_currentUser, _partService))
            {
                this.Hide();
                changePasswordForm.ShowDialog();
                this.Show();
            }
        }
        // tabletlerde textboxlara tıklanınca imleç en başa (ilk indekse) gitsin diye
        
        private void maskedSerialStart_Enter(object sender, EventArgs e)
        {
            maskedSerialStart.SelectionStart = 0; 
            maskedSerialStart.SelectionLength = 0;
        }

        private void maskedSerialEnd_Enter(object sender, EventArgs e)
        {
            maskedSerialEnd.SelectionStart = 0; 
            maskedSerialEnd.SelectionLength = 0;
        }

        private void maskedMissingCode_Enter(object sender, EventArgs e)
        {
            maskedMissingCode.SelectionStart = 0;
            maskedMissingCode.SelectionLength = 0;
        }

    }
}
