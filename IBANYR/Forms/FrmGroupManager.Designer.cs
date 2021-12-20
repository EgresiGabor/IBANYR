
namespace IBANYR
{
    partial class FrmGroupManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnRefreshGroups = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.grbEditor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnRemovePermission = new System.Windows.Forms.Button();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.lblGroupPermissions = new System.Windows.Forms.Label();
            this.lsbGroupPermissions = new System.Windows.Forms.ListBox();
            this.lsbPermissions = new System.Windows.Forms.ListBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.rtbGDiscription = new System.Windows.Forms.RichTextBox();
            this.lblGDescription = new System.Windows.Forms.Label();
            this.txbGName = new System.Windows.Forms.TextBox();
            this.lblGName = new System.Windows.Forms.Label();
            this.dgvGroups = new IBANYR.OwnDataGridView();
            this.panel1.SuspendLayout();
            this.grbEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEditGroup);
            this.panel1.Controls.Add(this.btnRefreshGroups);
            this.panel1.Controls.Add(this.btnDeleteGroup);
            this.panel1.Controls.Add(this.btnAddGroup);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 30);
            this.panel1.TabIndex = 10;
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.AccessibleDescription = "Csoport adatainak szerkesztése";
            this.btnEditGroup.AccessibleName = "Csoport adatainak szerkesztése";
            this.btnEditGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditGroup.FlatAppearance.BorderSize = 0;
            this.btnEditGroup.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnEditGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditGroup.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditGroup.Location = new System.Drawing.Point(59, -2);
            this.btnEditGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(30, 30);
            this.btnEditGroup.TabIndex = 3;
            this.btnEditGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditGroup.UseVisualStyleBackColor = true;
            this.btnEditGroup.Click += new System.EventHandler(this.BtnEditGroup_Click);
            // 
            // btnRefreshGroups
            // 
            this.btnRefreshGroups.AccessibleDescription = "Lista frissítése";
            this.btnRefreshGroups.AccessibleName = "Lista frissítése";
            this.btnRefreshGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshGroups.FlatAppearance.BorderSize = 0;
            this.btnRefreshGroups.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshGroups.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshGroups.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshGroups.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshGroups.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshGroups.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshGroups.Location = new System.Drawing.Point(496, -2);
            this.btnRefreshGroups.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshGroups.Name = "btnRefreshGroups";
            this.btnRefreshGroups.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshGroups.TabIndex = 4;
            this.btnRefreshGroups.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshGroups.UseVisualStyleBackColor = true;
            this.btnRefreshGroups.Click += new System.EventHandler(this.BtnRefreshGroups_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.AccessibleDescription = "Csoport törlése";
            this.btnDeleteGroup.AccessibleName = "Csoport törlése";
            this.btnDeleteGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteGroup.FlatAppearance.BorderSize = 0;
            this.btnDeleteGroup.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteGroup.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteGroup.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteGroup.TabIndex = 2;
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.BtnDeleteGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.AccessibleDescription = "Új csoport rögzítése";
            this.btnAddGroup.AccessibleName = "Új csoport rögzítése";
            this.btnAddGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGroup.FlatAppearance.BorderSize = 0;
            this.btnAddGroup.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAddGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddGroup.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddGroup.Location = new System.Drawing.Point(-1, -2);
            this.btnAddGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(30, 30);
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.BtnAddGroup_Click);
            // 
            // grbEditor
            // 
            this.grbEditor.AccessibleDescription = "Jogosultsági csoport adatlapja";
            this.grbEditor.AccessibleName = "Jogosultsági csoport adatlapja";
            this.grbEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEditor.Controls.Add(this.label1);
            this.grbEditor.Controls.Add(this.btnOk);
            this.grbEditor.Controls.Add(this.btnRemovePermission);
            this.grbEditor.Controls.Add(this.btnAddPermission);
            this.grbEditor.Controls.Add(this.lblGroupPermissions);
            this.grbEditor.Controls.Add(this.lsbGroupPermissions);
            this.grbEditor.Controls.Add(this.lsbPermissions);
            this.grbEditor.Controls.Add(this.lblPermissions);
            this.grbEditor.Controls.Add(this.rtbGDiscription);
            this.grbEditor.Controls.Add(this.lblGDescription);
            this.grbEditor.Controls.Add(this.txbGName);
            this.grbEditor.Controls.Add(this.lblGName);
            this.grbEditor.Location = new System.Drawing.Point(547, 13);
            this.grbEditor.Name = "grbEditor";
            this.grbEditor.Size = new System.Drawing.Size(377, 427);
            this.grbEditor.TabIndex = 6;
            this.grbEditor.TabStop = false;
            this.grbEditor.Text = "Csoport adatlapja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "*-gal jelölt adatok megadása kötelező!";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(10, 374);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(355, 40);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnRemovePermission
            // 
            this.btnRemovePermission.AccessibleDescription = "Jogosultság eltávolítása";
            this.btnRemovePermission.AccessibleName = "Jogosultság eltávolítása";
            this.btnRemovePermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemovePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemovePermission.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemovePermission.FlatAppearance.BorderSize = 0;
            this.btnRemovePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemovePermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemovePermission.Location = new System.Drawing.Point(172, 274);
            this.btnRemovePermission.Name = "btnRemovePermission";
            this.btnRemovePermission.Size = new System.Drawing.Size(31, 40);
            this.btnRemovePermission.TabIndex = 11;
            this.btnRemovePermission.Text = "<";
            this.btnRemovePermission.UseVisualStyleBackColor = false;
            this.btnRemovePermission.Click += new System.EventHandler(this.BtnRemovePermission_Click);
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.AccessibleDescription = "Jogosultság hozzáadása";
            this.btnAddPermission.AccessibleName = "Jogosultság hozzáadása";
            this.btnAddPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPermission.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddPermission.FlatAppearance.BorderSize = 0;
            this.btnAddPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddPermission.Location = new System.Drawing.Point(172, 228);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(31, 40);
            this.btnAddPermission.TabIndex = 10;
            this.btnAddPermission.Text = ">";
            this.btnAddPermission.UseVisualStyleBackColor = false;
            this.btnAddPermission.Click += new System.EventHandler(this.BtnAddPermission_Click);
            // 
            // lblGroupPermissions
            // 
            this.lblGroupPermissions.AutoSize = true;
            this.lblGroupPermissions.Location = new System.Drawing.Point(205, 172);
            this.lblGroupPermissions.Name = "lblGroupPermissions";
            this.lblGroupPermissions.Size = new System.Drawing.Size(114, 21);
            this.lblGroupPermissions.TabIndex = 21;
            this.lblGroupPermissions.Text = "Csoportjogok";
            // 
            // lsbGroupPermissions
            // 
            this.lsbGroupPermissions.AccessibleDescription = "Csoportjogok";
            this.lsbGroupPermissions.AccessibleName = "Csoportjogok";
            this.lsbGroupPermissions.FormattingEnabled = true;
            this.lsbGroupPermissions.ItemHeight = 21;
            this.lsbGroupPermissions.Location = new System.Drawing.Point(209, 196);
            this.lsbGroupPermissions.Name = "lsbGroupPermissions";
            this.lsbGroupPermissions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbGroupPermissions.Size = new System.Drawing.Size(156, 151);
            this.lsbGroupPermissions.TabIndex = 12;
            this.lsbGroupPermissions.SelectedIndexChanged += new System.EventHandler(this.LsbGroupPermissions_SelectedIndexChanged);
            this.lsbGroupPermissions.DoubleClick += new System.EventHandler(this.LsbPermissions_DoubleClick);
            // 
            // lsbPermissions
            // 
            this.lsbPermissions.AccessibleDescription = "Jogosultságok listája";
            this.lsbPermissions.AccessibleName = "Jogosultságok listája";
            this.lsbPermissions.FormattingEnabled = true;
            this.lsbPermissions.ItemHeight = 21;
            this.lsbPermissions.Location = new System.Drawing.Point(10, 196);
            this.lsbPermissions.Name = "lsbPermissions";
            this.lsbPermissions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbPermissions.Size = new System.Drawing.Size(156, 151);
            this.lsbPermissions.TabIndex = 9;
            this.lsbPermissions.SelectedIndexChanged += new System.EventHandler(this.LsbPermissions_SelectedIndexChanged);
            this.lsbPermissions.DoubleClick += new System.EventHandler(this.LsbPermissions_DoubleClick);
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Location = new System.Drawing.Point(6, 172);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(125, 21);
            this.lblPermissions.TabIndex = 18;
            this.lblPermissions.Text = "Jogosultságok:";
            // 
            // rtbGDiscription
            // 
            this.rtbGDiscription.AccessibleDescription = "A leírás nem lehet üres, és hossza nem haladhatja meg a 4000 karaktert!";
            this.rtbGDiscription.AccessibleName = "Csoport leírása";
            this.rtbGDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbGDiscription.Location = new System.Drawing.Point(10, 93);
            this.rtbGDiscription.MaxLength = 4000;
            this.rtbGDiscription.Name = "rtbGDiscription";
            this.rtbGDiscription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.rtbGDiscription.Size = new System.Drawing.Size(355, 76);
            this.rtbGDiscription.TabIndex = 8;
            this.rtbGDiscription.Text = "";
            // 
            // lblGDescription
            // 
            this.lblGDescription.AutoSize = true;
            this.lblGDescription.Location = new System.Drawing.Point(6, 68);
            this.lblGDescription.Name = "lblGDescription";
            this.lblGDescription.Size = new System.Drawing.Size(135, 21);
            this.lblGDescription.TabIndex = 16;
            this.lblGDescription.Text = "Csoport leírása*:";
            // 
            // txbGName
            // 
            this.txbGName.AccessibleDescription = "A csoportnév megadása kötelező, valamint minimum 3 és maximum 25 karakter hosszú " +
    "lehet!";
            this.txbGName.AccessibleName = "Csoportnév";
            this.txbGName.Location = new System.Drawing.Point(118, 28);
            this.txbGName.MaxLength = 25;
            this.txbGName.Name = "txbGName";
            this.txbGName.Size = new System.Drawing.Size(247, 27);
            this.txbGName.TabIndex = 7;
            // 
            // lblGName
            // 
            this.lblGName.AutoSize = true;
            this.lblGName.Location = new System.Drawing.Point(6, 31);
            this.lblGName.Name = "lblGName";
            this.lblGName.Size = new System.Drawing.Size(112, 21);
            this.lblGName.TabIndex = 15;
            this.lblGName.Text = "Csoportnév*:";
            // 
            // dgvGroups
            // 
            this.dgvGroups.AccessibleDescription = "Jogosultsági csoportok listája";
            this.dgvGroups.AccessibleName = "Jogosultsági csoportok listája";
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(12, 41);
            this.dgvGroups.Margin = new System.Windows.Forms.Padding(0);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.ReadOnly = true;
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(529, 399);
            this.dgvGroups.TabIndex = 5;
            this.dgvGroups.SelectionChanged += new System.EventHandler(this.DgvGroups_SelectionChanged);
            // 
            // FrmGroupManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 452);
            this.Controls.Add(this.dgvGroups);
            this.Controls.Add(this.grbEditor);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGroupManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jogosultság csoport kezelő";
            this.panel1.ResumeLayout(false);
            this.grbEditor.ResumeLayout(false);
            this.grbEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnRefreshGroups;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.GroupBox grbEditor;
        private System.Windows.Forms.RichTextBox rtbGDiscription;
        private System.Windows.Forms.Label lblGDescription;
        private System.Windows.Forms.TextBox txbGName;
        private System.Windows.Forms.Label lblGName;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.ListBox lsbPermissions;
        private System.Windows.Forms.Label lblGroupPermissions;
        private System.Windows.Forms.ListBox lsbGroupPermissions;
        private System.Windows.Forms.Button btnRemovePermission;
        private System.Windows.Forms.Button btnAddPermission;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private OwnDataGridView dgvGroups;
    }
}