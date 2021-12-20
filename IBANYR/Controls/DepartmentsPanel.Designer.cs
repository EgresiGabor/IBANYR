
namespace IBANYR
{
    partial class DepartmentsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentsPanel));
            this.trvDepartments = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReadDepartment = new System.Windows.Forms.Button();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnRefreshDepartments = new System.Windows.Forms.Button();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lsbDepartmentUsers = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvDepartments
            // 
            this.trvDepartments.AccessibleDescription = "Szervezeti egységek fastruktúrája";
            this.trvDepartments.AccessibleName = "Szervezeti egységek fastruktúrája";
            this.trvDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvDepartments.ImageIndex = 0;
            this.trvDepartments.ImageList = this.imageList;
            this.trvDepartments.Location = new System.Drawing.Point(3, 33);
            this.trvDepartments.Margin = new System.Windows.Forms.Padding(0);
            this.trvDepartments.Name = "trvDepartments";
            this.trvDepartments.SelectedImageIndex = 0;
            this.trvDepartments.ShowRootLines = false;
            this.trvDepartments.Size = new System.Drawing.Size(488, 564);
            this.trvDepartments.TabIndex = 6;
            this.trvDepartments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvDepartments_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "company_tiny_dark.png");
            this.imageList.Images.SetKeyName(1, "users_tiny_dark.png");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnReadDepartment);
            this.panel1.Controls.Add(this.btnEditDepartment);
            this.panel1.Controls.Add(this.btnRefreshDepartments);
            this.panel1.Controls.Add(this.btnDeleteDepartment);
            this.panel1.Controls.Add(this.btnAddDepartment);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 30);
            this.panel1.TabIndex = 38;
            // 
            // btnReadDepartment
            // 
            this.btnReadDepartment.AccessibleDescription = "Szervezeti egység adatainak megtekintése";
            this.btnReadDepartment.AccessibleName = "Szervezeti egység adatainak megtekintése";
            this.btnReadDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadDepartment.FlatAppearance.BorderSize = 0;
            this.btnReadDepartment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadDepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadDepartment.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadDepartment.Location = new System.Drawing.Point(89, -2);
            this.btnReadDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadDepartment.Name = "btnReadDepartment";
            this.btnReadDepartment.Size = new System.Drawing.Size(30, 30);
            this.btnReadDepartment.TabIndex = 4;
            this.btnReadDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadDepartment.UseVisualStyleBackColor = true;
            this.btnReadDepartment.Click += new System.EventHandler(this.BtnReadDepartment_Click);
            // 
            // btnEditDepartment
            // 
            this.btnEditDepartment.AccessibleDescription = "Szervezeti egység adatainak szerkesztése";
            this.btnEditDepartment.AccessibleName = "Szervezeti egység adatainak szerkesztése";
            this.btnEditDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditDepartment.FlatAppearance.BorderSize = 0;
            this.btnEditDepartment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditDepartment.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditDepartment.Location = new System.Drawing.Point(59, -2);
            this.btnEditDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(30, 30);
            this.btnEditDepartment.TabIndex = 3;
            this.btnEditDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.BtnEditDepartment_Click);
            // 
            // btnRefreshDepartments
            // 
            this.btnRefreshDepartments.AccessibleDescription = "Lista frissítése";
            this.btnRefreshDepartments.AccessibleName = "Lista frissítése";
            this.btnRefreshDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshDepartments.FlatAppearance.BorderSize = 0;
            this.btnRefreshDepartments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshDepartments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDepartments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshDepartments.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshDepartments.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshDepartments.Location = new System.Drawing.Point(456, -2);
            this.btnRefreshDepartments.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshDepartments.Name = "btnRefreshDepartments";
            this.btnRefreshDepartments.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshDepartments.TabIndex = 5;
            this.btnRefreshDepartments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshDepartments.UseVisualStyleBackColor = true;
            this.btnRefreshDepartments.Click += new System.EventHandler(this.BtnRefreshDepartments_Click);
            // 
            // btnDeleteDepartment
            // 
            this.btnDeleteDepartment.AccessibleDescription = "Szervezeti egység törlése";
            this.btnDeleteDepartment.AccessibleName = "Szervezeti egység törlése";
            this.btnDeleteDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteDepartment.FlatAppearance.BorderSize = 0;
            this.btnDeleteDepartment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteDepartment.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteDepartment.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteDepartment.TabIndex = 2;
            this.btnDeleteDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.BtnDeleteDepartment_Click);
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.AccessibleDescription = "Új szervezeti egység rögzítése";
            this.btnAddDepartment.AccessibleName = "Új szervezeti egység rögzítése";
            this.btnAddDepartment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDepartment.FlatAppearance.BorderSize = 0;
            this.btnAddDepartment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddDepartment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddDepartment.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddDepartment.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddDepartment.Location = new System.Drawing.Point(-1, -2);
            this.btnAddDepartment.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(30, 30);
            this.btnAddDepartment.TabIndex = 1;
            this.btnAddDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.BtnAddDepartment_Click);
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Location = new System.Drawing.Point(497, 12);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(240, 21);
            this.lblDepartmentName.TabIndex = 39;
            this.lblDepartmentName.Text = "Szervezeti egység felhasználói";
            // 
            // lsbDepartmentUsers
            // 
            this.lsbDepartmentUsers.AccessibleDescription = "Szervezeti egység felhasználói";
            this.lsbDepartmentUsers.AccessibleName = "Szervezeti egység felhasználói";
            this.lsbDepartmentUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbDepartmentUsers.FormattingEnabled = true;
            this.lsbDepartmentUsers.ItemHeight = 21;
            this.lsbDepartmentUsers.Location = new System.Drawing.Point(497, 47);
            this.lsbDepartmentUsers.Name = "lsbDepartmentUsers";
            this.lsbDepartmentUsers.Size = new System.Drawing.Size(326, 550);
            this.lsbDepartmentUsers.TabIndex = 7;
            // 
            // DepartmentsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lsbDepartmentUsers);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trvDepartments);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(830, 600);
            this.Name = "DepartmentsPanel";
            this.Size = new System.Drawing.Size(830, 600);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView trvDepartments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnRefreshDepartments;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Label lblDepartmentName;
        private System.Windows.Forms.ListBox lsbDepartmentUsers;
        private System.Windows.Forms.ImageList imageList;
    }
}
