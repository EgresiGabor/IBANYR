
namespace IBANYR
{
    partial class FrmConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguration));
            this.grbEmail = new System.Windows.Forms.GroupBox();
            this.txbSmtpServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.chbTestMail = new System.Windows.Forms.CheckBox();
            this.chbEnableSSL = new System.Windows.Forms.CheckBox();
            this.txbSmtpPasswordAgain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txbEmailAddress = new System.Windows.Forms.TextBox();
            this.txbSmtpPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbSmtpUserName = new System.Windows.Forms.TextBox();
            this.numRetentionDays = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.chbEnableEmail = new System.Windows.Forms.CheckBox();
            this.numPermanentLockingPeriod = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numFailedLoginNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPwComplexity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numPwLength = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numPwValidityPeriod = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUserGroups = new System.Windows.Forms.Button();
            this.btnUpdateConfigurations = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetentionDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermanentLockingPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFailedLoginNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPwLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPwValidityPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // grbEmail
            // 
            this.grbEmail.AccessibleDescription = "Email küldéséhez szükséges beállítások";
            this.grbEmail.AccessibleName = "Email küldéséhez szükséges beállítások";
            this.grbEmail.Controls.Add(this.txbSmtpServer);
            this.grbEmail.Controls.Add(this.label6);
            this.grbEmail.Controls.Add(this.label7);
            this.grbEmail.Controls.Add(this.numPort);
            this.grbEmail.Controls.Add(this.chbTestMail);
            this.grbEmail.Controls.Add(this.chbEnableSSL);
            this.grbEmail.Controls.Add(this.txbSmtpPasswordAgain);
            this.grbEmail.Controls.Add(this.label8);
            this.grbEmail.Controls.Add(this.label11);
            this.grbEmail.Controls.Add(this.txbEmailAddress);
            this.grbEmail.Controls.Add(this.txbSmtpPassword);
            this.grbEmail.Controls.Add(this.label9);
            this.grbEmail.Controls.Add(this.label10);
            this.grbEmail.Controls.Add(this.txbSmtpUserName);
            this.grbEmail.Location = new System.Drawing.Point(17, 249);
            this.grbEmail.Name = "grbEmail";
            this.grbEmail.Size = new System.Drawing.Size(955, 169);
            this.grbEmail.TabIndex = 8;
            this.grbEmail.TabStop = false;
            this.grbEmail.Text = "Email küldéséhez szükséges beállítások";
            // 
            // txbSmtpServer
            // 
            this.txbSmtpServer.AccessibleDescription = "Az email küldéséhez szükséges SMTP server címét meg kell adni.";
            this.txbSmtpServer.AccessibleName = "SMTP szerver";
            this.txbSmtpServer.Location = new System.Drawing.Point(185, 26);
            this.txbSmtpServer.MaxLength = 50;
            this.txbSmtpServer.Name = "txbSmtpServer";
            this.txbSmtpServer.Size = new System.Drawing.Size(225, 27);
            this.txbSmtpServer.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "SMTP szerver:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "SMTP port:";
            // 
            // numPort
            // 
            this.numPort.AccessibleDescription = "Az email küldéséhez használni kívánt SMTP portszám megadására szolgál. Alapértelm" +
    "ezett érték: 25";
            this.numPort.AccessibleName = "SMTP port";
            this.numPort.Location = new System.Drawing.Point(185, 59);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(100, 27);
            this.numPort.TabIndex = 10;
            this.numPort.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // chbTestMail
            // 
            this.chbTestMail.AccessibleDescription = resources.GetString("chbTestMail.AccessibleDescription");
            this.chbTestMail.AccessibleName = "Teszt üzenet küldése a beállítások frissítésekor";
            this.chbTestMail.AutoSize = true;
            this.chbTestMail.Location = new System.Drawing.Point(540, 125);
            this.chbTestMail.Name = "chbTestMail";
            this.chbTestMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbTestMail.Size = new System.Drawing.Size(377, 25);
            this.chbTestMail.TabIndex = 16;
            this.chbTestMail.Text = "Teszt üzenet küldése a beállítások frissítésekor";
            this.chbTestMail.UseVisualStyleBackColor = true;
            // 
            // chbEnableSSL
            // 
            this.chbEnableSSL.AccessibleDescription = "Az SSL használatához be kell jelölni a jelölőnégyzetet, amennyiben szüksége.";
            this.chbEnableSSL.AccessibleName = "SSL engedélyezése";
            this.chbEnableSSL.AutoSize = true;
            this.chbEnableSSL.Location = new System.Drawing.Point(26, 126);
            this.chbEnableSSL.Name = "chbEnableSSL";
            this.chbEnableSSL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbEnableSSL.Size = new System.Drawing.Size(172, 25);
            this.chbEnableSSL.TabIndex = 12;
            this.chbEnableSSL.Text = "SSL engedélyezése";
            this.chbEnableSSL.UseVisualStyleBackColor = true;
            // 
            // txbSmtpPasswordAgain
            // 
            this.txbSmtpPasswordAgain.AccessibleDescription = "Az SMTP szerveren beállított jelszó megadása újra.";
            this.txbSmtpPasswordAgain.AccessibleName = "Szerver jelszó újra";
            this.txbSmtpPasswordAgain.Location = new System.Drawing.Point(692, 92);
            this.txbSmtpPasswordAgain.MaxLength = 50;
            this.txbSmtpPasswordAgain.Name = "txbSmtpPasswordAgain";
            this.txbSmtpPasswordAgain.PasswordChar = '*';
            this.txbSmtpPasswordAgain.Size = new System.Drawing.Size(225, 27);
            this.txbSmtpPasswordAgain.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "Alias email cím:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(541, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 21);
            this.label11.TabIndex = 33;
            this.label11.Text = "Szerver jelszó újra:";
            // 
            // txbEmailAddress
            // 
            this.txbEmailAddress.AccessibleDescription = "Megadható a levelező eredeti címétől eltérő alias email cím.";
            this.txbEmailAddress.AccessibleName = "Alias email cím";
            this.txbEmailAddress.Location = new System.Drawing.Point(185, 92);
            this.txbEmailAddress.MaxLength = 50;
            this.txbEmailAddress.Name = "txbEmailAddress";
            this.txbEmailAddress.Size = new System.Drawing.Size(225, 27);
            this.txbEmailAddress.TabIndex = 11;
            // 
            // txbSmtpPassword
            // 
            this.txbSmtpPassword.AccessibleDescription = "Az SMTP szerveren beállított jelszó megadása.";
            this.txbSmtpPassword.AccessibleName = "Szerver jelszó";
            this.txbSmtpPassword.Location = new System.Drawing.Point(692, 59);
            this.txbSmtpPassword.MaxLength = 50;
            this.txbSmtpPassword.Name = "txbSmtpPassword";
            this.txbSmtpPassword.PasswordChar = '*';
            this.txbSmtpPassword.Size = new System.Drawing.Size(225, 27);
            this.txbSmtpPassword.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 21);
            this.label9.TabIndex = 29;
            this.label9.Text = "Szerver felhasználónév:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(574, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 21);
            this.label10.TabIndex = 31;
            this.label10.Text = "Szerver jelszó:";
            // 
            // txbSmtpUserName
            // 
            this.txbSmtpUserName.AccessibleDescription = "Az SMTP szerveren beállított felhasználónév (email cím).";
            this.txbSmtpUserName.AccessibleName = "Szerver felhasználónév";
            this.txbSmtpUserName.Location = new System.Drawing.Point(692, 26);
            this.txbSmtpUserName.MaxLength = 50;
            this.txbSmtpUserName.Name = "txbSmtpUserName";
            this.txbSmtpUserName.PasswordChar = '*';
            this.txbSmtpUserName.Size = new System.Drawing.Size(225, 27);
            this.txbSmtpUserName.TabIndex = 13;
            // 
            // numRetentionDays
            // 
            this.numRetentionDays.AccessibleDescription = "Naplóbejegyzések megőrzési ideje napokban";
            this.numRetentionDays.AccessibleName = "Naplóbejegyzések megőrzési ideje napokban";
            this.numRetentionDays.Enabled = false;
            this.numRetentionDays.Location = new System.Drawing.Point(433, 185);
            this.numRetentionDays.Maximum = new decimal(new int[] {
            7305,
            0,
            0,
            0});
            this.numRetentionDays.Name = "numRetentionDays";
            this.numRetentionDays.Size = new System.Drawing.Size(100, 27);
            this.numRetentionDays.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(63, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(363, 21);
            this.label12.TabIndex = 50;
            this.label12.Text = "Naplóbejegyzések megőrzési ideje napokban:";
            // 
            // chbEnableEmail
            // 
            this.chbEnableEmail.AccessibleDescription = "Email küldés engedélyezése";
            this.chbEnableEmail.AccessibleName = "Email küldés engedélyezése";
            this.chbEnableEmail.AutoSize = true;
            this.chbEnableEmail.Location = new System.Drawing.Point(203, 218);
            this.chbEnableEmail.Name = "chbEnableEmail";
            this.chbEnableEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbEnableEmail.Size = new System.Drawing.Size(242, 25);
            this.chbEnableEmail.TabIndex = 7;
            this.chbEnableEmail.Text = "Email küldés engedélyezése";
            this.chbEnableEmail.UseVisualStyleBackColor = true;
            this.chbEnableEmail.CheckedChanged += new System.EventHandler(this.ChbEnableEmail_CheckedChanged);
            // 
            // numPermanentLockingPeriod
            // 
            this.numPermanentLockingPeriod.AccessibleDescription = "Felhasználói fiók ideiglenes zárolásának intervalluma percben megadva";
            this.numPermanentLockingPeriod.AccessibleName = "Felhasználói fiók ideiglenes zárolásának intervalluma percben megadva";
            this.numPermanentLockingPeriod.Enabled = false;
            this.numPermanentLockingPeriod.Location = new System.Drawing.Point(433, 140);
            this.numPermanentLockingPeriod.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numPermanentLockingPeriod.Name = "numPermanentLockingPeriod";
            this.numPermanentLockingPeriod.Size = new System.Drawing.Size(100, 27);
            this.numPermanentLockingPeriod.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(415, 50);
            this.label5.TabIndex = 49;
            this.label5.Text = "Felhasználói fiók ideiglenes zárolásának intervalluma percben megadva:";
            // 
            // numFailedLoginNum
            // 
            this.numFailedLoginNum.AccessibleDescription = "Lehetséges sikertelen belépési próbálkozások száma";
            this.numFailedLoginNum.AccessibleName = "Lehetséges sikertelen belépési próbálkozások száma";
            this.numFailedLoginNum.Enabled = false;
            this.numFailedLoginNum.Location = new System.Drawing.Point(433, 107);
            this.numFailedLoginNum.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFailedLoginNum.Name = "numFailedLoginNum";
            this.numFailedLoginNum.Size = new System.Drawing.Size(100, 27);
            this.numFailedLoginNum.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(414, 21);
            this.label4.TabIndex = 48;
            this.label4.Text = "Lehetséges sikertelen belépési próbálkozások száma:";
            // 
            // cmbPwComplexity
            // 
            this.cmbPwComplexity.AccessibleDescription = "Jelszó bonyolultsági előírása";
            this.cmbPwComplexity.AccessibleName = "Jelszó bonyolultsági előírása";
            this.cmbPwComplexity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPwComplexity.Enabled = false;
            this.cmbPwComplexity.FormattingEnabled = true;
            this.cmbPwComplexity.Location = new System.Drawing.Point(433, 72);
            this.cmbPwComplexity.Name = "cmbPwComplexity";
            this.cmbPwComplexity.Size = new System.Drawing.Size(539, 29);
            this.cmbPwComplexity.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Jelszó bonyolultsági előírása:";
            // 
            // numPwLength
            // 
            this.numPwLength.AccessibleDescription = "Jelszavakkal szemben elvárt minimális karakterhossz";
            this.numPwLength.AccessibleName = "Jelszavakkal szemben elvárt minimális karakterhossz";
            this.numPwLength.Enabled = false;
            this.numPwLength.Location = new System.Drawing.Point(433, 39);
            this.numPwLength.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numPwLength.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPwLength.Name = "numPwLength";
            this.numPwLength.Size = new System.Drawing.Size(100, 27);
            this.numPwLength.TabIndex = 2;
            this.numPwLength.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(414, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "Jelszavakkal szemben elvárt minimális karakterhossz:";
            // 
            // numPwValidityPeriod
            // 
            this.numPwValidityPeriod.AccessibleDescription = "Jelszavak érvényességi ideje napokban megadva";
            this.numPwValidityPeriod.AccessibleName = "Jelszavak érvényességi ideje napokban megadva";
            this.numPwValidityPeriod.Enabled = false;
            this.numPwValidityPeriod.Location = new System.Drawing.Point(433, 6);
            this.numPwValidityPeriod.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numPwValidityPeriod.Name = "numPwValidityPeriod";
            this.numPwValidityPeriod.Size = new System.Drawing.Size(100, 27);
            this.numPwValidityPeriod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 21);
            this.label1.TabIndex = 45;
            this.label1.Text = "Jelszavak érvényességi ideje napokban megadva:";
            // 
            // btnUserGroups
            // 
            this.btnUserGroups.AccessibleDescription = "Csoportok kezelése";
            this.btnUserGroups.AccessibleName = "Csoportok kezelése";
            this.btnUserGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnUserGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserGroups.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUserGroups.FlatAppearance.BorderSize = 0;
            this.btnUserGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserGroups.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUserGroups.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUserGroups.Location = new System.Drawing.Point(372, 424);
            this.btnUserGroups.Name = "btnUserGroups";
            this.btnUserGroups.Size = new System.Drawing.Size(196, 40);
            this.btnUserGroups.TabIndex = 17;
            this.btnUserGroups.Text = "Csoportok kezelése";
            this.btnUserGroups.UseVisualStyleBackColor = false;
            this.btnUserGroups.Click += new System.EventHandler(this.BtnUserGroups_Click);
            // 
            // btnUpdateConfigurations
            // 
            this.btnUpdateConfigurations.AccessibleDescription = "Beállítások frissítése";
            this.btnUpdateConfigurations.AccessibleName = "Beállítások frissítése";
            this.btnUpdateConfigurations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateConfigurations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnUpdateConfigurations.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdateConfigurations.Enabled = false;
            this.btnUpdateConfigurations.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdateConfigurations.FlatAppearance.BorderSize = 0;
            this.btnUpdateConfigurations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateConfigurations.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpdateConfigurations.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateConfigurations.Location = new System.Drawing.Point(574, 424);
            this.btnUpdateConfigurations.Name = "btnUpdateConfigurations";
            this.btnUpdateConfigurations.Size = new System.Drawing.Size(196, 40);
            this.btnUpdateConfigurations.TabIndex = 18;
            this.btnUpdateConfigurations.Text = "Beállítások frissítése";
            this.btnUpdateConfigurations.UseVisualStyleBackColor = false;
            this.btnUpdateConfigurations.Click += new System.EventHandler(this.BtnUpdateConfigurations_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Mégse";
            this.btnCancel.AccessibleName = "Mégse";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(776, 425);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(196, 40);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmConfiguration
            // 
            this.AcceptButton = this.btnUpdateConfigurations;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(984, 477);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUserGroups);
            this.Controls.Add(this.btnUpdateConfigurations);
            this.Controls.Add(this.grbEmail);
            this.Controls.Add(this.numRetentionDays);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chbEnableEmail);
            this.Controls.Add(this.numPermanentLockingPeriod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numFailedLoginNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbPwComplexity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPwLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPwValidityPeriod);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Beállítások";
            this.grbEmail.ResumeLayout(false);
            this.grbEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetentionDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPermanentLockingPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFailedLoginNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPwLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPwValidityPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbEmail;
        private System.Windows.Forms.TextBox txbSmtpServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.CheckBox chbTestMail;
        private System.Windows.Forms.CheckBox chbEnableSSL;
        private System.Windows.Forms.TextBox txbSmtpPasswordAgain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbEmailAddress;
        private System.Windows.Forms.TextBox txbSmtpPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbSmtpUserName;
        private System.Windows.Forms.NumericUpDown numRetentionDays;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chbEnableEmail;
        private System.Windows.Forms.NumericUpDown numPermanentLockingPeriod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numFailedLoginNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPwComplexity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPwLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPwValidityPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUserGroups;
        private System.Windows.Forms.Button btnUpdateConfigurations;
        private System.Windows.Forms.Button btnCancel;
    }
}