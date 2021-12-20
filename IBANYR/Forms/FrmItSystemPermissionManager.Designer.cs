
namespace IBANYR
{
    partial class FrmItSystemPermissionManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItSystemPermissionManager));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbSuperiorSysPermission = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbSysPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSysPId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbSysPDescription = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnCancel.Location = new System.Drawing.Point(457, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 6;
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
            this.btnOk.Location = new System.Drawing.Point(301, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // cmbSuperiorSysPermission
            // 
            this.cmbSuperiorSysPermission.AccessibleDescription = "A felettes rendszerjog kiválasztása opcionális. Az informatikai rendszerhez már r" +
    "ögzített rendszerjogok közül lehet választani.";
            this.cmbSuperiorSysPermission.AccessibleName = "Felettes rendszerjog";
            this.cmbSuperiorSysPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuperiorSysPermission.FormattingEnabled = true;
            this.cmbSuperiorSysPermission.Location = new System.Drawing.Point(267, 174);
            this.cmbSuperiorSysPermission.Name = "cmbSuperiorSysPermission";
            this.cmbSuperiorSysPermission.Size = new System.Drawing.Size(341, 29);
            this.cmbSuperiorSysPermission.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 21);
            this.label4.TabIndex = 56;
            this.label4.Text = "Felettes rendszerjog:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 21);
            this.label6.TabIndex = 53;
            this.label6.Text = "Jogosultság leírása:";
            // 
            // txbSysPName
            // 
            this.txbSysPName.AccessibleDescription = "Kötelezően megadandó érték, és maximum 50 karakter hosszú lehet.";
            this.txbSysPName.AccessibleName = "Rendszerjogosultság neve";
            this.txbSysPName.Location = new System.Drawing.Point(267, 39);
            this.txbSysPName.MaxLength = 50;
            this.txbSysPName.Name = "txbSysPName";
            this.txbSysPName.Size = new System.Drawing.Size(340, 27);
            this.txbSysPName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 21);
            this.label2.TabIndex = 52;
            this.label2.Text = "Rendszerjogosultság neve*:";
            // 
            // txbSysPId
            // 
            this.txbSysPId.AccessibleName = "Rendszerjogosultság azonosító";
            this.txbSysPId.Location = new System.Drawing.Point(267, 6);
            this.txbSysPId.Name = "txbSysPId";
            this.txbSysPId.ReadOnly = true;
            this.txbSysPId.Size = new System.Drawing.Size(100, 27);
            this.txbSysPId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 21);
            this.label1.TabIndex = 51;
            this.label1.Text = "Rendszerjogosultság azonosító:";
            // 
            // rtbSysPDescription
            // 
            this.rtbSysPDescription.AccessibleDescription = "Opcionálisan megadható és maximum 4000 karakter hosszú lehet.";
            this.rtbSysPDescription.AccessibleName = "Jogosultság leírása";
            this.rtbSysPDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSysPDescription.Location = new System.Drawing.Point(267, 72);
            this.rtbSysPDescription.MaxLength = 4000;
            this.rtbSysPDescription.Name = "rtbSysPDescription";
            this.rtbSysPDescription.Size = new System.Drawing.Size(340, 96);
            this.rtbSysPDescription.TabIndex = 3;
            this.rtbSysPDescription.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(284, 206);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 101;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // FrmItSystemPermissionManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(618, 288);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.rtbSysPDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbSuperiorSysPermission);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbSysPName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbSysPId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItSystemPermissionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendszerjogosultság kezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbSuperiorSysPermission;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbSysPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSysPId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbSysPDescription;
        private System.Windows.Forms.Label label23;
    }
}