
namespace IBANYR
{
    partial class FrmContactManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContactManager));
            this.txbContId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.txbAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbContName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbContId
            // 
            this.txbContId.AccessibleDescription = "A kapcsolattartó azonosítójának megadása/módosítása nem lehetséges! Az adatbáziss" +
    "zerver automatikusan generált értéke.";
            this.txbContId.AccessibleName = "Kapcsolattartó azonosító";
            this.txbContId.Location = new System.Drawing.Point(228, 6);
            this.txbContId.Name = "txbContId";
            this.txbContId.ReadOnly = true;
            this.txbContId.Size = new System.Drawing.Size(100, 27);
            this.txbContId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AccessibleDescription = "";
            this.label1.AccessibleName = "";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Kapcsolattartó azonosító:";
            // 
            // mtbPhone
            // 
            this.mtbPhone.AccessibleDescription = "Telefonszám megadása opcionális. Megadása esetén meg kell, hogy feleljen a magyar" +
    " telefonszámokkal szemben támasztott formai előírásoknak.";
            this.mtbPhone.AccessibleName = "Telefonszám";
            this.mtbPhone.Location = new System.Drawing.Point(228, 109);
            this.mtbPhone.Mask = "(90) 999-9990";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(110, 27);
            this.mtbPhone.TabIndex = 4;
            // 
            // txbAddress
            // 
            this.txbAddress.AccessibleDescription = "Levelezési cím megadása opcionális és maximum 200 karakter hosszú lehet.";
            this.txbAddress.AccessibleName = "Levelezési cím";
            this.txbAddress.Location = new System.Drawing.Point(228, 141);
            this.txbAddress.MaxLength = 200;
            this.txbAddress.Multiline = true;
            this.txbAddress.Name = "txbAddress";
            this.txbAddress.Size = new System.Drawing.Size(219, 61);
            this.txbAddress.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(100, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 21);
            this.label8.TabIndex = 43;
            this.label8.Text = "Levelezési cím:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(113, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "Telefonszám:";
            // 
            // txbEmail
            // 
            this.txbEmail.AccessibleDescription = "Email cím megadása opcionális. Megadása esetén maximum 50 karakter hosszú lehet é" +
    "s meg kell, hogy feleljen az email címmekkel szemben támasztott formai követelmé" +
    "nyeknek.";
            this.txbEmail.AccessibleName = "Email cím";
            this.txbEmail.Location = new System.Drawing.Point(228, 75);
            this.txbEmail.MaxLength = 50;
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(219, 27);
            this.txbEmail.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(135, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Email cím:";
            // 
            // txbContName
            // 
            this.txbContName.AccessibleDescription = "A kapcsolattartó nevének megadása kötelező, és maximum 50 karakter hosszú lehet!";
            this.txbContName.AccessibleName = "Név";
            this.txbContName.Location = new System.Drawing.Point(228, 40);
            this.txbContName.MaxLength = 50;
            this.txbContName.Name = "txbContName";
            this.txbContName.Size = new System.Drawing.Size(219, 27);
            this.txbContName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Név*:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Mégsem vagy bezárás";
            this.btnCancel.AccessibleName = "Mégsem vagy bezárás";
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(296, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(140, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(123, 208);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 102;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // FrmContactManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(458, 290);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.txbAddress);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbContName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbContId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmContactManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kapcsolattartó kezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbContId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.TextBox txbAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbContName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label23;
    }
}