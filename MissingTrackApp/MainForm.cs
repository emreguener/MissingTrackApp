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

        public MainForm(IMissingPartService partService, User currentUser)
        {
            InitializeComponent();
            _partService = partService;
            _currentUser = currentUser;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            lblWelcome.Text = $"Hoş Geldiniz, {_currentUser.Username}!";
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            timer1.Interval = 1000; // 1 saniye
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            lblResult.Text = "";
            //maskedSerialStart.Mask = "00000000/0000/0000";
            //maskedSerialStart.PromptChar = '-';
            //maskedSerialStart.Enter += (sender2, args2) => maskedSerialStart.SelectionStart = 0;

            //maskedSerialEnd.Mask = "0000";
            //maskedSerialEnd.PromptChar = '-';
            //maskedSerialEnd.Enter += (sender2, args2) => maskedSerialEnd.SelectionStart = 0;

            //maskedMissingCode.Mask = "00000000";
            //maskedMissingCode.PromptChar = '-';
            //maskedMissingCode.Enter += (sender2, args2) => maskedMissingCode.SelectionStart = 0;

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
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // MainForm'dan çıkış (geri)
            this.Close();
        }


    }
}
