namespace MissingTrackApp.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.maskedSerialStart = new System.Windows.Forms.MaskedTextBox();
            this.maskedSerialEnd = new System.Windows.Forms.MaskedTextBox();
            this.maskedMissingCode = new System.Windows.Forms.MaskedTextBox();
            this.lblSerialStart = new System.Windows.Forms.Label();
            this.lblSerialEnd = new System.Windows.Forms.Label();
            this.lblMissingCode = new System.Windows.Forms.Label();
            this.lblHelpSerialStart = new System.Windows.Forms.Label();
            this.lblHelpSerialEnd = new System.Windows.Forms.Label();
            this.lblHelpMissingCode = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblClock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.Location = new System.Drawing.Point(276, 37);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(114, 25);
            this.lblWelcome.TabIndex = 3;
            this.lblWelcome.Text = "lblWelcome";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Location = new System.Drawing.Point(254, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 51);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "KAYDET";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.Location = new System.Drawing.Point(249, 403);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(85, 25);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "lblResult";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Location = new System.Drawing.Point(637, 337);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(136, 51);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "TEMİZLE";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Location = new System.Drawing.Point(701, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 42);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "ÇIKIŞ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // maskedSerialStart
            // 
            this.maskedSerialStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedSerialStart.Location = new System.Drawing.Point(277, 123);
            this.maskedSerialStart.Mask = "(00000000)/(0000)/(0000)";
            this.maskedSerialStart.Name = "maskedSerialStart";
            this.maskedSerialStart.PromptChar = '-';
            this.maskedSerialStart.Size = new System.Drawing.Size(496, 30);
            this.maskedSerialStart.TabIndex = 1;
            // 
            // maskedSerialEnd
            // 
            this.maskedSerialEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedSerialEnd.Location = new System.Drawing.Point(277, 191);
            this.maskedSerialEnd.Mask = "0000";
            this.maskedSerialEnd.Name = "maskedSerialEnd";
            this.maskedSerialEnd.PromptChar = '-';
            this.maskedSerialEnd.Size = new System.Drawing.Size(496, 30);
            this.maskedSerialEnd.TabIndex = 2;
            // 
            // maskedMissingCode
            // 
            this.maskedMissingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maskedMissingCode.Location = new System.Drawing.Point(277, 259);
            this.maskedMissingCode.Mask = "00000000";
            this.maskedMissingCode.Name = "maskedMissingCode";
            this.maskedMissingCode.PromptChar = '-';
            this.maskedMissingCode.Size = new System.Drawing.Size(496, 30);
            this.maskedMissingCode.TabIndex = 3;
            // 
            // lblSerialStart
            // 
            this.lblSerialStart.AutoSize = true;
            this.lblSerialStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSerialStart.Location = new System.Drawing.Point(50, 126);
            this.lblSerialStart.Name = "lblSerialStart";
            this.lblSerialStart.Size = new System.Drawing.Size(163, 25);
            this.lblSerialStart.TabIndex = 11;
            this.lblSerialStart.Text = "Seri Başlangıcı:";
            // 
            // lblSerialEnd
            // 
            this.lblSerialEnd.AutoSize = true;
            this.lblSerialEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSerialEnd.Location = new System.Drawing.Point(50, 194);
            this.lblSerialEnd.Name = "lblSerialEnd";
            this.lblSerialEnd.Size = new System.Drawing.Size(110, 25);
            this.lblSerialEnd.TabIndex = 12;
            this.lblSerialEnd.Text = "Seri Bitişi:";
            // 
            // lblMissingCode
            // 
            this.lblMissingCode.AutoSize = true;
            this.lblMissingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMissingCode.Location = new System.Drawing.Point(50, 262);
            this.lblMissingCode.Name = "lblMissingCode";
            this.lblMissingCode.Size = new System.Drawing.Size(190, 25);
            this.lblMissingCode.TabIndex = 13;
            this.lblMissingCode.Text = "Eksik Parça Kodu:";
            // 
            // lblHelpSerialStart
            // 
            this.lblHelpSerialStart.AutoSize = true;
            this.lblHelpSerialStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHelpSerialStart.Location = new System.Drawing.Point(274, 156);
            this.lblHelpSerialStart.Name = "lblHelpSerialStart";
            this.lblHelpSerialStart.Size = new System.Drawing.Size(355, 16);
            this.lblHelpSerialStart.TabIndex = 14;
            this.lblHelpSerialStart.Text = "Aralıktaki ilk seri numarasını girin (örn. 31111111/2504/0001)";
            // 
            // lblHelpSerialEnd
            // 
            this.lblHelpSerialEnd.AutoSize = true;
            this.lblHelpSerialEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHelpSerialEnd.Location = new System.Drawing.Point(274, 224);
            this.lblHelpSerialEnd.Name = "lblHelpSerialEnd";
            this.lblHelpSerialEnd.Size = new System.Drawing.Size(373, 16);
            this.lblHelpSerialEnd.TabIndex = 15;
            this.lblHelpSerialEnd.Text = "Aralığın kaç seri numarası ileriye kadar devam edeceğini girin";
            // 
            // lblHelpMissingCode
            // 
            this.lblHelpMissingCode.AutoSize = true;
            this.lblHelpMissingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHelpMissingCode.Location = new System.Drawing.Point(274, 292);
            this.lblHelpMissingCode.Name = "lblHelpMissingCode";
            this.lblHelpMissingCode.Size = new System.Drawing.Size(185, 16);
            this.lblHelpMissingCode.TabIndex = 16;
            this.lblHelpMissingCode.Text = "Eksik parçaya ait 8 haneli kod";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Location = new System.Drawing.Point(2, 1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 42);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "GERİ";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(276, 74);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(81, 25);
            this.lblClock.TabIndex = 18;
            this.lblClock.Text = "lblClock";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblHelpMissingCode);
            this.Controls.Add(this.lblHelpSerialEnd);
            this.Controls.Add(this.lblHelpSerialStart);
            this.Controls.Add(this.lblMissingCode);
            this.Controls.Add(this.lblSerialEnd);
            this.Controls.Add(this.lblSerialStart);
            this.Controls.Add(this.maskedMissingCode);
            this.Controls.Add(this.maskedSerialEnd);
            this.Controls.Add(this.maskedSerialStart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "Eksik Parça Kayıt Paneli";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.MaskedTextBox maskedSerialStart;
        private System.Windows.Forms.MaskedTextBox maskedSerialEnd;
        private System.Windows.Forms.MaskedTextBox maskedMissingCode;
        private System.Windows.Forms.Label lblSerialStart;
        private System.Windows.Forms.Label lblSerialEnd;
        private System.Windows.Forms.Label lblMissingCode;
        private System.Windows.Forms.Label lblHelpSerialStart;
        private System.Windows.Forms.Label lblHelpSerialEnd;
        private System.Windows.Forms.Label lblHelpMissingCode;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblClock;
    }
}