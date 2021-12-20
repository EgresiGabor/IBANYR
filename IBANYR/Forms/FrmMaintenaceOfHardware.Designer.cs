
namespace IBANYR
{
    partial class FrmMaintenaceOfHardware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaintenaceOfHardware));
            this.pnlDgvFooter = new System.Windows.Forms.Panel();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfMaintenanceLogs = new System.Windows.Forms.Label();
            this.btnReadMaintenanceLog = new System.Windows.Forms.Button();
            this.btnEditMaintenanceLog = new System.Windows.Forms.Button();
            this.btnDeleteMaintenanceLog = new System.Windows.Forms.Button();
            this.btnAddMaintenanceLog = new System.Windows.Forms.Button();
            this.btnExportMaintenanceLogsToCsv = new System.Windows.Forms.Button();
            this.btnRefreshMaintenanceLogs = new System.Windows.Forms.Button();
            this.dgvMaintenanceLogs = new IBANYR.OwnDataGridView();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.pnlDgvFooter.SuspendLayout();
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
            this.pnlDgvFooter.Location = new System.Drawing.Point(12, 405);
            this.pnlDgvFooter.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlDgvFooter.Name = "pnlDgvFooter";
            this.pnlDgvFooter.Size = new System.Drawing.Size(823, 30);
            this.pnlDgvFooter.TabIndex = 28;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPageNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPageNumber.Location = new System.Drawing.Point(78, -1);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(665, 30);
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
            this.btnNextPage.Location = new System.Drawing.Point(746, -1);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(38, 30);
            this.btnNextPage.TabIndex = 10;
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
            this.btnLastPage.Location = new System.Drawing.Point(784, -1);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(38, 30);
            this.btnLastPage.TabIndex = 11;
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
            this.btnPreviousPage.TabIndex = 9;
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
            this.btnFirstPage.TabIndex = 8;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.ChangePage);
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 30);
            this.panel1.TabIndex = 26;
            // 
            // lblNumberOfMaintenanceLogs
            // 
            this.lblNumberOfMaintenanceLogs.AutoSize = true;
            this.lblNumberOfMaintenanceLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfMaintenanceLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfMaintenanceLogs.Location = new System.Drawing.Point(122, 4);
            this.lblNumberOfMaintenanceLogs.Name = "lblNumberOfMaintenanceLogs";
            this.lblNumberOfMaintenanceLogs.Size = new System.Drawing.Size(230, 19);
            this.lblNumberOfMaintenanceLogs.TabIndex = 26;
            this.lblNumberOfMaintenanceLogs.Text = "Listázott bejegyzések száma: ";
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
            this.btnReadMaintenanceLog.TabIndex = 4;
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
            this.btnEditMaintenanceLog.TabIndex = 3;
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
            this.btnDeleteMaintenanceLog.TabIndex = 2;
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
            this.btnAddMaintenanceLog.TabIndex = 1;
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
            this.btnExportMaintenanceLogsToCsv.Location = new System.Drawing.Point(761, -2);
            this.btnExportMaintenanceLogsToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportMaintenanceLogsToCsv.Name = "btnExportMaintenanceLogsToCsv";
            this.btnExportMaintenanceLogsToCsv.Size = new System.Drawing.Size(30, 30);
            this.btnExportMaintenanceLogsToCsv.TabIndex = 5;
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
            this.btnRefreshMaintenanceLogs.Location = new System.Drawing.Point(790, -2);
            this.btnRefreshMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshMaintenanceLogs.Name = "btnRefreshMaintenanceLogs";
            this.btnRefreshMaintenanceLogs.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshMaintenanceLogs.TabIndex = 6;
            this.btnRefreshMaintenanceLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshMaintenanceLogs.UseVisualStyleBackColor = true;
            this.btnRefreshMaintenanceLogs.Click += new System.EventHandler(this.BtnRefreshMaintenanceLogs_Click);
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
            this.dgvMaintenanceLogs.Location = new System.Drawing.Point(12, 42);
            this.dgvMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.dgvMaintenanceLogs.MultiSelect = false;
            this.dgvMaintenanceLogs.Name = "dgvMaintenanceLogs";
            this.dgvMaintenanceLogs.ReadOnly = true;
            this.dgvMaintenanceLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaintenanceLogs.Size = new System.Drawing.Size(822, 363);
            this.dgvMaintenanceLogs.TabIndex = 7;
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "karbantartas_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
            // 
            // FrmMaintenaceOfHardware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 447);
            this.Controls.Add(this.pnlDgvFooter);
            this.Controls.Add(this.dgvMaintenanceLogs);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaintenaceOfHardware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardver karbantartási bejegyzései";
            this.pnlDgvFooter.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumberOfMaintenanceLogs;
        private System.Windows.Forms.Button btnReadMaintenanceLog;
        private System.Windows.Forms.Button btnEditMaintenanceLog;
        private System.Windows.Forms.Button btnDeleteMaintenanceLog;
        private System.Windows.Forms.Button btnAddMaintenanceLog;
        private System.Windows.Forms.Button btnExportMaintenanceLogsToCsv;
        private System.Windows.Forms.Button btnRefreshMaintenanceLogs;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
    }
}