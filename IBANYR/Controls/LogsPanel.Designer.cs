
namespace IBANYR
{
    partial class LogsPanel
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
            this.grbLogFilter = new System.Windows.Forms.GroupBox();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.cmbEventFunctions = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpLogDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpLogDateStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportLogsToCsv = new System.Windows.Forms.Button();
            this.lblNumberOfLogs = new System.Windows.Forms.Label();
            this.btnRefreshLogs = new System.Windows.Forms.Button();
            this.sfdExportToCsv = new System.Windows.Forms.SaveFileDialog();
            this.pnlDgvFooter = new System.Windows.Forms.Panel();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.dgvLogs = new IBANYR.OwnDataGridView();
            this.grbLogFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDgvFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.AccessibleDescription = "Szűrés törlése";
            this.btnDeleteFilter.AccessibleName = "Szűrés törlése";
            this.btnDeleteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnDeleteFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFilter.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteFilter.FlatAppearance.BorderSize = 0;
            this.btnDeleteFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteFilter.Location = new System.Drawing.Point(897, 63);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilter.TabIndex = 7;
            this.btnDeleteFilter.Text = "Szűrés törlése";
            this.btnDeleteFilter.UseVisualStyleBackColor = false;
            this.btnDeleteFilter.Click += new System.EventHandler(this.BtnDeleteFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.AccessibleDescription = "Szűrés";
            this.btnFilter.AccessibleName = "Szűrés";
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFilter.Location = new System.Drawing.Point(761, 63);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 40);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Szűrés";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.ChangePage);
            // 
            // grbLogFilter
            // 
            this.grbLogFilter.AccessibleDescription = "Naplóbejegyzések szűrési feltételei";
            this.grbLogFilter.AccessibleName = "Naplóbejegyzések szűrési feltételei";
            this.grbLogFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbLogFilter.Controls.Add(this.cmbUsers);
            this.grbLogFilter.Controls.Add(this.cmbEventFunctions);
            this.grbLogFilter.Controls.Add(this.label5);
            this.grbLogFilter.Controls.Add(this.btnDeleteFilter);
            this.grbLogFilter.Controls.Add(this.dtpLogDateEnd);
            this.grbLogFilter.Controls.Add(this.label2);
            this.grbLogFilter.Controls.Add(this.btnFilter);
            this.grbLogFilter.Controls.Add(this.dtpLogDateStart);
            this.grbLogFilter.Controls.Add(this.label1);
            this.grbLogFilter.Controls.Add(this.label3);
            this.grbLogFilter.Location = new System.Drawing.Point(3, 4);
            this.grbLogFilter.Name = "grbLogFilter";
            this.grbLogFilter.Size = new System.Drawing.Size(1033, 109);
            this.grbLogFilter.TabIndex = 1;
            this.grbLogFilter.TabStop = false;
            this.grbLogFilter.Text = "Naplóbejegyzések szűrési feltételei";
            // 
            // cmbUsers
            // 
            this.cmbUsers.AccessibleDescription = "Eseményt kiváltó felhasználó kiválasztása.";
            this.cmbUsers.AccessibleName = "Felhasználó";
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(188, 26);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(238, 29);
            this.cmbUsers.TabIndex = 2;
            // 
            // cmbEventFunctions
            // 
            this.cmbEventFunctions.AccessibleDescription = "Bejegyzéstípus kiválasztása";
            this.cmbEventFunctions.AccessibleName = "Esemény kategóriája";
            this.cmbEventFunctions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventFunctions.FormattingEnabled = true;
            this.cmbEventFunctions.Location = new System.Drawing.Point(188, 61);
            this.cmbEventFunctions.Name = "cmbEventFunctions";
            this.cmbEventFunctions.Size = new System.Drawing.Size(558, 29);
            this.cmbEventFunctions.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 21);
            this.label5.TabIndex = 23;
            this.label5.Tag = "cmbEventFunctions";
            this.label5.Text = "Esemény kategóriája:";
            // 
            // dtpLogDateEnd
            // 
            this.dtpLogDateEnd.AccessibleDescription = "Esemény dátumának felső határának beállítása";
            this.dtpLogDateEnd.AccessibleName = "Esemény dátumának felső határa";
            this.dtpLogDateEnd.Checked = false;
            this.dtpLogDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLogDateEnd.Location = new System.Drawing.Point(773, 26);
            this.dtpLogDateEnd.Name = "dtpLogDateEnd";
            this.dtpLogDateEnd.ShowCheckBox = true;
            this.dtpLogDateEnd.Size = new System.Drawing.Size(155, 27);
            this.dtpLogDateEnd.TabIndex = 4;
            this.dtpLogDateEnd.ValueChanged += new System.EventHandler(this.DtpLogDateEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(752, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "-";
            // 
            // dtpLogDateStart
            // 
            this.dtpLogDateStart.AccessibleDescription = "Esemény dátumának alsó határának beállítása";
            this.dtpLogDateStart.AccessibleName = "Esemény dátumának alsó határa";
            this.dtpLogDateStart.Checked = false;
            this.dtpLogDateStart.CustomFormat = "";
            this.dtpLogDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLogDateStart.Location = new System.Drawing.Point(589, 26);
            this.dtpLogDateStart.Name = "dtpLogDateStart";
            this.dtpLogDateStart.ShowCheckBox = true;
            this.dtpLogDateStart.Size = new System.Drawing.Size(155, 27);
            this.dtpLogDateStart.TabIndex = 3;
            this.dtpLogDateStart.ValueChanged += new System.EventHandler(this.DtpLogDateStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Esemény dátuma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Felhasználó:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnExportLogsToCsv);
            this.panel1.Controls.Add(this.lblNumberOfLogs);
            this.panel1.Controls.Add(this.btnRefreshLogs);
            this.panel1.Location = new System.Drawing.Point(3, 119);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 30);
            this.panel1.TabIndex = 9;
            // 
            // btnExportLogsToCsv
            // 
            this.btnExportLogsToCsv.AccessibleDescription = "Naplóbejegyzések exportálása";
            this.btnExportLogsToCsv.AccessibleName = "Naplóbejegyzések exportálása";
            this.btnExportLogsToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportLogsToCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLogsToCsv.FlatAppearance.BorderSize = 0;
            this.btnExportLogsToCsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnExportLogsToCsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExportLogsToCsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExportLogsToCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLogsToCsv.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExportLogsToCsv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportLogsToCsv.Image = global::IBANYR.Properties.Resources.excel;
            this.btnExportLogsToCsv.Location = new System.Drawing.Point(972, -2);
            this.btnExportLogsToCsv.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportLogsToCsv.Name = "btnExportLogsToCsv";
            this.btnExportLogsToCsv.Size = new System.Drawing.Size(30, 30);
            this.btnExportLogsToCsv.TabIndex = 8;
            this.btnExportLogsToCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportLogsToCsv.UseVisualStyleBackColor = true;
            this.btnExportLogsToCsv.Click += new System.EventHandler(this.BtnExportLogsToCsv_Click);
            // 
            // lblNumberOfLogs
            // 
            this.lblNumberOfLogs.AutoSize = true;
            this.lblNumberOfLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfLogs.Location = new System.Drawing.Point(4, 4);
            this.lblNumberOfLogs.Name = "lblNumberOfLogs";
            this.lblNumberOfLogs.Size = new System.Drawing.Size(143, 19);
            this.lblNumberOfLogs.TabIndex = 17;
            this.lblNumberOfLogs.Text = "Találatok száma: ";
            // 
            // btnRefreshLogs
            // 
            this.btnRefreshLogs.AccessibleDescription = "Lista frissítése";
            this.btnRefreshLogs.AccessibleName = "Lista frissítése";
            this.btnRefreshLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshLogs.FlatAppearance.BorderSize = 0;
            this.btnRefreshLogs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshLogs.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshLogs.Location = new System.Drawing.Point(1001, -2);
            this.btnRefreshLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshLogs.Name = "btnRefreshLogs";
            this.btnRefreshLogs.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshLogs.TabIndex = 9;
            this.btnRefreshLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshLogs.UseVisualStyleBackColor = true;
            this.btnRefreshLogs.Click += new System.EventHandler(this.BtnRefreshLogs_Click);
            // 
            // sfdExportToCsv
            // 
            this.sfdExportToCsv.DefaultExt = "*.csv";
            this.sfdExportToCsv.FileName = "naplo_export.csv";
            this.sfdExportToCsv.Filter = "CSV fájl|*.csv|Minden fájl|*.*";
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
            this.pnlDgvFooter.TabIndex = 19;
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
            this.lblPageNumber.TabIndex = 13;
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
            this.btnNextPage.TabIndex = 14;
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
            this.btnLastPage.TabIndex = 15;
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
            this.btnPreviousPage.TabIndex = 12;
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
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFirstPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFirstPage.Location = new System.Drawing.Point(-1, -1);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(0);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(38, 30);
            this.btnFirstPage.TabIndex = 11;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = false;
            this.btnFirstPage.Click += new System.EventHandler(this.ChangePage);
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(3, 149);
            this.dgvLogs.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLogs.MultiSelect = false;
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersVisible = false;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(1033, 418);
            this.dgvLogs.TabIndex = 10;
            // 
            // LogsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlDgvFooter);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.grbLogFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1040, 600);
            this.Name = "LogsPanel";
            this.Size = new System.Drawing.Size(1040, 600);
            this.grbLogFilter.ResumeLayout(false);
            this.grbLogFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDgvFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.GroupBox grbLogFilter;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.ComboBox cmbEventFunctions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpLogDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefreshLogs;
        private OwnDataGridView dgvLogs;
        private System.Windows.Forms.Label lblNumberOfLogs;
        private System.Windows.Forms.Button btnExportLogsToCsv;
        private System.Windows.Forms.SaveFileDialog sfdExportToCsv;
        private System.Windows.Forms.Panel pnlDgvFooter;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.DateTimePicker dtpLogDateStart;
    }
}
