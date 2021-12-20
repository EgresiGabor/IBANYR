
namespace IBANYR
{
    partial class ItSystemsPanel
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
            this.grbItSystemFilter = new System.Windows.Forms.GroupBox();
            this.numSecurityClass = new System.Windows.Forms.NumericUpDown();
            this.cmbDataOwnerDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLifeCycle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfItems = new System.Windows.Forms.Label();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.btnSystemPermissions = new System.Windows.Forms.Button();
            this.btnReadSystem = new System.Windows.Forms.Button();
            this.btnEditSystem = new System.Windows.Forms.Button();
            this.btnRefreshSystems = new System.Windows.Forms.Button();
            this.btnDeleteSystem = new System.Windows.Forms.Button();
            this.btnAddSystem = new System.Windows.Forms.Button();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.dgvItSystems = new IBANYR.OwnDataGridView();
            this.grbItSystemFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecurityClass)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItSystems)).BeginInit();
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
            this.btnDeleteFilter.Location = new System.Drawing.Point(900, 100);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilter.TabIndex = 8;
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
            this.btnFilter.Location = new System.Drawing.Point(764, 100);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 40);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Szűrés";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // grbItSystemFilter
            // 
            this.grbItSystemFilter.AccessibleDescription = "Rendszer szűrési feltételei";
            this.grbItSystemFilter.AccessibleName = "Rendszer szűrési feltételei";
            this.grbItSystemFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbItSystemFilter.Controls.Add(this.numSecurityClass);
            this.grbItSystemFilter.Controls.Add(this.btnDeleteFilter);
            this.grbItSystemFilter.Controls.Add(this.cmbDataOwnerDepartment);
            this.grbItSystemFilter.Controls.Add(this.btnFilter);
            this.grbItSystemFilter.Controls.Add(this.label2);
            this.grbItSystemFilter.Controls.Add(this.cmbDataType);
            this.grbItSystemFilter.Controls.Add(this.label10);
            this.grbItSystemFilter.Controls.Add(this.cmbLifeCycle);
            this.grbItSystemFilter.Controls.Add(this.label5);
            this.grbItSystemFilter.Controls.Add(this.label1);
            this.grbItSystemFilter.Controls.Add(this.txbSName);
            this.grbItSystemFilter.Controls.Add(this.label3);
            this.grbItSystemFilter.Location = new System.Drawing.Point(3, 4);
            this.grbItSystemFilter.Name = "grbItSystemFilter";
            this.grbItSystemFilter.Size = new System.Drawing.Size(1036, 149);
            this.grbItSystemFilter.TabIndex = 1;
            this.grbItSystemFilter.TabStop = false;
            this.grbItSystemFilter.Text = "Rendszerek szűrési feltételei";
            // 
            // numSecurityClass
            // 
            this.numSecurityClass.AccessibleDescription = "Biztonsági osztály szerinti szűrési paraméter. Nulla érték esetén nincs hatása a " +
    "szűrésre.";
            this.numSecurityClass.AccessibleName = "Biztonsági osztály";
            this.numSecurityClass.Location = new System.Drawing.Point(716, 63);
            this.numSecurityClass.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSecurityClass.Name = "numSecurityClass";
            this.numSecurityClass.Size = new System.Drawing.Size(114, 27);
            this.numSecurityClass.TabIndex = 5;
            // 
            // cmbDataOwnerDepartment
            // 
            this.cmbDataOwnerDepartment.AccessibleDescription = "Adatgazda szervezeti egység. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbDataOwnerDepartment.AccessibleName = "Adatgazda szervezeti egység";
            this.cmbDataOwnerDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataOwnerDepartment.FormattingEnabled = true;
            this.cmbDataOwnerDepartment.Location = new System.Drawing.Point(258, 97);
            this.cmbDataOwnerDepartment.Name = "cmbDataOwnerDepartment";
            this.cmbDataOwnerDepartment.Size = new System.Drawing.Size(498, 29);
            this.cmbDataOwnerDepartment.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 21);
            this.label2.TabIndex = 38;
            this.label2.Text = "Adatgazda szervezeti egység:";
            // 
            // cmbDataType
            // 
            this.cmbDataType.AccessibleDescription = "Tárolt adatok típusa. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbDataType.AccessibleName = "Tárolt adatok típusa";
            this.cmbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(258, 62);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(299, 29);
            this.cmbDataType.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "Tárolt adatok típusa:";
            // 
            // cmbLifeCycle
            // 
            this.cmbLifeCycle.AccessibleDescription = "Rendszer védelmi életciklusa. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbLifeCycle.AccessibleName = "Védelmi életciklus";
            this.cmbLifeCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLifeCycle.FormattingEnabled = true;
            this.cmbLifeCycle.Location = new System.Drawing.Point(716, 28);
            this.cmbLifeCycle.Name = "cmbLifeCycle";
            this.cmbLifeCycle.Size = new System.Drawing.Size(314, 29);
            this.cmbLifeCycle.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 21);
            this.label5.TabIndex = 23;
            this.label5.Text = "Biztonsági osztály:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(559, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Védelmi életciklus:";
            // 
            // txbSName
            // 
            this.txbSName.AccessibleDescription = "Rendszer neve/rövid neve részben vagy egészben. Üresen hagyva nincs hatása a szűr" +
    "ésre. Maximum 50 karakter hosszú szöveg adható meg.";
            this.txbSName.AccessibleName = "Rendszer neve";
            this.txbSName.Location = new System.Drawing.Point(258, 29);
            this.txbSName.MaxLength = 50;
            this.txbSName.Name = "txbSName";
            this.txbSName.Size = new System.Drawing.Size(299, 27);
            this.txbSName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rendszer neve:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumberOfItems);
            this.panel1.Controls.Add(this.btnExportToCsv);
            this.panel1.Controls.Add(this.btnSystemPermissions);
            this.panel1.Controls.Add(this.btnReadSystem);
            this.panel1.Controls.Add(this.btnEditSystem);
            this.panel1.Controls.Add(this.btnRefreshSystems);
            this.panel1.Controls.Add(this.btnDeleteSystem);
            this.panel1.Controls.Add(this.btnAddSystem);
            this.panel1.Location = new System.Drawing.Point(3, 159);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 30);
            this.panel1.TabIndex = 9;
            // 
            // lblNumberOfItems
            // 
            this.lblNumberOfItems.AutoSize = true;
            this.lblNumberOfItems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfItems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfItems.Location = new System.Drawing.Point(151, 4);
            this.lblNumberOfItems.Name = "lblNumberOfItems";
            this.lblNumberOfItems.Size = new System.Drawing.Size(216, 19);
            this.lblNumberOfItems.TabIndex = 22;
            this.lblNumberOfItems.Text = "Listázott rendszerek száma: ";
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.AccessibleDescription = "Rendszerek exportálása";
            this.btnExportToCsv.AccessibleName = "Rendszerek exportálása";
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
            this.btnExportToCsv.TabIndex = 14;
            this.btnExportToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.BtnExportToCsv_Click);
            // 
            // btnSystemPermissions
            // 
            this.btnSystemPermissions.AccessibleDescription = "Rendszerjogosultság kezelő megnyitása";
            this.btnSystemPermissions.AccessibleName = "Rendszerjogosultság kezelő megnyitása";
            this.btnSystemPermissions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystemPermissions.FlatAppearance.BorderSize = 0;
            this.btnSystemPermissions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSystemPermissions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSystemPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemPermissions.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSystemPermissions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSystemPermissions.Image = global::IBANYR.Properties.Resources.list;
            this.btnSystemPermissions.Location = new System.Drawing.Point(88, -2);
            this.btnSystemPermissions.Margin = new System.Windows.Forms.Padding(0);
            this.btnSystemPermissions.Name = "btnSystemPermissions";
            this.btnSystemPermissions.Size = new System.Drawing.Size(30, 30);
            this.btnSystemPermissions.TabIndex = 12;
            this.btnSystemPermissions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystemPermissions.UseVisualStyleBackColor = true;
            this.btnSystemPermissions.Click += new System.EventHandler(this.BtnSystemPermissions_Click);
            // 
            // btnReadSystem
            // 
            this.btnReadSystem.AccessibleDescription = "Rendszer adatainak megtekintése";
            this.btnReadSystem.AccessibleName = "Rendszer adatainak megtekintése";
            this.btnReadSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadSystem.FlatAppearance.BorderSize = 0;
            this.btnReadSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadSystem.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadSystem.Location = new System.Drawing.Point(118, -2);
            this.btnReadSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadSystem.Name = "btnReadSystem";
            this.btnReadSystem.Size = new System.Drawing.Size(30, 30);
            this.btnReadSystem.TabIndex = 13;
            this.btnReadSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadSystem.UseVisualStyleBackColor = true;
            this.btnReadSystem.Click += new System.EventHandler(this.BtnReadSystem_Click);
            // 
            // btnEditSystem
            // 
            this.btnEditSystem.AccessibleDescription = "Rendszer adatainak szerkesztése";
            this.btnEditSystem.AccessibleName = "Rendszer adatainak szerkesztése";
            this.btnEditSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSystem.FlatAppearance.BorderSize = 0;
            this.btnEditSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditSystem.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditSystem.Location = new System.Drawing.Point(59, -2);
            this.btnEditSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditSystem.Name = "btnEditSystem";
            this.btnEditSystem.Size = new System.Drawing.Size(30, 30);
            this.btnEditSystem.TabIndex = 11;
            this.btnEditSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditSystem.UseVisualStyleBackColor = true;
            this.btnEditSystem.Click += new System.EventHandler(this.BtnEditSystem_Click);
            // 
            // btnRefreshSystems
            // 
            this.btnRefreshSystems.AccessibleDescription = "Lista frissítése";
            this.btnRefreshSystems.AccessibleName = "Lista frissítése";
            this.btnRefreshSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSystems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshSystems.FlatAppearance.BorderSize = 0;
            this.btnRefreshSystems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshSystems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSystems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshSystems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshSystems.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshSystems.Location = new System.Drawing.Point(1003, -2);
            this.btnRefreshSystems.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshSystems.Name = "btnRefreshSystems";
            this.btnRefreshSystems.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshSystems.TabIndex = 15;
            this.btnRefreshSystems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshSystems.UseVisualStyleBackColor = true;
            this.btnRefreshSystems.Click += new System.EventHandler(this.BtnRefreshSystems_Click);
            // 
            // btnDeleteSystem
            // 
            this.btnDeleteSystem.AccessibleDescription = "Rendszer törlése";
            this.btnDeleteSystem.AccessibleName = "Rendszer törlése";
            this.btnDeleteSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSystem.FlatAppearance.BorderSize = 0;
            this.btnDeleteSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteSystem.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteSystem.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteSystem.Name = "btnDeleteSystem";
            this.btnDeleteSystem.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteSystem.TabIndex = 10;
            this.btnDeleteSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteSystem.UseVisualStyleBackColor = true;
            this.btnDeleteSystem.Click += new System.EventHandler(this.BtnDeleteSystem_Click);
            // 
            // btnAddSystem
            // 
            this.btnAddSystem.AccessibleDescription = "Új rendszer rögzítése";
            this.btnAddSystem.AccessibleName = "Új rendszer rögzítése";
            this.btnAddSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSystem.FlatAppearance.BorderSize = 0;
            this.btnAddSystem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddSystem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSystem.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddSystem.Location = new System.Drawing.Point(-1, -2);
            this.btnAddSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddSystem.Name = "btnAddSystem";
            this.btnAddSystem.Size = new System.Drawing.Size(30, 30);
            this.btnAddSystem.TabIndex = 9;
            this.btnAddSystem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSystem.UseVisualStyleBackColor = true;
            this.btnAddSystem.Click += new System.EventHandler(this.BtnAddSystem_Click);
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "rendszer_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
            // 
            // dgvItSystems
            // 
            this.dgvItSystems.AllowUserToAddRows = false;
            this.dgvItSystems.AllowUserToDeleteRows = false;
            this.dgvItSystems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItSystems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvItSystems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItSystems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItSystems.Location = new System.Drawing.Point(3, 189);
            this.dgvItSystems.Margin = new System.Windows.Forms.Padding(0);
            this.dgvItSystems.MultiSelect = false;
            this.dgvItSystems.Name = "dgvItSystems";
            this.dgvItSystems.ReadOnly = true;
            this.dgvItSystems.RowHeadersVisible = false;
            this.dgvItSystems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItSystems.Size = new System.Drawing.Size(1036, 408);
            this.dgvItSystems.TabIndex = 14;
            // 
            // ItSystemsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItSystems);
            this.Controls.Add(this.grbItSystemFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(999, 600);
            this.Name = "ItSystemsPanel";
            this.Size = new System.Drawing.Size(1043, 600);
            this.grbItSystemFilter.ResumeLayout(false);
            this.grbItSystemFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecurityClass)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItSystems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OwnDataGridView dgvItSystems;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox grbItSystemFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSystemPermissions;
        private System.Windows.Forms.Button btnReadSystem;
        private System.Windows.Forms.Button btnEditSystem;
        private System.Windows.Forms.Button btnRefreshSystems;
        private System.Windows.Forms.Button btnDeleteSystem;
        private System.Windows.Forms.Button btnAddSystem;
        private System.Windows.Forms.ComboBox cmbLifeCycle;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numSecurityClass;
        private System.Windows.Forms.ComboBox cmbDataOwnerDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
        private System.Windows.Forms.Button btnExportToCsv;
        private System.Windows.Forms.Label lblNumberOfItems;
    }
}
