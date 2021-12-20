
namespace IBANYR
{
    partial class FrmUsersHardwares
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsersHardwares));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaintenanceLogs = new System.Windows.Forms.Button();
            this.btnReadHardware = new System.Windows.Forms.Button();
            this.btnRefreshHardwares = new System.Windows.Forms.Button();
            this.dgvHardwares = new IBANYR.OwnDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardwares)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMaintenanceLogs);
            this.panel1.Controls.Add(this.btnReadHardware);
            this.panel1.Controls.Add(this.btnRefreshHardwares);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 30);
            this.panel1.TabIndex = 16;
            // 
            // btnMaintenanceLogs
            // 
            this.btnMaintenanceLogs.AccessibleDescription = "Hardver karbantartási bejegyzéseinek megtekintése";
            this.btnMaintenanceLogs.AccessibleName = "Hardver karbantartási bejegyzéseinek megtekintése";
            this.btnMaintenanceLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenanceLogs.FlatAppearance.BorderSize = 0;
            this.btnMaintenanceLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenanceLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenanceLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenanceLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMaintenanceLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMaintenanceLogs.Image = global::IBANYR.Properties.Resources.maintenance_tiny;
            this.btnMaintenanceLogs.Location = new System.Drawing.Point(30, -2);
            this.btnMaintenanceLogs.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaintenanceLogs.Name = "btnMaintenanceLogs";
            this.btnMaintenanceLogs.Size = new System.Drawing.Size(30, 30);
            this.btnMaintenanceLogs.TabIndex = 2;
            this.btnMaintenanceLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaintenanceLogs.UseVisualStyleBackColor = true;
            this.btnMaintenanceLogs.Click += new System.EventHandler(this.BtnMaintenanceLogs_Click);
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
            this.btnReadHardware.Location = new System.Drawing.Point(0, -2);
            this.btnReadHardware.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadHardware.Name = "btnReadHardware";
            this.btnReadHardware.Size = new System.Drawing.Size(30, 30);
            this.btnReadHardware.TabIndex = 1;
            this.btnReadHardware.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadHardware.UseVisualStyleBackColor = true;
            this.btnReadHardware.Click += new System.EventHandler(this.BtnReadHardware_Click);
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
            this.btnRefreshHardwares.Location = new System.Drawing.Point(954, -2);
            this.btnRefreshHardwares.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshHardwares.Name = "btnRefreshHardwares";
            this.btnRefreshHardwares.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshHardwares.TabIndex = 3;
            this.btnRefreshHardwares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshHardwares.UseVisualStyleBackColor = true;
            this.btnRefreshHardwares.Click += new System.EventHandler(this.BtnRefreshHardwares_Click);
            // 
            // dgvHardwares
            // 
            this.dgvHardwares.AccessibleDescription = "Felhasználó használatában lévő eszközök listája";
            this.dgvHardwares.AccessibleName = "Felhasználó használatában lévő eszközök listája";
            this.dgvHardwares.AllowUserToAddRows = false;
            this.dgvHardwares.AllowUserToDeleteRows = false;
            this.dgvHardwares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHardwares.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHardwares.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHardwares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHardwares.Location = new System.Drawing.Point(9, 42);
            this.dgvHardwares.Margin = new System.Windows.Forms.Padding(0);
            this.dgvHardwares.MultiSelect = false;
            this.dgvHardwares.Name = "dgvHardwares";
            this.dgvHardwares.ReadOnly = true;
            this.dgvHardwares.RowHeadersVisible = false;
            this.dgvHardwares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHardwares.Size = new System.Drawing.Size(987, 510);
            this.dgvHardwares.TabIndex = 4;
            // 
            // FrmUsersHardwares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.dgvHardwares);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "FrmUsersHardwares";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Felhasználó eszközei";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHardwares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMaintenanceLogs;
        private System.Windows.Forms.Button btnReadHardware;
        private System.Windows.Forms.Button btnRefreshHardwares;
        private OwnDataGridView dgvHardwares;
    }
}