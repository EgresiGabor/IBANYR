
namespace IBANYR
{
    partial class FrmUserManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManager));
            this.label1 = new System.Windows.Forms.Label();
            this.txbUId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbUName = new System.Windows.Forms.TextBox();
            this.chbULocked = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lsbGroups = new System.Windows.Forms.ListBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.lsbUserGroup = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbPost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Felhasználóazonosító:";
            // 
            // txbUId
            // 
            this.txbUId.AccessibleDescription = "A felhasználóazonosító megadása/módosítása nem lehetséges! Az adatbázisszerver au" +
    "tomatikusan generált értéke.";
            this.txbUId.AccessibleName = "Felhasználóazonosító";
            this.txbUId.Location = new System.Drawing.Point(189, 6);
            this.txbUId.Name = "txbUId";
            this.txbUId.ReadOnly = true;
            this.txbUId.Size = new System.Drawing.Size(100, 27);
            this.txbUId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Felhasználónév*:";
            // 
            // txbUName
            // 
            this.txbUName.AccessibleDescription = "A felhasználónév megadása kötelező, valamint minimum 3 és maximum 50 karakter hos" +
    "szú lehet!";
            this.txbUName.AccessibleName = "Felhasználónév";
            this.txbUName.Location = new System.Drawing.Point(189, 38);
            this.txbUName.MaxLength = 50;
            this.txbUName.Name = "txbUName";
            this.txbUName.Size = new System.Drawing.Size(219, 27);
            this.txbUName.TabIndex = 2;
            // 
            // chbULocked
            // 
            this.chbULocked.AccessibleDescription = "Megjelölése esetén a felhasználó fiókja zárolásra kerül!";
            this.chbULocked.AccessibleName = "Felhasználó zárolva";
            this.chbULocked.AutoSize = true;
            this.chbULocked.Location = new System.Drawing.Point(24, 205);
            this.chbULocked.Name = "chbULocked";
            this.chbULocked.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbULocked.Size = new System.Drawing.Size(179, 25);
            this.chbULocked.TabIndex = 7;
            this.chbULocked.Text = "Felhasználó zárolva";
            this.chbULocked.UseVisualStyleBackColor = true;
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
            this.btnOk.Location = new System.Drawing.Point(174, 457);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(330, 457);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lsbGroups
            // 
            this.lsbGroups.AccessibleDescription = "Jogosultsági csoportok listája";
            this.lsbGroups.AccessibleName = "Jogosultsági csoportok listája";
            this.lsbGroups.FormattingEnabled = true;
            this.lsbGroups.ItemHeight = 21;
            this.lsbGroups.Location = new System.Drawing.Point(16, 255);
            this.lsbGroups.Name = "lsbGroups";
            this.lsbGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbGroups.Size = new System.Drawing.Size(191, 172);
            this.lsbGroups.TabIndex = 8;
            this.lsbGroups.SelectedIndexChanged += new System.EventHandler(this.LsbGroups_SelectedIndexChanged);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(12, 231);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(187, 21);
            this.lblGroups.TabIndex = 17;
            this.lblGroups.Text = "Jogosultsági csoportok";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.AccessibleDescription = "Jogosultsági csoport hozzáadása";
            this.btnAddGroup.AccessibleName = "Jogosultsági csoport hozzáadása";
            this.btnAddGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGroup.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddGroup.FlatAppearance.BorderSize = 0;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddGroup.Location = new System.Drawing.Point(223, 302);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(49, 40);
            this.btnAddGroup.TabIndex = 9;
            this.btnAddGroup.Text = ">";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.BtnAddGroup_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.AccessibleDescription = "Jogosultsági csoport eltávolítása";
            this.btnRemoveGroup.AccessibleName = "Jogosultsági csoport eltávolítása";
            this.btnRemoveGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnRemoveGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemoveGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveGroup.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveGroup.FlatAppearance.BorderSize = 0;
            this.btnRemoveGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveGroup.Location = new System.Drawing.Point(223, 348);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveGroup.TabIndex = 10;
            this.btnRemoveGroup.Text = "<";
            this.btnRemoveGroup.UseVisualStyleBackColor = false;
            this.btnRemoveGroup.Click += new System.EventHandler(this.BtnRemoveGroup_Click);
            // 
            // lsbUserGroup
            // 
            this.lsbUserGroup.AccessibleDescription = "Felhasználó jogosultsági csoportjainak listája";
            this.lsbUserGroup.AccessibleName = "Felhasználó jogosultsági csoportjainak listája";
            this.lsbUserGroup.FormattingEnabled = true;
            this.lsbUserGroup.ItemHeight = 21;
            this.lsbUserGroup.Location = new System.Drawing.Point(289, 255);
            this.lsbUserGroup.Name = "lsbUserGroup";
            this.lsbUserGroup.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbUserGroup.Size = new System.Drawing.Size(191, 172);
            this.lsbUserGroup.TabIndex = 11;
            this.lsbUserGroup.SelectedIndexChanged += new System.EventHandler(this.LsbUserGroup_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Felhasználó csoportjai";
            // 
            // txbEmail
            // 
            this.txbEmail.AccessibleDescription = "A felhasználó email címének megadása kötelező, maximum 50 karakter hosszú lehet, " +
    "és megfelelő formátumúnak kell lennie.";
            this.txbEmail.AccessibleName = "Email cím";
            this.txbEmail.Location = new System.Drawing.Point(189, 103);
            this.txbEmail.MaxLength = 50;
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(219, 27);
            this.txbEmail.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Email cím*:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Telefonszám:";
            // 
            // txbPost
            // 
            this.txbPost.AccessibleDescription = "A beosztás megadása opcionális. A szöveg hossza maximum 50 karakter lehet!";
            this.txbPost.AccessibleName = "Beosztás";
            this.txbPost.Location = new System.Drawing.Point(189, 70);
            this.txbPost.MaxLength = 50;
            this.txbPost.Name = "txbPost";
            this.txbPost.Size = new System.Drawing.Size(219, 27);
            this.txbPost.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 29;
            this.label8.Text = "Beosztás:";
            // 
            // mtbPhone
            // 
            this.mtbPhone.AccessibleDescription = "A telefonszám megadása opcionális, formátuma kötött, és maximum 9 számjegyből áll" +
    "hat!";
            this.mtbPhone.AccessibleName = "Telefonszám";
            this.mtbPhone.Location = new System.Drawing.Point(189, 137);
            this.mtbPhone.Mask = "(90) 999-9990";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(109, 27);
            this.mtbPhone.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 21);
            this.label9.TabIndex = 31;
            this.label9.Text = "Szervezeti egység:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AccessibleDescription = "A felhasználó szervezeti egységének megadása opcionális. A nyilvántartó rendszerb" +
    "en már rögzített szervezeti egységek közül lehet választani.";
            this.cmbDepartment.AccessibleName = "Szervezeti egység";
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(189, 170);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(287, 29);
            this.cmbDepartment.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(156, 430);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 101;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // FrmUserManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(496, 513);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.txbPost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsbUserGroup);
            this.Controls.Add(this.btnRemoveGroup);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.lblGroups);
            this.Controls.Add(this.lsbGroups);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chbULocked);
            this.Controls.Add(this.txbUName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbUId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Felhasználókezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbUName;
        private System.Windows.Forms.CheckBox chbULocked;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lsbGroups;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.ListBox lsbUserGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbPost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label23;
    }
}