
namespace IBANYR
{
    partial class FrmDepartmentManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartmentManager));
            this.cmbSuperiorD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDShortName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbDName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSuperiorD
            // 
            this.cmbSuperiorD.AccessibleDescription = "A felettes szervezeti egység kiválasztása opcionális. A rögzített szervezeti egys" +
    "égek közül lehetséges választani.";
            this.cmbSuperiorD.AccessibleName = "Felettes szervezeti egység";
            this.cmbSuperiorD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuperiorD.FormattingEnabled = true;
            this.cmbSuperiorD.Location = new System.Drawing.Point(247, 139);
            this.cmbSuperiorD.Name = "cmbSuperiorD";
            this.cmbSuperiorD.Size = new System.Drawing.Size(360, 29);
            this.cmbSuperiorD.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 21);
            this.label4.TabIndex = 44;
            this.label4.Text = "Felettes szervezeti egység:";
            // 
            // cmbManager
            // 
            this.cmbManager.AccessibleDescription = "A vezető kiválasztása opcionális. A rögzített felhasználók közül lehetséges válas" +
    "ztani.";
            this.cmbManager.AccessibleName = "Vezető";
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.ItemHeight = 21;
            this.cmbManager.Location = new System.Drawing.Point(247, 104);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(219, 29);
            this.cmbManager.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 42;
            this.label3.Text = "Vezető:";
            // 
            // txbDShortName
            // 
            this.txbDShortName.AccessibleDescription = "A szervezeti egység rövid nevének megadása kötelező, valamint minimum 2 és maximu" +
    "m 20 karakter hosszú lehet!";
            this.txbDShortName.AccessibleName = "Szervezeti egység rövid neve";
            this.txbDShortName.Location = new System.Drawing.Point(247, 71);
            this.txbDShortName.MaxLength = 20;
            this.txbDShortName.Name = "txbDShortName";
            this.txbDShortName.Size = new System.Drawing.Size(151, 27);
            this.txbDShortName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Szervezeti egység rövid neve*:";
            // 
            // txbDName
            // 
            this.txbDName.AccessibleDescription = "A szervezeti egység nevének megadása kötelező, valamint minimum 3 és maximum 150 " +
    "karakter hosszú lehet!";
            this.txbDName.AccessibleName = "Szervezeti egység neve";
            this.txbDName.Location = new System.Drawing.Point(247, 38);
            this.txbDName.MaxLength = 150;
            this.txbDName.Name = "txbDName";
            this.txbDName.Size = new System.Drawing.Size(360, 27);
            this.txbDName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 21);
            this.label2.TabIndex = 40;
            this.label2.Text = "Szervezeti egység neve*:";
            // 
            // txbDId
            // 
            this.txbDId.AccessibleDescription = "A szervezeti egység azonosító megadása/módosítása nem lehetséges! Az adatbázissze" +
    "rver automatikusan generált értéke.";
            this.txbDId.AccessibleName = "Szervezeti egység azonosító";
            this.txbDId.Location = new System.Drawing.Point(247, 5);
            this.txbDId.Name = "txbDId";
            this.txbDId.ReadOnly = true;
            this.txbDId.Size = new System.Drawing.Size(100, 27);
            this.txbDId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Szervezeti egység azonosító:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleDescription = "Mégsem vagy bezárás";
            this.btnCancel.AccessibleName = "Mégsem vagy bezárás";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(456, 195);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleDescription = "Ok";
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(300, 195);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 21);
            this.label5.TabIndex = 45;
            this.label5.Text = "*-gal jelölt adatok megadása kötelező!";
            // 
            // FrmDepartmentManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(618, 247);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbSuperiorD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbManager);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDShortName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbDName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbDId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDepartmentManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szervezeti egység kezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSuperiorD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDShortName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbDName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label5;
    }
}