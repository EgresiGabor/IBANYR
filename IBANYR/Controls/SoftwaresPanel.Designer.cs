
namespace IBANYR
{
    partial class SoftwaresPanel
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
            this.btnDeleteFilterSoftware = new System.Windows.Forms.Button();
            this.btnFilterSoftware = new System.Windows.Forms.Button();
            this.grbSoftwareFilter = new System.Windows.Forms.GroupBox();
            this.cmbSoftwareOwnerId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNetworkDeviceId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSoftwareItSystem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSoftwareProducer = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbSoftAName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfSoftwares = new System.Windows.Forms.Label();
            this.btnExportSoftwaresToCsv = new System.Windows.Forms.Button();
            this.btnReadSoftware = new System.Windows.Forms.Button();
            this.btnEditSoftware = new System.Windows.Forms.Button();
            this.btnRefreshSoftwares = new System.Windows.Forms.Button();
            this.btnDeleteSoftware = new System.Windows.Forms.Button();
            this.btnAddSoftware = new System.Windows.Forms.Button();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.dgvSoftwares = new IBANYR.OwnDataGridView();
            this.grbSoftwareFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftwares)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteFilterSoftware
            // 
            this.btnDeleteFilterSoftware.AccessibleDescription = "Szűrés törlése";
            this.btnDeleteFilterSoftware.AccessibleName = "Szűrés törlése";
            this.btnDeleteFilterSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFilterSoftware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnDeleteFilterSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFilterSoftware.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteFilterSoftware.FlatAppearance.BorderSize = 0;
            this.btnDeleteFilterSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilterSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteFilterSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteFilterSoftware.Location = new System.Drawing.Point(898, 125);
            this.btnDeleteFilterSoftware.Name = "btnDeleteFilterSoftware";
            this.btnDeleteFilterSoftware.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilterSoftware.TabIndex = 8;
            this.btnDeleteFilterSoftware.Text = "Szűrés törlése";
            this.btnDeleteFilterSoftware.UseVisualStyleBackColor = false;
            this.btnDeleteFilterSoftware.Click += new System.EventHandler(this.BtnDeleteFilterSoftware_Click);
            // 
            // btnFilterSoftware
            // 
            this.btnFilterSoftware.AccessibleDescription = "Szűrés";
            this.btnFilterSoftware.AccessibleName = "Szűrés";
            this.btnFilterSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterSoftware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnFilterSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterSoftware.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilterSoftware.FlatAppearance.BorderSize = 0;
            this.btnFilterSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFilterSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFilterSoftware.Location = new System.Drawing.Point(762, 125);
            this.btnFilterSoftware.Name = "btnFilterSoftware";
            this.btnFilterSoftware.Size = new System.Drawing.Size(130, 40);
            this.btnFilterSoftware.TabIndex = 7;
            this.btnFilterSoftware.Text = "Szűrés";
            this.btnFilterSoftware.UseVisualStyleBackColor = false;
            this.btnFilterSoftware.Click += new System.EventHandler(this.BtnFilterSoftware_Click);
            // 
            // grbSoftwareFilter
            // 
            this.grbSoftwareFilter.AccessibleDescription = "Szoftverek szűrési feltételei";
            this.grbSoftwareFilter.AccessibleName = "Szoftverek szűrési feltételei";
            this.grbSoftwareFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSoftwareFilter.Controls.Add(this.cmbSoftwareOwnerId);
            this.grbSoftwareFilter.Controls.Add(this.btnDeleteFilterSoftware);
            this.grbSoftwareFilter.Controls.Add(this.label4);
            this.grbSoftwareFilter.Controls.Add(this.btnFilterSoftware);
            this.grbSoftwareFilter.Controls.Add(this.cmbNetworkDeviceId);
            this.grbSoftwareFilter.Controls.Add(this.label1);
            this.grbSoftwareFilter.Controls.Add(this.cmbSoftwareItSystem);
            this.grbSoftwareFilter.Controls.Add(this.label2);
            this.grbSoftwareFilter.Controls.Add(this.cmbSoftwareProducer);
            this.grbSoftwareFilter.Controls.Add(this.label10);
            this.grbSoftwareFilter.Controls.Add(this.txbSoftAName);
            this.grbSoftwareFilter.Controls.Add(this.label3);
            this.grbSoftwareFilter.Location = new System.Drawing.Point(3, 2);
            this.grbSoftwareFilter.Name = "grbSoftwareFilter";
            this.grbSoftwareFilter.Size = new System.Drawing.Size(1034, 171);
            this.grbSoftwareFilter.TabIndex = 1;
            this.grbSoftwareFilter.TabStop = false;
            this.grbSoftwareFilter.Text = "Szoftverek szűrési feltételei";
            // 
            // cmbSoftwareOwnerId
            // 
            this.cmbSoftwareOwnerId.AccessibleDescription = "Szoftvert tulajdonló szervezet. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbSoftwareOwnerId.AccessibleName = "Tulajdonos";
            this.cmbSoftwareOwnerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftwareOwnerId.FormattingEnabled = true;
            this.cmbSoftwareOwnerId.Location = new System.Drawing.Point(185, 64);
            this.cmbSoftwareOwnerId.Name = "cmbSoftwareOwnerId";
            this.cmbSoftwareOwnerId.Size = new System.Drawing.Size(415, 29);
            this.cmbSoftwareOwnerId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 21);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tulajdonos:";
            // 
            // cmbNetworkDeviceId
            // 
            this.cmbNetworkDeviceId.AccessibleDescription = "Kapcsolódó számítógép eszköz. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbNetworkDeviceId.AccessibleName = "Kapcsolódó hardver";
            this.cmbNetworkDeviceId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetworkDeviceId.FormattingEnabled = true;
            this.cmbNetworkDeviceId.Location = new System.Drawing.Point(185, 134);
            this.cmbNetworkDeviceId.Name = "cmbNetworkDeviceId";
            this.cmbNetworkDeviceId.Size = new System.Drawing.Size(415, 29);
            this.cmbNetworkDeviceId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "Kapcsolódó hardver:";
            // 
            // cmbSoftwareItSystem
            // 
            this.cmbSoftwareItSystem.AccessibleDescription = "Kapcsolódó rendszer. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbSoftwareItSystem.AccessibleName = "Kapcsolódó rendszer";
            this.cmbSoftwareItSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftwareItSystem.FormattingEnabled = true;
            this.cmbSoftwareItSystem.Location = new System.Drawing.Point(185, 99);
            this.cmbSoftwareItSystem.Name = "cmbSoftwareItSystem";
            this.cmbSoftwareItSystem.Size = new System.Drawing.Size(415, 29);
            this.cmbSoftwareItSystem.TabIndex = 5;
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
            // cmbSoftwareProducer
            // 
            this.cmbSoftwareProducer.AccessibleDescription = "Szoftver gyártója. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbSoftwareProducer.AccessibleName = "Gyártó";
            this.cmbSoftwareProducer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftwareProducer.FormattingEnabled = true;
            this.cmbSoftwareProducer.Location = new System.Drawing.Point(678, 29);
            this.cmbSoftwareProducer.Name = "cmbSoftwareProducer";
            this.cmbSoftwareProducer.Size = new System.Drawing.Size(350, 29);
            this.cmbSoftwareProducer.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(603, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 21);
            this.label10.TabIndex = 37;
            this.label10.Text = "Gyártó:";
            // 
            // txbSoftAName
            // 
            this.txbSoftAName.AccessibleDescription = "Szoftver neve részben vagy egészben. Üresen hagyva nincs hatása a szűrésre. Maxim" +
    "um 50 karakter hosszú szöveg adható meg.";
            this.txbSoftAName.AccessibleName = "Szoftver neve";
            this.txbSoftAName.Location = new System.Drawing.Point(185, 29);
            this.txbSoftAName.MaxLength = 50;
            this.txbSoftAName.Name = "txbSoftAName";
            this.txbSoftAName.Size = new System.Drawing.Size(219, 27);
            this.txbSoftAName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Szoftver neve:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumberOfSoftwares);
            this.panel1.Controls.Add(this.btnExportSoftwaresToCsv);
            this.panel1.Controls.Add(this.btnReadSoftware);
            this.panel1.Controls.Add(this.btnEditSoftware);
            this.panel1.Controls.Add(this.btnRefreshSoftwares);
            this.panel1.Controls.Add(this.btnDeleteSoftware);
            this.panel1.Controls.Add(this.btnAddSoftware);
            this.panel1.Location = new System.Drawing.Point(3, 179);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 30);
            this.panel1.TabIndex = 20;
            // 
            // lblNumberOfSoftwares
            // 
            this.lblNumberOfSoftwares.AutoSize = true;
            this.lblNumberOfSoftwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfSoftwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfSoftwares.Location = new System.Drawing.Point(122, 4);
            this.lblNumberOfSoftwares.Name = "lblNumberOfSoftwares";
            this.lblNumberOfSoftwares.Size = new System.Drawing.Size(207, 19);
            this.lblNumberOfSoftwares.TabIndex = 21;
            this.lblNumberOfSoftwares.Text = "Listázott szoftverek száma: ";
            // 
            // btnExportSoftwaresToCsv
            // 
            this.btnExportSoftwaresToCsv.AccessibleDescription = "Szoftverek exportálása";
            this.btnExportSoftwaresToCsv.AccessibleName = "Szoftverek exportálása";
            this.btnExportSoftwaresToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSoftwaresToCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportSoftwaresToCsv.FlatAppearance.BorderSize = 0;
            this.btnExportSoftwaresToCsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExportSoftwaresToCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportSoftwaresToCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportSoftwaresToCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSoftwaresToCsv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExportSoftwaresToCsv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportSoftwaresToCsv.Image = global::IBANYR.Properties.Resources.excel;
            this.btnExportSoftwaresToCsv.Location = new System.Drawing.Point(973, -2);
            this.btnExportSoftwaresToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportSoftwaresToCsv.Name = "btnExportSoftwaresToCsv";
            this.btnExportSoftwaresToCsv.Size = new System.Drawing.Size(30, 30);
            this.btnExportSoftwaresToCsv.TabIndex = 13;
            this.btnExportSoftwaresToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSoftwaresToCsv.UseVisualStyleBackColor = true;
            this.btnExportSoftwaresToCsv.Click += new System.EventHandler(this.BtnExportSoftwaresToCsv_Click);
            // 
            // btnReadSoftware
            // 
            this.btnReadSoftware.AccessibleDescription = "Szoftver adatainak megtekintése";
            this.btnReadSoftware.AccessibleName = "Szoftver adatainak megtekintése";
            this.btnReadSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadSoftware.FlatAppearance.BorderSize = 0;
            this.btnReadSoftware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadSoftware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadSoftware.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadSoftware.Location = new System.Drawing.Point(89, -2);
            this.btnReadSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadSoftware.Name = "btnReadSoftware";
            this.btnReadSoftware.Size = new System.Drawing.Size(30, 30);
            this.btnReadSoftware.TabIndex = 12;
            this.btnReadSoftware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadSoftware.UseVisualStyleBackColor = true;
            this.btnReadSoftware.Click += new System.EventHandler(this.BtnReadSoftware_Click);
            // 
            // btnEditSoftware
            // 
            this.btnEditSoftware.AccessibleDescription = "Szoftver adatainak szerkesztése";
            this.btnEditSoftware.AccessibleName = "Szoftver adatainak szerkesztése";
            this.btnEditSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSoftware.FlatAppearance.BorderSize = 0;
            this.btnEditSoftware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditSoftware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditSoftware.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditSoftware.Location = new System.Drawing.Point(59, -2);
            this.btnEditSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditSoftware.Name = "btnEditSoftware";
            this.btnEditSoftware.Size = new System.Drawing.Size(30, 30);
            this.btnEditSoftware.TabIndex = 11;
            this.btnEditSoftware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditSoftware.UseVisualStyleBackColor = true;
            this.btnEditSoftware.Click += new System.EventHandler(this.BtnEditSoftware_Click);
            // 
            // btnRefreshSoftwares
            // 
            this.btnRefreshSoftwares.AccessibleDescription = "Lista frissítése";
            this.btnRefreshSoftwares.AccessibleName = "Lista frissítése";
            this.btnRefreshSoftwares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSoftwares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshSoftwares.FlatAppearance.BorderSize = 0;
            this.btnRefreshSoftwares.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshSoftwares.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshSoftwares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSoftwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshSoftwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshSoftwares.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshSoftwares.Location = new System.Drawing.Point(1003, -2);
            this.btnRefreshSoftwares.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshSoftwares.Name = "btnRefreshSoftwares";
            this.btnRefreshSoftwares.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshSoftwares.TabIndex = 14;
            this.btnRefreshSoftwares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshSoftwares.UseVisualStyleBackColor = true;
            this.btnRefreshSoftwares.Click += new System.EventHandler(this.BtnRefreshSoftwares_Click);
            // 
            // btnDeleteSoftware
            // 
            this.btnDeleteSoftware.AccessibleDescription = "Szoftver törlése";
            this.btnDeleteSoftware.AccessibleName = "Szoftver törlése";
            this.btnDeleteSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSoftware.FlatAppearance.BorderSize = 0;
            this.btnDeleteSoftware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSoftware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteSoftware.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteSoftware.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteSoftware.Name = "btnDeleteSoftware";
            this.btnDeleteSoftware.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteSoftware.TabIndex = 10;
            this.btnDeleteSoftware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteSoftware.UseVisualStyleBackColor = true;
            this.btnDeleteSoftware.Click += new System.EventHandler(this.BtnDeleteSoftware_Click);
            // 
            // btnAddSoftware
            // 
            this.btnAddSoftware.AccessibleDescription = "Új szoftver rögzítése";
            this.btnAddSoftware.AccessibleName = "Új szoftver rögzítése";
            this.btnAddSoftware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSoftware.FlatAppearance.BorderSize = 0;
            this.btnAddSoftware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddSoftware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSoftware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddSoftware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSoftware.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddSoftware.Location = new System.Drawing.Point(-1, -2);
            this.btnAddSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddSoftware.Name = "btnAddSoftware";
            this.btnAddSoftware.Size = new System.Drawing.Size(30, 30);
            this.btnAddSoftware.TabIndex = 9;
            this.btnAddSoftware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSoftware.UseVisualStyleBackColor = true;
            this.btnAddSoftware.Click += new System.EventHandler(this.BtnAddSoftware_Click);
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "szoftver_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
            // 
            // dgvSoftwares
            // 
            this.dgvSoftwares.AllowUserToAddRows = false;
            this.dgvSoftwares.AllowUserToDeleteRows = false;
            this.dgvSoftwares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoftwares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSoftwares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSoftwares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoftwares.Location = new System.Drawing.Point(3, 209);
            this.dgvSoftwares.Margin = new System.Windows.Forms.Padding(0);
            this.dgvSoftwares.MultiSelect = false;
            this.dgvSoftwares.Name = "dgvSoftwares";
            this.dgvSoftwares.ReadOnly = true;
            this.dgvSoftwares.RowHeadersVisible = false;
            this.dgvSoftwares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoftwares.Size = new System.Drawing.Size(1036, 389);
            this.dgvSoftwares.TabIndex = 15;
            // 
            // SoftwaresPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSoftwares);
            this.Controls.Add(this.grbSoftwareFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(999, 600);
            this.Name = "SoftwaresPanel";
            this.Size = new System.Drawing.Size(1043, 600);
            this.grbSoftwareFilter.ResumeLayout(false);
            this.grbSoftwareFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoftwares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OwnDataGridView dgvSoftwares;
        private System.Windows.Forms.Button btnDeleteFilterSoftware;
        private System.Windows.Forms.Button btnFilterSoftware;
        private System.Windows.Forms.GroupBox grbSoftwareFilter;
        private System.Windows.Forms.ComboBox cmbNetworkDeviceId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSoftwareItSystem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSoftwareProducer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbSoftAName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumberOfSoftwares;
        private System.Windows.Forms.Button btnExportSoftwaresToCsv;
        private System.Windows.Forms.Button btnReadSoftware;
        private System.Windows.Forms.Button btnEditSoftware;
        private System.Windows.Forms.Button btnRefreshSoftwares;
        private System.Windows.Forms.Button btnDeleteSoftware;
        private System.Windows.Forms.Button btnAddSoftware;
        private System.Windows.Forms.ComboBox cmbSoftwareOwnerId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
    }
}
