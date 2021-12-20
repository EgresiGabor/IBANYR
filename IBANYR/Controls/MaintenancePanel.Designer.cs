
namespace IBANYR
{
    partial class MaintenancePanel
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
            this.pnlDgvFooter = new System.Windows.Forms.Panel();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.grbLogFilter = new System.Windows.Forms.GroupBox();
            this.txbActivitiesDesc = new System.Windows.Forms.TextBox();
            this.cmbMMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteFilterMaintenance = new System.Windows.Forms.Button();
            this.txbMName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFilterMaintenance = new System.Windows.Forms.Button();
            this.cmbMType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfMaintenanceLogs = new System.Windows.Forms.Label();
            this.btnReadMaintenanceLog = new System.Windows.Forms.Button();
            this.btnEditMaintenanceLog = new System.Windows.Forms.Button();
            this.btnDeleteMaintenanceLog = new System.Windows.Forms.Button();
            this.btnAddMaintenanceLog = new System.Windows.Forms.Button();
            this.btnExportMaintenanceLogsToCsv = new System.Windows.Forms.Button();
            this.btnRefreshMaintenanceLogs = new System.Windows.Forms.Button();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.dgvMaintenanceLogs = new IBANYR.OwnDataGridView();
            this.pnlDgvFooter.SuspendLayout();
            this.grbLogFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenanceLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDgvFooter
            // 
            this.pnlDgvFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDgvFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.pnlDgvFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDgvFooter.Controls.Add(this.lblPageNumber);
            this.pnlDgvFooter.Controls.Add(this.btnNextPage);
            this.pnlDgvFooter.Controls.Add(this.btnLastPage);
            this.pnlDgvFooter.Controls.Add(this.btnPreviousPage);
            this.pnlDgvFooter.Controls.Add(this.btnFirstPage);
            this.pnlDgvFooter.Location = new System.Drawing.Point(3, 567);
            this.pnlDgvFooter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlDgvFooter.Name = "pnlDgvFooter";
            this.pnlDgvFooter.Size = new System.Drawing.Size(1034, 30);
            this.pnlDgvFooter.TabIndex = 25;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPageNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPageNumber.Location = new System.Drawing.Point(78, -1);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(876, 30);
            this.lblPageNumber.TabIndex = 19;
            this.lblPageNumber.Text = "1/1 oldal";
            this.lblPageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPage
            // 
            this.btnNextPage.AccessibleDescription = "Következő oldal";
            this.btnNextPage.AccessibleName = "Következő oldal";
            this.btnNextPage.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNextPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNextPage.Location = new System.Drawing.Point(957, -1);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(38, 30);
            this.btnNextPage.TabIndex = 19;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.ChangePage);
            // 
            // btnLastPage
            // 
            this.btnLastPage.AccessibleDescription = "Ugrás az utolsó oldalra";
            this.btnLastPage.AccessibleName = "Ugrás az utolsó oldalra";
            this.btnLastPage.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnLastPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLastPage.FlatAppearance.BorderSize = 0;
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLastPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLastPage.Location = new System.Drawing.Point(995, -1);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(38, 30);
            this.btnLastPage.TabIndex = 20;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.ChangePage);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AccessibleDescription = "Előző oldal";
            this.btnPreviousPage.AccessibleName = "Előző oldal";
            this.btnPreviousPage.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPreviousPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPreviousPage.Location = new System.Drawing.Point(37, -1);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(38, 30);
            this.btnPreviousPage.TabIndex = 18;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.ChangePage);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.AccessibleDescription = "Ugrás az első oldalra";
            this.btnFirstPage.AccessibleName = "Ugrás az első oldalra";
            this.btnFirstPage.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnFirstPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFirstPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFirstPage.Location = new System.Drawing.Point(-1, -1);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(38, 30);
            this.btnFirstPage.TabIndex = 17;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.ChangePage);
            // 
            // grbLogFilter
            // 
            this.grbLogFilter.AccessibleDescription = "Karbantartási naplóbejegyzések szűrési feltételei";
            this.grbLogFilter.AccessibleName = "Karbantartási naplóbejegyzések szűrési feltételei";
            this.grbLogFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLogFilter.Controls.Add(this.txbActivitiesDesc);
            this.grbLogFilter.Controls.Add(this.cmbMMethod);
            this.grbLogFilter.Controls.Add(this.label6);
            this.grbLogFilter.Controls.Add(this.btnDeleteFilterMaintenance);
            this.grbLogFilter.Controls.Add(this.txbMName);
            this.grbLogFilter.Controls.Add(this.label4);
            this.grbLogFilter.Controls.Add(this.btnFilterMaintenance);
            this.grbLogFilter.Controls.Add(this.cmbMType);
            this.grbLogFilter.Controls.Add(this.label5);
            this.grbLogFilter.Controls.Add(this.dtpEndDate);
            this.grbLogFilter.Controls.Add(this.label2);
            this.grbLogFilter.Controls.Add(this.dtpStartDate);
            this.grbLogFilter.Controls.Add(this.label1);
            this.grbLogFilter.Controls.Add(this.label3);
            this.grbLogFilter.Location = new System.Drawing.Point(3, 4);
            this.grbLogFilter.Name = "grbLogFilter";
            this.grbLogFilter.Size = new System.Drawing.Size(1033, 141);
            this.grbLogFilter.TabIndex = 1;
            this.grbLogFilter.TabStop = false;
            this.grbLogFilter.Text = "Karbantartási naplóbejegyzések szűrési feltételei";
            // 
            // txbActivitiesDesc
            // 
            this.txbActivitiesDesc.AccessibleDescription = "Karbantartáskor végzett tevékenység részben, vagy egyészben. Maximum 50 karakter " +
    "hosszú szöveg adható meg a kis- és nagybetűk figyelmen kívűl hagyásával.";
            this.txbActivitiesDesc.AccessibleName = "Tevékenység";
            this.txbActivitiesDesc.Location = new System.Drawing.Point(199, 58);
            this.txbActivitiesDesc.MaxLength = 200;
            this.txbActivitiesDesc.Name = "txbActivitiesDesc";
            this.txbActivitiesDesc.Size = new System.Drawing.Size(339, 27);
            this.txbActivitiesDesc.TabIndex = 4;
            // 
            // cmbMMethod
            // 
            this.cmbMMethod.AccessibleDescription = "Karbantartás módja szerinti szűrés. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbMMethod.AccessibleName = "Karbantartás módja";
            this.cmbMMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMMethod.FormattingEnabled = true;
            this.cmbMMethod.Location = new System.Drawing.Point(789, 59);
            this.cmbMMethod.Name = "cmbMMethod";
            this.cmbMMethod.Size = new System.Drawing.Size(238, 29);
            this.cmbMMethod.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(611, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Karbantartás módja:";
            // 
            // btnDeleteFilterMaintenance
            // 
            this.btnDeleteFilterMaintenance.AccessibleDescription = "Szűrés törlése";
            this.btnDeleteFilterMaintenance.AccessibleName = "Szűrés törlése";
            this.btnDeleteFilterMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFilterMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnDeleteFilterMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFilterMaintenance.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteFilterMaintenance.FlatAppearance.BorderSize = 0;
            this.btnDeleteFilterMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilterMaintenance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteFilterMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteFilterMaintenance.Location = new System.Drawing.Point(897, 95);
            this.btnDeleteFilterMaintenance.Name = "btnDeleteFilterMaintenance";
            this.btnDeleteFilterMaintenance.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilterMaintenance.TabIndex = 9;
            this.btnDeleteFilterMaintenance.Text = "Szűrés törlése";
            this.btnDeleteFilterMaintenance.UseVisualStyleBackColor = false;
            this.btnDeleteFilterMaintenance.Click += new System.EventHandler(this.BtnDeleteFilterMaintenance_Click);
            // 
            // txbMName
            // 
            this.txbMName.AccessibleDescription = "Karbantartást végző személy vagy szervezet neve részben, vagy egészben. Maximum 5" +
    "0 karakter hosszú szöveg adható meg a kis- és nagybetűk figyelmen kívűl hagyásáv" +
    "al.";
            this.txbMName.AccessibleName = "Karbantartó neve";
            this.txbMName.Location = new System.Drawing.Point(199, 26);
            this.txbMName.MaxLength = 150;
            this.txbMName.Name = "txbMName";
            this.txbMName.Size = new System.Drawing.Size(238, 27);
            this.txbMName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 21);
            this.label4.TabIndex = 26;
            this.label4.Text = "Karbantartó neve:";
            // 
            // btnFilterMaintenance
            // 
            this.btnFilterMaintenance.AccessibleDescription = "Szűrés";
            this.btnFilterMaintenance.AccessibleName = "Szűrés";
            this.btnFilterMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterMaintenance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnFilterMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilterMaintenance.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilterMaintenance.FlatAppearance.BorderSize = 0;
            this.btnFilterMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterMaintenance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFilterMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFilterMaintenance.Location = new System.Drawing.Point(761, 95);
            this.btnFilterMaintenance.Name = "btnFilterMaintenance";
            this.btnFilterMaintenance.Size = new System.Drawing.Size(130, 40);
            this.btnFilterMaintenance.TabIndex = 8;
            this.btnFilterMaintenance.Text = "Szűrés";
            this.btnFilterMaintenance.UseVisualStyleBackColor = false;
            this.btnFilterMaintenance.Click += new System.EventHandler(this.ChangePage);
            // 
            // cmbMType
            // 
            this.cmbMType.AccessibleDescription = "Karbantartás típusa szerinti szűrés. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbMType.AccessibleName = "Karbantartás típusa";
            this.cmbMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMType.FormattingEnabled = true;
            this.cmbMType.Location = new System.Drawing.Point(789, 24);
            this.cmbMType.Name = "cmbMType";
            this.cmbMType.Size = new System.Drawing.Size(238, 29);
            this.cmbMType.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 21);
            this.label5.TabIndex = 23;
            this.label5.Tag = "";
            this.label5.Text = "Tevékenység:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AccessibleDescription = "Karbantartás dátumának felső határa";
            this.dtpEndDate.AccessibleName = "Karbantartás dátumának felső határa";
            this.dtpEndDate.Checked = false;
            this.dtpEndDate.CustomFormat = "yyyy.MM.dd HH:mm";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(417, 91);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowCheckBox = true;
            this.dtpEndDate.Size = new System.Drawing.Size(191, 27);
            this.dtpEndDate.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "-";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AccessibleDescription = "Karbantartás dátumának alsó határa";
            this.dtpStartDate.AccessibleName = "Karbantartás dátumának alsó határa";
            this.dtpStartDate.Checked = false;
            this.dtpStartDate.CustomFormat = "yyyy.MM.dd HH:mm";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(199, 91);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.ShowCheckBox = true;
            this.dtpStartDate.Size = new System.Drawing.Size(191, 27);
            this.dtpStartDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Karbantartás dátuma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Karbantartás típusa:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumberOfMaintenanceLogs);
            this.panel1.Controls.Add(this.btnReadMaintenanceLog);
            this.panel1.Controls.Add(this.btnEditMaintenanceLog);
            this.panel1.Controls.Add(this.btnDeleteMaintenanceLog);
            this.panel1.Controls.Add(this.btnAddMaintenanceLog);
            this.panel1.Controls.Add(this.btnExportMaintenanceLogsToCsv);
            this.panel1.Controls.Add(this.btnRefreshMaintenanceLogs);
            this.panel1.Location = new System.Drawing.Point(3, 151);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 30);
            this.panel1.TabIndex = 20;
            // 
            // lblNumberOfMaintenanceLogs
            // 
            this.lblNumberOfMaintenanceLogs.AutoSize = true;
            this.lblNumberOfMaintenanceLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfMaintenanceLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfMaintenanceLogs.Location = new System.Drawing.Point(122, 4);
            this.lblNumberOfMaintenanceLogs.Name = "lblNumberOfMaintenanceLogs";
            this.lblNumberOfMaintenanceLogs.Size = new System.Drawing.Size(192, 19);
            this.lblNumberOfMaintenanceLogs.TabIndex = 26;
            this.lblNumberOfMaintenanceLogs.Text = "Listázott elemek száma: ";
            // 
            // btnReadMaintenanceLog
            // 
            this.btnReadMaintenanceLog.AccessibleDescription = "Karbantartási naplóbejegyzés megtekintése";
            this.btnReadMaintenanceLog.AccessibleName = "Karbantartási naplóbejegyzés megtekintése";
            this.btnReadMaintenanceLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadMaintenanceLog.FlatAppearance.BorderSize = 0;
            this.btnReadMaintenanceLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadMaintenanceLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadMaintenanceLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadMaintenanceLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadMaintenanceLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadMaintenanceLog.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadMaintenanceLog.Location = new System.Drawing.Point(89, -2);
            this.btnReadMaintenanceLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadMaintenanceLog.Name = "btnReadMaintenanceLog";
            this.btnReadMaintenanceLog.Size = new System.Drawing.Size(30, 30);
            this.btnReadMaintenanceLog.TabIndex = 13;
            this.btnReadMaintenanceLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadMaintenanceLog.UseVisualStyleBackColor = true;
            this.btnReadMaintenanceLog.Click += new System.EventHandler(this.BtnReadMaintenanceLog_Click);
            // 
            // btnEditMaintenanceLog
            // 
            this.btnEditMaintenanceLog.AccessibleDescription = "Karbantartási naplóbejegyzés módosítása";
            this.btnEditMaintenanceLog.AccessibleName = "Karbantartási naplóbejegyzés módosítása";
            this.btnEditMaintenanceLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditMaintenanceLog.FlatAppearance.BorderSize = 0;
            this.btnEditMaintenanceLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditMaintenanceLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditMaintenanceLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMaintenanceLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditMaintenanceLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditMaintenanceLog.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditMaintenanceLog.Location = new System.Drawing.Point(59, -2);
            this.btnEditMaintenanceLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditMaintenanceLog.Name = "btnEditMaintenanceLog";
            this.btnEditMaintenanceLog.Size = new System.Drawing.Size(30, 30);
            this.btnEditMaintenanceLog.TabIndex = 12;
            this.btnEditMaintenanceLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditMaintenanceLog.UseVisualStyleBackColor = true;
            this.btnEditMaintenanceLog.Click += new System.EventHandler(this.BtnEditMaintenanceLog_Click);
            // 
            // btnDeleteMaintenanceLog
            // 
            this.btnDeleteMaintenanceLog.AccessibleDescription = "Karbantartási naplóbejegyzés törlése";
            this.btnDeleteMaintenanceLog.AccessibleName = "Karbantartási naplóbejegyzés törlése";
            this.btnDeleteMaintenanceLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteMaintenanceLog.FlatAppearance.BorderSize = 0;
            this.btnDeleteMaintenanceLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteMaintenanceLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteMaintenanceLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMaintenanceLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteMaintenanceLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteMaintenanceLog.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteMaintenanceLog.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteMaintenanceLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteMaintenanceLog.Name = "btnDeleteMaintenanceLog";
            this.btnDeleteMaintenanceLog.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteMaintenanceLog.TabIndex = 11;
            this.btnDeleteMaintenanceLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteMaintenanceLog.UseVisualStyleBackColor = true;
            this.btnDeleteMaintenanceLog.Click += new System.EventHandler(this.BtnDeleteMaintenanceLog_Click);
            // 
            // btnAddMaintenanceLog
            // 
            this.btnAddMaintenanceLog.AccessibleDescription = "Karbantartási naplóbejegyzés rögzítése";
            this.btnAddMaintenanceLog.AccessibleName = "Karbantartási naplóbejegyzés rögzítése";
            this.btnAddMaintenanceLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMaintenanceLog.FlatAppearance.BorderSize = 0;
            this.btnAddMaintenanceLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddMaintenanceLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddMaintenanceLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMaintenanceLog.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddMaintenanceLog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddMaintenanceLog.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddMaintenanceLog.Location = new System.Drawing.Point(-1, -2);
            this.btnAddMaintenanceLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddMaintenanceLog.Name = "btnAddMaintenanceLog";
            this.btnAddMaintenanceLog.Size = new System.Drawing.Size(30, 30);
            this.btnAddMaintenanceLog.TabIndex = 10;
            this.btnAddMaintenanceLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddMaintenanceLog.UseVisualStyleBackColor = true;
            this.btnAddMaintenanceLog.Click += new System.EventHandler(this.BtnAddMaintenanceLog_Click);
            // 
            // btnExportMaintenanceLogsToCsv
            // 
            this.btnExportMaintenanceLogsToCsv.AccessibleDescription = "Karbantartási napló exportálása";
            this.btnExportMaintenanceLogsToCsv.AccessibleName = "Karbantartási napló exportálása";
            this.btnExportMaintenanceLogsToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportMaintenanceLogsToCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportMaintenanceLogsToCsv.FlatAppearance.BorderSize = 0;
            this.btnExportMaintenanceLogsToCsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExportMaintenanceLogsToCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportMaintenanceLogsToCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportMaintenanceLogsToCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMaintenanceLogsToCsv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExportMaintenanceLogsToCsv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportMaintenanceLogsToCsv.Image = global::IBANYR.Properties.Resources.excel;
            this.btnExportMaintenanceLogsToCsv.Location = new System.Drawing.Point(972, -2);
            this.btnExportMaintenanceLogsToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportMaintenanceLogsToCsv.Name = "btnExportMaintenanceLogsToCsv";
            this.btnExportMaintenanceLogsToCsv.Size = new System.Drawing.Size(30, 30);
            this.btnExportMaintenanceLogsToCsv.TabIndex = 14;
            this.btnExportMaintenanceLogsToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportMaintenanceLogsToCsv.UseVisualStyleBackColor = true;
            this.btnExportMaintenanceLogsToCsv.Click += new System.EventHandler(this.BtnExportMaintenanceLogsToCsv_Click);
            // 
            // btnRefreshMaintenanceLogs
            // 
            this.btnRefreshMaintenanceLogs.AccessibleDescription = "Lista frissítése";
            this.btnRefreshMaintenanceLogs.AccessibleName = "Lista frissítése";
            this.btnRefreshMaintenanceLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshMaintenanceLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshMaintenanceLogs.FlatAppearance.BorderSize = 0;
            this.btnRefreshMaintenanceLogs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshMaintenanceLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshMaintenanceLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshMaintenanceLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMaintenanceLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshMaintenanceLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshMaintenanceLogs.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshMaintenanceLogs.Location = new System.Drawing.Point(1001, -2);
            this.btnRefreshMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshMaintenanceLogs.Name = "btnRefreshMaintenanceLogs";
            this.btnRefreshMaintenanceLogs.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshMaintenanceLogs.TabIndex = 15;
            this.btnRefreshMaintenanceLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshMaintenanceLogs.UseVisualStyleBackColor = true;
            this.btnRefreshMaintenanceLogs.Click += new System.EventHandler(this.BtnRefreshMaintenanceLogs_Click);
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "karbantartas_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
            // 
            // dgvMaintenanceLogs
            // 
            this.dgvMaintenanceLogs.AllowUserToAddRows = false;
            this.dgvMaintenanceLogs.AllowUserToDeleteRows = false;
            this.dgvMaintenanceLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaintenanceLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMaintenanceLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaintenanceLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaintenanceLogs.Location = new System.Drawing.Point(3, 181);
            this.dgvMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMaintenanceLogs.MultiSelect = false;
            this.dgvMaintenanceLogs.Name = "dgvMaintenanceLogs";
            this.dgvMaintenanceLogs.ReadOnly = true;
            this.dgvMaintenanceLogs.RowHeadersVisible = false;
            this.dgvMaintenanceLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintenanceLogs.Size = new System.Drawing.Size(1033, 386);
            this.dgvMaintenanceLogs.TabIndex = 16;
            // 
            // MaintenancePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlDgvFooter);
            this.Controls.Add(this.dgvMaintenanceLogs);
            this.Controls.Add(this.grbLogFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1040, 600);
            this.Name = "MaintenancePanel";
            this.Size = new System.Drawing.Size(1040, 600);
            this.pnlDgvFooter.ResumeLayout(false);
            this.grbLogFilter.ResumeLayout(false);
            this.grbLogFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaintenanceLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDgvFooter;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnFirstPage;
        private OwnDataGridView dgvMaintenanceLogs;
        private System.Windows.Forms.GroupBox grbLogFilter;
        private System.Windows.Forms.ComboBox cmbMType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteFilterMaintenance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExportMaintenanceLogsToCsv;
        private System.Windows.Forms.Button btnRefreshMaintenanceLogs;
        private System.Windows.Forms.Button btnFilterMaintenance;
        private System.Windows.Forms.Label lblNumberOfMaintenanceLogs;
        private System.Windows.Forms.Button btnReadMaintenanceLog;
        private System.Windows.Forms.Button btnEditMaintenanceLog;
        private System.Windows.Forms.Button btnDeleteMaintenanceLog;
        private System.Windows.Forms.Button btnAddMaintenanceLog;
        private System.Windows.Forms.TextBox txbMName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMMethod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbActivitiesDesc;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
    }
}
