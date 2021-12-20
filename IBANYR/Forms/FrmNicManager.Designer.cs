
namespace IBANYR
{
    partial class FrmNicManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNicManager));
            this.mtbMacAddress = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNICType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lsbIPv4 = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbIPv4Addressing = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDeleteIPv4 = new System.Windows.Forms.Button();
            this.btnAddIPv4 = new System.Windows.Forms.Button();
            this.btnEditIPv4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mtbMacAddress
            // 
            this.mtbMacAddress.AccessibleDescription = "MAC cím";
            this.mtbMacAddress.AccessibleName = "MAC cím";
            this.mtbMacAddress.Location = new System.Drawing.Point(165, 12);
            this.mtbMacAddress.Mask = "&&:&&:&&:&&:&&:&&";
            this.mtbMacAddress.Name = "mtbMacAddress";
            this.mtbMacAddress.Size = new System.Drawing.Size(144, 27);
            this.mtbMacAddress.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 21);
            this.label7.TabIndex = 28;
            this.label7.Text = "MAC cím:";
            // 
            // cmbNICType
            // 
            this.cmbNICType.AccessibleDescription = "Adapter típusa";
            this.cmbNICType.AccessibleName = "Adapter típusa";
            this.cmbNICType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNICType.FormattingEnabled = true;
            this.cmbNICType.Location = new System.Drawing.Point(165, 45);
            this.cmbNICType.Name = "cmbNICType";
            this.cmbNICType.Size = new System.Drawing.Size(177, 29);
            this.cmbNICType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 21);
            this.label5.TabIndex = 51;
            this.label5.Text = "Adapter típusa:";
            // 
            // lsbIPv4
            // 
            this.lsbIPv4.AccessibleDescription = "IPv4 címek listája";
            this.lsbIPv4.AccessibleName = "IPv4 címek listája";
            this.lsbIPv4.FormattingEnabled = true;
            this.lsbIPv4.ItemHeight = 21;
            this.lsbIPv4.Location = new System.Drawing.Point(12, 151);
            this.lsbIPv4.Name = "lsbIPv4";
            this.lsbIPv4.Size = new System.Drawing.Size(418, 109);
            this.lsbIPv4.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 21);
            this.label15.TabIndex = 88;
            this.label15.Text = "IPv4 címek:";
            // 
            // cmbIPv4Addressing
            // 
            this.cmbIPv4Addressing.AccessibleDescription = "Címkezelés típusa";
            this.cmbIPv4Addressing.AccessibleName = "Címkezelés típusa";
            this.cmbIPv4Addressing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIPv4Addressing.FormattingEnabled = true;
            this.cmbIPv4Addressing.Location = new System.Drawing.Point(165, 80);
            this.cmbIPv4Addressing.Name = "cmbIPv4Addressing";
            this.cmbIPv4Addressing.Size = new System.Drawing.Size(177, 29);
            this.cmbIPv4Addressing.TabIndex = 3;
            this.cmbIPv4Addressing.SelectedIndexChanged += new System.EventHandler(this.CmbIPv4Addressing_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 21);
            this.label2.TabIndex = 97;
            this.label2.Text = "Címkezelés típusa:";
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
            this.btnCancel.Location = new System.Drawing.Point(280, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
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
            this.btnOk.Location = new System.Drawing.Point(124, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnDeleteIPv4
            // 
            this.btnDeleteIPv4.AccessibleDescription = "IP cím beállítás törlése";
            this.btnDeleteIPv4.AccessibleName = "IP cím beállítás törlése";
            this.btnDeleteIPv4.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteIPv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteIPv4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteIPv4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteIPv4.FlatAppearance.BorderSize = 0;
            this.btnDeleteIPv4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteIPv4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteIPv4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteIPv4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteIPv4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteIPv4.Image = global::IBANYR.Properties.Resources.deleteBlue;
            this.btnDeleteIPv4.Location = new System.Drawing.Point(400, 115);
            this.btnDeleteIPv4.Name = "btnDeleteIPv4";
            this.btnDeleteIPv4.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteIPv4.TabIndex = 6;
            this.btnDeleteIPv4.UseVisualStyleBackColor = false;
            this.btnDeleteIPv4.Click += new System.EventHandler(this.BtnDeleteIPv4_Click);
            // 
            // btnAddIPv4
            // 
            this.btnAddIPv4.AccessibleDescription = "IP cím hozzáadása";
            this.btnAddIPv4.AccessibleName = "IP cím hozzáadása";
            this.btnAddIPv4.BackColor = System.Drawing.Color.Transparent;
            this.btnAddIPv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddIPv4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIPv4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddIPv4.FlatAppearance.BorderSize = 0;
            this.btnAddIPv4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddIPv4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddIPv4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIPv4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddIPv4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddIPv4.Image = global::IBANYR.Properties.Resources.addBlue;
            this.btnAddIPv4.Location = new System.Drawing.Point(364, 115);
            this.btnAddIPv4.Name = "btnAddIPv4";
            this.btnAddIPv4.Size = new System.Drawing.Size(30, 30);
            this.btnAddIPv4.TabIndex = 5;
            this.btnAddIPv4.UseVisualStyleBackColor = false;
            this.btnAddIPv4.Click += new System.EventHandler(this.BtnAddIPv4_Click);
            // 
            // btnEditIPv4
            // 
            this.btnEditIPv4.AccessibleDescription = "IP cím beállítás módosítása";
            this.btnEditIPv4.AccessibleName = "IP cím beállítás módosítása";
            this.btnEditIPv4.BackColor = System.Drawing.Color.Transparent;
            this.btnEditIPv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditIPv4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditIPv4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEditIPv4.FlatAppearance.BorderSize = 0;
            this.btnEditIPv4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditIPv4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditIPv4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditIPv4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditIPv4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditIPv4.Image = global::IBANYR.Properties.Resources.editBlue;
            this.btnEditIPv4.Location = new System.Drawing.Point(328, 115);
            this.btnEditIPv4.Name = "btnEditIPv4";
            this.btnEditIPv4.Size = new System.Drawing.Size(30, 30);
            this.btnEditIPv4.TabIndex = 4;
            this.btnEditIPv4.UseVisualStyleBackColor = false;
            this.btnEditIPv4.Click += new System.EventHandler(this.BtnEditIPv4_Click);
            // 
            // FrmNicManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbIPv4Addressing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteIPv4);
            this.Controls.Add(this.btnAddIPv4);
            this.Controls.Add(this.btnEditIPv4);
            this.Controls.Add(this.lsbIPv4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbNICType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtbMacAddress);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNicManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hálózati adapter kezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbMacAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbNICType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteIPv4;
        private System.Windows.Forms.Button btnAddIPv4;
        private System.Windows.Forms.Button btnEditIPv4;
        private System.Windows.Forms.ListBox lsbIPv4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbIPv4Addressing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}