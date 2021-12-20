
namespace IBANYR
{
    partial class FrmItSystemPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItSystemPermissions));
            this.lsbUsersWithPermission = new System.Windows.Forms.ListBox();
            this.lblPermissionName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReadPermission = new System.Windows.Forms.Button();
            this.btnEditPermission = new System.Windows.Forms.Button();
            this.btnRefreshPermissions = new System.Windows.Forms.Button();
            this.btnDeletePermission = new System.Windows.Forms.Button();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.trvPermissions = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbUsersWithPermission
            // 
            this.lsbUsersWithPermission.AccessibleDescription = "Jogosultsággal rendelkező felhasználók listája";
            this.lsbUsersWithPermission.AccessibleName = "Jogosultsággal rendelkező felhasználók listája";
            this.lsbUsersWithPermission.FormattingEnabled = true;
            this.lsbUsersWithPermission.ItemHeight = 21;
            this.lsbUsersWithPermission.Location = new System.Drawing.Point(499, 56);
            this.lsbUsersWithPermission.Name = "lsbUsersWithPermission";
            this.lsbUsersWithPermission.Size = new System.Drawing.Size(326, 550);
            this.lsbUsersWithPermission.TabIndex = 7;
            // 
            // lblPermissionName
            // 
            this.lblPermissionName.AutoSize = true;
            this.lblPermissionName.Location = new System.Drawing.Point(499, 21);
            this.lblPermissionName.Name = "lblPermissionName";
            this.lblPermissionName.Size = new System.Drawing.Size(314, 21);
            this.lblPermissionName.TabIndex = 43;
            this.lblPermissionName.Text = "Jogosultsággal rendelkező felhasználók";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReadPermission);
            this.panel1.Controls.Add(this.btnEditPermission);
            this.panel1.Controls.Add(this.btnRefreshPermissions);
            this.panel1.Controls.Add(this.btnDeletePermission);
            this.panel1.Controls.Add(this.btnAddPermission);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 30);
            this.panel1.TabIndex = 42;
            // 
            // btnReadPermission
            // 
            this.btnReadPermission.AccessibleDescription = "Rendszerjogosultság adatainak megtekintése";
            this.btnReadPermission.AccessibleName = "Rendszerjogosultság adatainak megtekintése";
            this.btnReadPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadPermission.FlatAppearance.BorderSize = 0;
            this.btnReadPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadPermission.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadPermission.Location = new System.Drawing.Point(89, -2);
            this.btnReadPermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadPermission.Name = "btnReadPermission";
            this.btnReadPermission.Size = new System.Drawing.Size(30, 30);
            this.btnReadPermission.TabIndex = 4;
            this.btnReadPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadPermission.UseVisualStyleBackColor = true;
            this.btnReadPermission.Click += new System.EventHandler(this.BtnReadPermission_Click);
            // 
            // btnEditPermission
            // 
            this.btnEditPermission.AccessibleDescription = "Rendszerjogosultság szerkesztése";
            this.btnEditPermission.AccessibleName = "Rendszerjogosultság szerkesztése";
            this.btnEditPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditPermission.FlatAppearance.BorderSize = 0;
            this.btnEditPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditPermission.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditPermission.Location = new System.Drawing.Point(59, -2);
            this.btnEditPermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditPermission.Name = "btnEditPermission";
            this.btnEditPermission.Size = new System.Drawing.Size(30, 30);
            this.btnEditPermission.TabIndex = 3;
            this.btnEditPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditPermission.UseVisualStyleBackColor = true;
            this.btnEditPermission.Click += new System.EventHandler(this.BtnEditPermission_Click);
            // 
            // btnRefreshPermissions
            // 
            this.btnRefreshPermissions.AccessibleDescription = "Lista frissítése";
            this.btnRefreshPermissions.AccessibleName = "Lista frissítése";
            this.btnRefreshPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshPermissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPermissions.FlatAppearance.BorderSize = 0;
            this.btnRefreshPermissions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshPermissions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPermissions.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshPermissions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshPermissions.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshPermissions.Location = new System.Drawing.Point(449, -2);
            this.btnRefreshPermissions.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshPermissions.Name = "btnRefreshPermissions";
            this.btnRefreshPermissions.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshPermissions.TabIndex = 5;
            this.btnRefreshPermissions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshPermissions.UseVisualStyleBackColor = true;
            this.btnRefreshPermissions.Click += new System.EventHandler(this.BtnRefreshPermissions_Click);
            // 
            // btnDeletePermission
            // 
            this.btnDeletePermission.AccessibleDescription = "Rendszerjogosultság törlése";
            this.btnDeletePermission.AccessibleName = "Rendszerjogosultság törlése";
            this.btnDeletePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeletePermission.FlatAppearance.BorderSize = 0;
            this.btnDeletePermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeletePermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeletePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeletePermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeletePermission.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeletePermission.Location = new System.Drawing.Point(29, -2);
            this.btnDeletePermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeletePermission.Name = "btnDeletePermission";
            this.btnDeletePermission.Size = new System.Drawing.Size(30, 30);
            this.btnDeletePermission.TabIndex = 2;
            this.btnDeletePermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletePermission.UseVisualStyleBackColor = true;
            this.btnDeletePermission.Click += new System.EventHandler(this.BtnDeletePermission_Click);
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.AccessibleDescription = "Új rendszerjogosultság rögzítése";
            this.btnAddPermission.AccessibleName = "Új rendszerjogosultság rögzítése";
            this.btnAddPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPermission.FlatAppearance.BorderSize = 0;
            this.btnAddPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddPermission.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddPermission.Location = new System.Drawing.Point(-1, -2);
            this.btnAddPermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(30, 30);
            this.btnAddPermission.TabIndex = 1;
            this.btnAddPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddPermission.UseVisualStyleBackColor = true;
            this.btnAddPermission.Click += new System.EventHandler(this.BtnAddPermission_Click);
            // 
            // trvPermissions
            // 
            this.trvPermissions.AccessibleDescription = "Rendszerjogosultságok";
            this.trvPermissions.AccessibleName = "Rendszerjogosultságok";
            this.trvPermissions.ImageIndex = 0;
            this.trvPermissions.ImageList = this.imageList;
            this.trvPermissions.Location = new System.Drawing.Point(12, 42);
            this.trvPermissions.Margin = new System.Windows.Forms.Padding(0);
            this.trvPermissions.Name = "trvPermissions";
            this.trvPermissions.SelectedImageIndex = 0;
            this.trvPermissions.ShowRootLines = false;
            this.trvPermissions.Size = new System.Drawing.Size(481, 566);
            this.trvPermissions.TabIndex = 6;
            this.trvPermissions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvPermissions_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "software_tiny_dark.png");
            // 
            // FrmItSystemPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 618);
            this.Controls.Add(this.lsbUsersWithPermission);
            this.Controls.Add(this.lblPermissionName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trvPermissions);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItSystemPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendszerjogosultságok";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbUsersWithPermission;
        private System.Windows.Forms.Label lblPermissionName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadPermission;
        private System.Windows.Forms.Button btnEditPermission;
        private System.Windows.Forms.Button btnRefreshPermissions;
        private System.Windows.Forms.Button btnDeletePermission;
        private System.Windows.Forms.Button btnAddPermission;
        private System.Windows.Forms.TreeView trvPermissions;
        private System.Windows.Forms.ImageList imageList;
    }
}