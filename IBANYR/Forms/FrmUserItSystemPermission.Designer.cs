
namespace IBANYR
{
    partial class FrmUserItSystemPermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserItSystemPermission));
            this.trvItSystemPermissions = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblPermissionDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trvItSystemPermissions
            // 
            this.trvItSystemPermissions.AccessibleDescription = "Felhasználó rendszerjogosultságainak listája";
            this.trvItSystemPermissions.AccessibleName = "Felhasználó rendszerjogosultságainak listája";
            this.trvItSystemPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvItSystemPermissions.CheckBoxes = true;
            this.trvItSystemPermissions.ImageIndex = 0;
            this.trvItSystemPermissions.ImageList = this.imageList;
            this.trvItSystemPermissions.Location = new System.Drawing.Point(14, 14);
            this.trvItSystemPermissions.Margin = new System.Windows.Forms.Padding(5);
            this.trvItSystemPermissions.Name = "trvItSystemPermissions";
            this.trvItSystemPermissions.SelectedImageIndex = 0;
            this.trvItSystemPermissions.ShowNodeToolTips = true;
            this.trvItSystemPermissions.ShowRootLines = false;
            this.trvItSystemPermissions.Size = new System.Drawing.Size(673, 355);
            this.trvItSystemPermissions.TabIndex = 1;
            this.trvItSystemPermissions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrvItSystemPermissions_AfterCheck);
            this.trvItSystemPermissions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvItSystemPermissions_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "system_tiny_dark.png");
            this.imageList.Images.SetKeyName(1, "software_tiny_dark.png");
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
            this.btnCancel.Location = new System.Drawing.Point(537, 522);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 3;
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
            this.btnOk.Location = new System.Drawing.Point(381, 522);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // rtbDescription
            // 
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Location = new System.Drawing.Point(14, 398);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(673, 118);
            this.rtbDescription.TabIndex = 0;
            this.rtbDescription.Text = "";
            // 
            // lblPermissionDescription
            // 
            this.lblPermissionDescription.AutoSize = true;
            this.lblPermissionDescription.Location = new System.Drawing.Point(12, 374);
            this.lblPermissionDescription.Name = "lblPermissionDescription";
            this.lblPermissionDescription.Size = new System.Drawing.Size(156, 21);
            this.lblPermissionDescription.TabIndex = 10;
            this.lblPermissionDescription.Text = "Jogosultság leírása";
            // 
            // FrmUserItSystemPermission
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 574);
            this.Controls.Add(this.lblPermissionDescription);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.trvItSystemPermissions);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserItSystemPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Felhasználó rendszerjogosultságai";
            this.Load += new System.EventHandler(this.FrmUserItSystemPermission_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trvItSystemPermissions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblPermissionDescription;
        private System.Windows.Forms.ImageList imageList;
    }
}