
namespace IBANYR
{
    partial class FrmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePassword));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txbOldPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNewPasswordAgain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleDescription = "Módosítás";
            this.btnUpdate.AccessibleName = "Módosítás";
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(61, 217);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 40);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "&Módosítás";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // txbOldPassword
            // 
            this.txbOldPassword.AccessibleDescription = "Jelenlegi jelszó megadása szükséges ebben a mezőben.";
            this.txbOldPassword.AccessibleName = "Jelenlegi jelszó";
            this.txbOldPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txbOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbOldPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbOldPassword.Location = new System.Drawing.Point(12, 39);
            this.txbOldPassword.MaxLength = 50;
            this.txbOldPassword.Name = "txbOldPassword";
            this.txbOldPassword.PasswordChar = '*';
            this.txbOldPassword.Size = new System.Drawing.Size(250, 27);
            this.txbOldPassword.TabIndex = 2;
            this.txbOldPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AccessibleName = "Jelenlegi jelszó";
            this.lblPassword.Location = new System.Drawing.Point(12, 9);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(139, 27);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Jelenlegi jelszó";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.AccessibleDescription = "Ú jelszó megadása szükséges ebben a mezőben.";
            this.txbNewPassword.AccessibleName = "Új jelszó";
            this.txbNewPassword.BackColor = System.Drawing.SystemColors.Window;
            this.txbNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbNewPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbNewPassword.Location = new System.Drawing.Point(12, 99);
            this.txbNewPassword.MaxLength = 50;
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.Size = new System.Drawing.Size(250, 27);
            this.txbNewPassword.TabIndex = 4;
            this.txbNewPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Új jelszó";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbNewPasswordAgain
            // 
            this.txbNewPasswordAgain.AccessibleDescription = "Új jelszó újramegadása szükséges ebben a mezőben";
            this.txbNewPasswordAgain.AccessibleName = "Új jelszó újra";
            this.txbNewPasswordAgain.BackColor = System.Drawing.SystemColors.Window;
            this.txbNewPasswordAgain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbNewPasswordAgain.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txbNewPasswordAgain.Location = new System.Drawing.Point(12, 159);
            this.txbNewPasswordAgain.MaxLength = 50;
            this.txbNewPasswordAgain.Name = "txbNewPasswordAgain";
            this.txbNewPasswordAgain.PasswordChar = '*';
            this.txbNewPasswordAgain.Size = new System.Drawing.Size(250, 27);
            this.txbNewPasswordAgain.TabIndex = 6;
            this.txbNewPasswordAgain.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Új jelszó újra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmChangePassword
            // 
            this.AcceptButton = this.btnUpdate;
            this.AccessibleDescription = "Saját jelszó módosítására szolgáló ablak";
            this.AccessibleName = "Jelszó módosítása";
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 269);
            this.Controls.Add(this.txbNewPasswordAgain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbNewPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txbOldPassword);
            this.Controls.Add(this.lblPassword);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jelszó módosítása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txbOldPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNewPasswordAgain;
        private System.Windows.Forms.Label label2;
    }
}