
namespace IBANYR
{
    partial class FrmSetConnectionString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetConnectionString));
            this.txbDBServer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.txbDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDBPasswordAgain = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbDBPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbDBUserName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txbDBServer
            // 
            this.txbDBServer.AccessibleDescription = "SQL szerver neve/IP címe";
            this.txbDBServer.AccessibleName = "SQL szerver neve/IP címe";
            this.txbDBServer.Location = new System.Drawing.Point(218, 12);
            this.txbDBServer.MaxLength = 50;
            this.txbDBServer.Name = "txbDBServer";
            this.txbDBServer.Size = new System.Drawing.Size(225, 27);
            this.txbDBServer.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "SQL szerver neve/IP címe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 21);
            this.label7.TabIndex = 28;
            this.label7.Text = "Portszám:";
            // 
            // numPort
            // 
            this.numPort.AccessibleDescription = "Portszám";
            this.numPort.AccessibleName = "Portszám";
            this.numPort.Location = new System.Drawing.Point(218, 45);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(100, 27);
            this.numPort.TabIndex = 2;
            this.numPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
            // 
            // txbDBName
            // 
            this.txbDBName.AccessibleDescription = "Adatbázis neve";
            this.txbDBName.AccessibleName = "Adatbázis neve";
            this.txbDBName.Location = new System.Drawing.Point(218, 78);
            this.txbDBName.MaxLength = 50;
            this.txbDBName.Name = "txbDBName";
            this.txbDBName.Size = new System.Drawing.Size(225, 27);
            this.txbDBName.TabIndex = 3;
            this.txbDBName.Text = "IBANYR";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "Adatbázis neve:";
            // 
            // txbDBPasswordAgain
            // 
            this.txbDBPasswordAgain.AccessibleDescription = "Szerver jelszó újra megadása";
            this.txbDBPasswordAgain.AccessibleName = "Szerver jelszó újra megadása";
            this.txbDBPasswordAgain.Location = new System.Drawing.Point(218, 177);
            this.txbDBPasswordAgain.MaxLength = 50;
            this.txbDBPasswordAgain.Name = "txbDBPasswordAgain";
            this.txbDBPasswordAgain.PasswordChar = '*';
            this.txbDBPasswordAgain.Size = new System.Drawing.Size(225, 27);
            this.txbDBPasswordAgain.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 21);
            this.label11.TabIndex = 39;
            this.label11.Text = "Szerver jelszó újra:";
            // 
            // txbDBPassword
            // 
            this.txbDBPassword.AccessibleDescription = "Szerver jelszó megadása";
            this.txbDBPassword.AccessibleName = "Szerver jelszó megadása";
            this.txbDBPassword.Location = new System.Drawing.Point(218, 144);
            this.txbDBPassword.MaxLength = 50;
            this.txbDBPassword.Name = "txbDBPassword";
            this.txbDBPassword.PasswordChar = '*';
            this.txbDBPassword.Size = new System.Drawing.Size(225, 27);
            this.txbDBPassword.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 21);
            this.label9.TabIndex = 37;
            this.label9.Text = "Szerver felhasználónév:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 21);
            this.label10.TabIndex = 38;
            this.label10.Text = "Szerver jelszó:";
            // 
            // txbDBUserName
            // 
            this.txbDBUserName.AccessibleDescription = "Szerver felhasználónév";
            this.txbDBUserName.AccessibleName = "Szerver felhasználónév";
            this.txbDBUserName.Location = new System.Drawing.Point(218, 111);
            this.txbDBUserName.MaxLength = 50;
            this.txbDBUserName.Name = "txbDBUserName";
            this.txbDBUserName.PasswordChar = '*';
            this.txbDBUserName.Size = new System.Drawing.Size(225, 27);
            this.txbDBUserName.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(322, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 40);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(195, 215);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 40);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // FrmSetConnectionString
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(455, 267);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbDBPasswordAgain);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbDBPassword);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbDBUserName);
            this.Controls.Add(this.txbDBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDBServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numPort);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetConnectionString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szerver csatlakozási adatok beállítása";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetConnectionString_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDBServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TextBox txbDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDBPasswordAgain;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbDBPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbDBUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}