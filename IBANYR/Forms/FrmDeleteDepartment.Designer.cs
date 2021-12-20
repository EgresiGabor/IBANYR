
namespace IBANYR
{
    partial class FrmDeleteDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeleteDepartment));
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbUsersD = new System.Windows.Forms.ComboBox();
            this.cmbSuperiorD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AccessibleName = "";
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 92);
            this.label2.TabIndex = 13;
            this.label2.Text = "Kérem, válassza ki, hogy a törlendő szervezeti egység alá sorolt felhasználók mel" +
    "y szervezeti egységbe kerüljenek átsorolásra! Ha nem óhajtja beállítani, hagyja " +
    "üresen!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.btnOk.Location = new System.Drawing.Point(113, 277);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // cmbUsersD
            // 
            this.cmbUsersD.AccessibleDescription = "Felettes szervezeti egység beállítása felhasználók számára";
            this.cmbUsersD.AccessibleName = "Felettes szervezeti egység beállítása felhasználók számára";
            this.cmbUsersD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsersD.FormattingEnabled = true;
            this.cmbUsersD.Location = new System.Drawing.Point(12, 104);
            this.cmbUsersD.Name = "cmbUsersD";
            this.cmbUsersD.Size = new System.Drawing.Size(360, 29);
            this.cmbUsersD.TabIndex = 1;
            // 
            // cmbSuperiorD
            // 
            this.cmbSuperiorD.AccessibleDescription = "Felettes szervezeti egység beállítása szervezeti egységek számára";
            this.cmbSuperiorD.AccessibleName = "Felettes szervezeti egység beállítása szervezeti egységek számára";
            this.cmbSuperiorD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuperiorD.FormattingEnabled = true;
            this.cmbSuperiorD.Location = new System.Drawing.Point(12, 242);
            this.cmbSuperiorD.Name = "cmbSuperiorD";
            this.cmbSuperiorD.Size = new System.Drawing.Size(360, 29);
            this.cmbSuperiorD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 94);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kérem, válassza ki, hogy a törlendő szervezeti egység alá tartozó szervezeti egys" +
    "égek mely szervezeti egység alá kerüljenek átsorolásra! Ha nem óhajtja beállítan" +
    "i, hagyja üresen!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmDeleteDepartment
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 328);
            this.Controls.Add(this.cmbSuperiorD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUsersD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeleteDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szervezeti egység törlése";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbUsersD;
        private System.Windows.Forms.ComboBox cmbSuperiorD;
        private System.Windows.Forms.Label label1;
    }
}