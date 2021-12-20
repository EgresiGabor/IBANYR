
namespace IBANYR
{
    partial class HardwaresPanel
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
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.grbHardwareFilter = new System.Windows.Forms.GroupBox();
            this.cmbPortable = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOwnerId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbItSystem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUId = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbAName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaintenanceLogs = new System.Windows.Forms.Button();
            this.lblNumberOfItems = new System.Windows.Forms.Label();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.btnReadHardware = new System.Windows.Forms.Button();
            this.btnEditHardware = new System.Windows.Forms.Button();
            this.btnRefreshHardwares = new System.Windows.Forms.Button();
            this.btnDeleteHardware = new System.Windows.Forms.Button();
            this.btnAddHardware = new System.Windows.Forms.Button();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.dgvHardwares = new IBANYR.OwnDataGridView();
            this.grbHardwareFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardwares)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.AccessibleDescription = "Szűrés törlése";
            this.btnDeleteFilter.AccessibleName = "Szűrés törlése";
            this.btnDeleteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnDeleteFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFilter.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteFilter.FlatAppearance.BorderSize = 0;
            this.btnDeleteFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteFilter.Location = new System.Drawing.Point(898, 125);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilter.TabIndex = 9;
            this.btnDeleteFilter.Text = "Szűrés törlése";
            this.btnDeleteFilter.UseVisualStyleBackColor = false;
            this.btnDeleteFilter.Click += new System.EventHandler(this.BtnDeleteFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleDescription = "Szűrés";
            this.btnFilter.AccessibleName = "Szűrés";
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFilter.Location = new System.Drawing.Point(762, 125);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 40);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Szűrés";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // grbHardwareFilter
            // 
            this.grbHardwareFilter.AccessibleName = "Hardverek szűrési feltételei";
            this.grbHardwareFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbHardwareFilter.Controls.Add(this.cmbPortable);
            this.grbHardwareFilter.Controls.Add(this.btnDeleteFilter);
            this.grbHardwareFilter.Controls.Add(this.label5);
            this.grbHardwareFilter.Controls.Add(this.btnFilter);
            this.grbHardwareFilter.Controls.Add(this.cmbCategory);
            this.grbHardwareFilter.Controls.Add(this.label4);
            this.grbHardwareFilter.Controls.Add(this.cmbOwnerId);
            this.grbHardwareFilter.Controls.Add(this.label1);
            this.grbHardwareFilter.Controls.Add(this.cmbItSystem);
            this.grbHardwareFilter.Controls.Add(this.label2);
            this.grbHardwareFilter.Controls.Add(this.cmbUId);
            this.grbHardwareFilter.Controls.Add(this.label10);
            this.grbHardwareFilter.Controls.Add(this.txbAName);
            this.grbHardwareFilter.Controls.Add(this.label3);
            this.grbHardwareFilter.Location = new System.Drawing.Point(3, 4);
            this.grbHardwareFilter.Name = "grbHardwareFilter";
            this.grbHardwareFilter.Size = new System.Drawing.Size(1034, 171);
            this.grbHardwareFilter.TabIndex = 1;
            this.grbHardwareFilter.TabStop = false;
            this.grbHardwareFilter.Text = "Hardverek szűrési feltételei";
            // 
            // cmbPortable
            // 
            this.cmbPortable.AccessibleDescription = "A hardver hordozatósága szerinti szűrési feltétel. Üres érték esetén nincs hatása" +
    " a szűrésre.";
            this.cmbPortable.AccessibleName = "Hordozható";
            this.cmbPortable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortable.FormattingEnabled = true;
            this.cmbPortable.Items.AddRange(new object[] {
            "",
            "Igen",
            "Nem"});
            this.cmbPortable.Location = new System.Drawing.Point(673, 64);
            this.cmbPortable.Name = "cmbPortable";
            this.cmbPortable.Size = new System.Drawing.Size(147, 29);
            this.cmbPortable.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 46;
            this.label5.Text = "Hordozható:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AccessibleDescription = "Hardver kategóriája szerinti szűrési feltétel. Üres érték esetén nincs hatása a s" +
    "zűrésre.";
            this.cmbCategory.AccessibleName = "Kategória";
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(673, 29);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(355, 29);
            this.cmbCategory.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(575, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 21);
            this.label4.TabIndex = 44;
            this.label4.Text = "Kategória:";
            // 
            // cmbOwnerId
            // 
            this.cmbOwnerId.AccessibleDescription = "Hardvert tulajdonló szervezet szerinti szűrési feltétel. Üres érték esetén nincs " +
    "hatása a szűrésre.";
            this.cmbOwnerId.AccessibleName = "Tulajdonos";
            this.cmbOwnerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwnerId.FormattingEnabled = true;
            this.cmbOwnerId.Location = new System.Drawing.Point(185, 134);
            this.cmbOwnerId.Name = "cmbOwnerId";
            this.cmbOwnerId.Size = new System.Drawing.Size(362, 29);
            this.cmbOwnerId.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "Tulajdonos:";
            // 
            // cmbItSystem
            // 
            this.cmbItSystem.AccessibleDescription = "Kapcsolódó rendszer szerinti szűrési feltétel. Üres érték esetén nincs hatása a s" +
    "zűrésre.";
            this.cmbItSystem.AccessibleName = "Kapcsolódó rendszer";
            this.cmbItSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItSystem.FormattingEnabled = true;
            this.cmbItSystem.Location = new System.Drawing.Point(185, 99);
            this.cmbItSystem.Name = "cmbItSystem";
            this.cmbItSystem.Size = new System.Drawing.Size(362, 29);
            this.cmbItSystem.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "Kapcsolódó rendszer:";
            // 
            // cmbUId
            // 
            this.cmbUId.AccessibleDescription = "Hardvert használó személy szerinti szűrési feltétel. Üres érték esetén nincs hatá" +
    "sa a szűrésre.";
            this.cmbUId.AccessibleName = "Használó";
            this.cmbUId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUId.FormattingEnabled = true;
            this.cmbUId.Location = new System.Drawing.Point(185, 64);
            this.cmbUId.Name = "cmbUId";
            this.cmbUId.Size = new System.Drawing.Size(362, 29);
            this.cmbUId.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "Használó:";
            // 
            // txbAName
            // 
            this.txbAName.AccessibleDescription = "Hardver neve részben vagy egészben. Üresen hagyva nincs hatása a szűrésre. Maximu" +
    "m 50 karakter hosszú szöveg adható meg.";
            this.txbAName.AccessibleName = "Hardver neve";
            this.txbAName.Location = new System.Drawing.Point(185, 29);
            this.txbAName.MaxLength = 50;
            this.txbAName.Name = "txbAName";
            this.txbAName.Size = new System.Drawing.Size(362, 27);
            this.txbAName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hardver neve:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMaintenanceLogs);
            this.panel1.Controls.Add(this.lblNumberOfItems);
            this.panel1.Controls.Add(this.btnExportToCsv);
            this.panel1.Controls.Add(this.btnReadHardware);
            this.panel1.Controls.Add(this.btnEditHardware);
            this.panel1.Controls.Add(this.btnRefreshHardwares);
            this.panel1.Controls.Add(this.btnDeleteHardware);
            this.panel1.Controls.Add(this.btnAddHardware);
            this.panel1.Location = new System.Drawing.Point(3, 181);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 30);
            this.panel1.TabIndex = 15;
            // 
            // btnMaintenanceLogs
            // 
            this.btnMaintenanceLogs.AccessibleDescription = "Hardver karbantartási bejegyzései";
            this.btnMaintenanceLogs.AccessibleName = "Hardver karbantartási bejegyzései";
            this.btnMaintenanceLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenanceLogs.FlatAppearance.BorderSize = 0;
            this.btnMaintenanceLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenanceLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenanceLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenanceLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMaintenanceLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMaintenanceLogs.Image = global::IBANYR.Properties.Resources.maintenance_tiny;
            this.btnMaintenanceLogs.Location = new System.Drawing.Point(119, -2);
            this.btnMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaintenanceLogs.Name = "btnMaintenanceLogs";
            this.btnMaintenanceLogs.Size = new System.Drawing.Size(30, 30);
            this.btnMaintenanceLogs.TabIndex = 14;
            this.btnMaintenanceLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaintenanceLogs.UseVisualStyleBackColor = true;
            this.btnMaintenanceLogs.Click += new System.EventHandler(this.BtnMaintenanceLogs_Click);
            // 
            // lblNumberOfItems
            // 
            this.lblNumberOfItems.AutoSize = true;
            this.lblNumberOfItems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfItems.Location = new System.Drawing.Point(152, 4);
            this.lblNumberOfItems.Name = "lblNumberOfItems";
            this.lblNumberOfItems.Size = new System.Drawing.Size(213, 19);
            this.lblNumberOfItems.TabIndex = 21;
            this.lblNumberOfItems.Text = "Listázott hardverek száma: ";
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.AccessibleDescription = "Hardverek exportálása";
            this.btnExportToCsv.AccessibleName = "Hardverek exportálása";
            this.btnExportToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportToCsv.FlatAppearance.BorderSize = 0;
            this.btnExportToCsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExportToCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportToCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportToCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToCsv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExportToCsv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportToCsv.Image = global::IBANYR.Properties.Resources.excel;
            this.btnExportToCsv.Location = new System.Drawing.Point(973, -2);
            this.btnExportToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(30, 30);
            this.btnExportToCsv.TabIndex = 15;
            this.btnExportToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.BtnExportToCsv_Click);
            // 
            // btnReadHardware
            // 
            this.btnReadHardware.AccessibleDescription = "Hardver adatainak megtekintése";
            this.btnReadHardware.AccessibleName = "Hardver adatainak megtekintése";
            this.btnReadHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadHardware.FlatAppearance.BorderSize = 0;
            this.btnReadHardware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadHardware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadHardware.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadHardware.Location = new System.Drawing.Point(89, -2);
            this.btnReadHardware.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadHardware.Name = "btnReadHardware";
            this.btnReadHardware.Size = new System.Drawing.Size(30, 30);
            this.btnReadHardware.TabIndex = 13;
            this.btnReadHardware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadHardware.UseVisualStyleBackColor = true;
            this.btnReadHardware.Click += new System.EventHandler(this.BtnReadHardware_Click);
            // 
            // btnEditHardware
            // 
            this.btnEditHardware.AccessibleDescription = "Hardver adatainak szerkesztése";
            this.btnEditHardware.AccessibleName = "Hardver adatainak szerkesztése";
            this.btnEditHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditHardware.FlatAppearance.BorderSize = 0;
            this.btnEditHardware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditHardware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditHardware.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditHardware.Location = new System.Drawing.Point(59, -2);
            this.btnEditHardware.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditHardware.Name = "btnEditHardware";
            this.btnEditHardware.Size = new System.Drawing.Size(30, 30);
            this.btnEditHardware.TabIndex = 12;
            this.btnEditHardware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditHardware.UseVisualStyleBackColor = true;
            this.btnEditHardware.Click += new System.EventHandler(this.BtnEditHardware_Click);
            // 
            // btnRefreshHardwares
            // 
            this.btnRefreshHardwares.AccessibleDescription = "Lista frissítése";
            this.btnRefreshHardwares.AccessibleName = "Lista frissítése";
            this.btnRefreshHardwares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHardwares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshHardwares.FlatAppearance.BorderSize = 0;
            this.btnRefreshHardwares.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshHardwares.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshHardwares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshHardwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshHardwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshHardwares.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshHardwares.Location = new System.Drawing.Point(1003, -2);
            this.btnRefreshHardwares.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshHardwares.Name = "btnRefreshHardwares";
            this.btnRefreshHardwares.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshHardwares.TabIndex = 16;
            this.btnRefreshHardwares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshHardwares.UseVisualStyleBackColor = true;
            this.btnRefreshHardwares.Click += new System.EventHandler(this.BtnRefreshHardwares_Click);
            // 
            // btnDeleteHardware
            // 
            this.btnDeleteHardware.AccessibleDescription = "Hardver törlése";
            this.btnDeleteHardware.AccessibleName = "Hardver törlése";
            this.btnDeleteHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteHardware.FlatAppearance.BorderSize = 0;
            this.btnDeleteHardware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteHardware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteHardware.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteHardware.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteHardware.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteHardware.Name = "btnDeleteHardware";
            this.btnDeleteHardware.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteHardware.TabIndex = 11;
            this.btnDeleteHardware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteHardware.UseVisualStyleBackColor = true;
            this.btnDeleteHardware.Click += new System.EventHandler(this.BtnDeleteHardware_Click);
            // 
            // btnAddHardware
            // 
            this.btnAddHardware.AccessibleDescription = "Új hardver rögzítése";
            this.btnAddHardware.AccessibleName = "Új hardver rögzítése";
            this.btnAddHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHardware.FlatAppearance.BorderSize = 0;
            this.btnAddHardware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddHardware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddHardware.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddHardware.Location = new System.Drawing.Point(-1, -2);
            this.btnAddHardware.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddHardware.Name = "btnAddHardware";
            this.btnAddHardware.Size = new System.Drawing.Size(30, 30);
            this.btnAddHardware.TabIndex = 10;
            this.btnAddHardware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddHardware.UseVisualStyleBackColor = true;
            this.btnAddHardware.Click += new System.EventHandler(this.BtnAddHardware_Click);
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "hardver_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
            // 
            // dgvHardwares
            // 
            this.dgvHardwares.AllowUserToAddRows = false;
            this.dgvHardwares.AllowUserToDeleteRows = false;
            this.dgvHardwares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHardwares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHardwares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHardwares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHardwares.Location = new System.Drawing.Point(3, 211);
            this.dgvHardwares.Margin = new System.Windows.Forms.Padding(0);
            this.dgvHardwares.MultiSelect = false;
            this.dgvHardwares.Name = "dgvHardwares";
            this.dgvHardwares.ReadOnly = true;
            this.dgvHardwares.RowHeadersVisible = false;
            this.dgvHardwares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHardwares.Size = new System.Drawing.Size(1036, 389);
            this.dgvHardwares.TabIndex = 17;
            // 
            // HardwaresPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHardwares);
            this.Controls.Add(this.grbHardwareFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(999, 600);
            this.Name = "HardwaresPanel";
            this.Size = new System.Drawing.Size(1043, 600);
            this.grbHardwareFilter.ResumeLayout(false);
            this.grbHardwareFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardwares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OwnDataGridView dgvHardwares;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox grbHardwareFilter;
        private System.Windows.Forms.ComboBox cmbItSystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbAName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReadHardware;
        private System.Windows.Forms.Button btnEditHardware;
        private System.Windows.Forms.Button btnRefreshHardwares;
        private System.Windows.Forms.Button btnDeleteHardware;
        private System.Windows.Forms.Button btnAddHardware;
        private System.Windows.Forms.ComboBox cmbOwnerId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPortable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExportToCsv;
        private System.Windows.Forms.Label lblNumberOfItems;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
        private System.Windows.Forms.Button btnMaintenanceLogs;
    }
}
