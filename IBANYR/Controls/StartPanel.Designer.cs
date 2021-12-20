
namespace IBANYR
{
    partial class StartPanel
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
            this.grbPersonalData = new System.Windows.Forms.GroupBox();
            this.btnOwnHardwares = new System.Windows.Forms.Button();
            this.btnOwnItSystemPermissions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grbPlannedMaintenances = new System.Windows.Forms.GroupBox();
            this.lsvMaintenances = new System.Windows.Forms.ListView();
            this.grbDepartmentUsers = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new IBANYR.OwnDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUserItSystemPermission = new System.Windows.Forms.Button();
            this.btnReadUser = new System.Windows.Forms.Button();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.grbPersonalData.SuspendLayout();
            this.grbPlannedMaintenances.SuspendLayout();
            this.grbDepartmentUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbPersonalData
            // 
            this.grbPersonalData.AccessibleDescription = "Saját adatok";
            this.grbPersonalData.AccessibleName = "Saját adatok";
            this.grbPersonalData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPersonalData.Controls.Add(this.btnOwnHardwares);
            this.grbPersonalData.Controls.Add(this.btnOwnItSystemPermissions);
            this.grbPersonalData.Controls.Add(this.label1);
            this.grbPersonalData.Controls.Add(this.label2);
            this.grbPersonalData.Controls.Add(this.label3);
            this.grbPersonalData.Controls.Add(this.label4);
            this.grbPersonalData.Controls.Add(this.label5);
            this.grbPersonalData.Controls.Add(this.lblDepartment);
            this.grbPersonalData.Controls.Add(this.lblPhone);
            this.grbPersonalData.Controls.Add(this.lblEmail);
            this.grbPersonalData.Controls.Add(this.lblPost);
            this.grbPersonalData.Controls.Add(this.lblUserName);
            this.grbPersonalData.Location = new System.Drawing.Point(3, 4);
            this.grbPersonalData.Name = "grbPersonalData";
            this.grbPersonalData.Size = new System.Drawing.Size(1034, 168);
            this.grbPersonalData.TabIndex = 1;
            this.grbPersonalData.TabStop = false;
            this.grbPersonalData.Text = "Saját adatok";
            // 
            // btnOwnHardwares
            // 
            this.btnOwnHardwares.AccessibleDescription = "Használt eszközök megtekintése";
            this.btnOwnHardwares.AccessibleName = "Használt eszközök megtekintése";
            this.btnOwnHardwares.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwnHardwares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOwnHardwares.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOwnHardwares.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOwnHardwares.FlatAppearance.BorderSize = 0;
            this.btnOwnHardwares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOwnHardwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOwnHardwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOwnHardwares.Location = new System.Drawing.Point(737, 62);
            this.btnOwnHardwares.Name = "btnOwnHardwares";
            this.btnOwnHardwares.Size = new System.Drawing.Size(291, 40);
            this.btnOwnHardwares.TabIndex = 3;
            this.btnOwnHardwares.Text = "Használt eszközök megtekintése";
            this.btnOwnHardwares.UseVisualStyleBackColor = false;
            this.btnOwnHardwares.Click += new System.EventHandler(this.BtnOwnHardwares_Click);
            // 
            // btnOwnItSystemPermissions
            // 
            this.btnOwnItSystemPermissions.AccessibleDescription = "Saját jogosultságok megtekintése";
            this.btnOwnItSystemPermissions.AccessibleName = "Saját jogosultságok megtekintése";
            this.btnOwnItSystemPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwnItSystemPermissions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOwnItSystemPermissions.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOwnItSystemPermissions.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOwnItSystemPermissions.FlatAppearance.BorderSize = 0;
            this.btnOwnItSystemPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOwnItSystemPermissions.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOwnItSystemPermissions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOwnItSystemPermissions.Location = new System.Drawing.Point(737, 16);
            this.btnOwnItSystemPermissions.Name = "btnOwnItSystemPermissions";
            this.btnOwnItSystemPermissions.Size = new System.Drawing.Size(291, 40);
            this.btnOwnItSystemPermissions.TabIndex = 2;
            this.btnOwnItSystemPermissions.Text = "Saját jogosultságok megtekintése";
            this.btnOwnItSystemPermissions.UseVisualStyleBackColor = false;
            this.btnOwnItSystemPermissions.Click += new System.EventHandler(this.BtnOwnItSystemPermissions_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Szervezet/szervezeti egység:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Telefon:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Email cím:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Beosztás:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Név:";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(254, 135);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(3);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(242, 21);
            this.lblDepartment.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(254, 108);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(3);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(242, 21);
            this.lblPhone.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(254, 81);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(3);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(242, 21);
            this.lblEmail.TabIndex = 2;
            // 
            // lblPost
            // 
            this.lblPost.Location = new System.Drawing.Point(254, 54);
            this.lblPost.Margin = new System.Windows.Forms.Padding(3);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(242, 21);
            this.lblPost.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(254, 26);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(3);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(242, 21);
            this.lblUserName.TabIndex = 0;
            // 
            // grbPlannedMaintenances
            // 
            this.grbPlannedMaintenances.AccessibleDescription = "Tervezett rendszerkarbantartások";
            this.grbPlannedMaintenances.AccessibleName = "Tervezett rendszerkarbantartások";
            this.grbPlannedMaintenances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPlannedMaintenances.Controls.Add(this.lsvMaintenances);
            this.grbPlannedMaintenances.Location = new System.Drawing.Point(3, 178);
            this.grbPlannedMaintenances.Name = "grbPlannedMaintenances";
            this.grbPlannedMaintenances.Size = new System.Drawing.Size(1034, 240);
            this.grbPlannedMaintenances.TabIndex = 4;
            this.grbPlannedMaintenances.TabStop = false;
            this.grbPlannedMaintenances.Text = "Tervezett rendszerkarbantartások";
            // 
            // lsvMaintenances
            // 
            this.lsvMaintenances.AccessibleDescription = "Tervezett rendszerkarbantartások listája";
            this.lsvMaintenances.AccessibleName = "Tervezett rendszerkarbantartások listája";
            this.lsvMaintenances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvMaintenances.FullRowSelect = true;
            this.lsvMaintenances.GridLines = true;
            this.lsvMaintenances.HideSelection = false;
            this.lsvMaintenances.Location = new System.Drawing.Point(3, 23);
            this.lsvMaintenances.Name = "lsvMaintenances";
            this.lsvMaintenances.Size = new System.Drawing.Size(1028, 214);
            this.lsvMaintenances.TabIndex = 5;
            this.lsvMaintenances.UseCompatibleStateImageBehavior = false;
            this.lsvMaintenances.View = System.Windows.Forms.View.Details;
            // 
            // grbDepartmentUsers
            // 
            this.grbDepartmentUsers.AccessibleDescription = "Beosztottak listája";
            this.grbDepartmentUsers.AccessibleName = "Beosztottak listája";
            this.grbDepartmentUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDepartmentUsers.Controls.Add(this.dgvUsers);
            this.grbDepartmentUsers.Controls.Add(this.panel1);
            this.grbDepartmentUsers.Location = new System.Drawing.Point(3, 424);
            this.grbDepartmentUsers.Name = "grbDepartmentUsers";
            this.grbDepartmentUsers.Size = new System.Drawing.Size(1034, 206);
            this.grbDepartmentUsers.TabIndex = 6;
            this.grbDepartmentUsers.TabStop = false;
            this.grbDepartmentUsers.Text = "Beosztottak listája";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AccessibleDescription = "Beosztottak listája";
            this.dgvUsers.AccessibleName = "Beosztottak listája";
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(3, 56);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(0);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1028, 147);
            this.dgvUsers.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUserItSystemPermission);
            this.panel1.Controls.Add(this.btnReadUser);
            this.panel1.Controls.Add(this.btnRefreshUsers);
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 30);
            this.panel1.TabIndex = 2;
            // 
            // btnUserItSystemPermission
            // 
            this.btnUserItSystemPermission.AccessibleDescription = "Felhasználó rendszerjogosultságai";
            this.btnUserItSystemPermission.AccessibleName = "Felhasználó rendszerjogosultságai";
            this.btnUserItSystemPermission.BackgroundImage = global::IBANYR.Properties.Resources.list;
            this.btnUserItSystemPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserItSystemPermission.FlatAppearance.BorderSize = 0;
            this.btnUserItSystemPermission.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserItSystemPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUserItSystemPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUserItSystemPermission.Location = new System.Drawing.Point(30, -1);
            this.btnUserItSystemPermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserItSystemPermission.Name = "btnUserItSystemPermission";
            this.btnUserItSystemPermission.Size = new System.Drawing.Size(30, 30);
            this.btnUserItSystemPermission.TabIndex = 8;
            this.btnUserItSystemPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserItSystemPermission.UseVisualStyleBackColor = true;
            this.btnUserItSystemPermission.Click += new System.EventHandler(this.BtnUserItSystemPermission_Click);
            // 
            // btnReadUser
            // 
            this.btnReadUser.AccessibleDescription = "Felhasználó adatainak megtekintése";
            this.btnReadUser.AccessibleName = "Felhasználó adatainak megtekintése";
            this.btnReadUser.BackgroundImage = global::IBANYR.Properties.Resources.see;
            this.btnReadUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadUser.FlatAppearance.BorderSize = 0;
            this.btnReadUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadUser.Location = new System.Drawing.Point(0, -1);
            this.btnReadUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadUser.Name = "btnReadUser";
            this.btnReadUser.Size = new System.Drawing.Size(30, 30);
            this.btnReadUser.TabIndex = 7;
            this.btnReadUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadUser.UseVisualStyleBackColor = true;
            this.btnReadUser.Click += new System.EventHandler(this.BtnReadUser_Click);
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.AccessibleDescription = "Lista frissítése";
            this.btnRefreshUsers.AccessibleName = "Lista frissítése";
            this.btnRefreshUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshUsers.BackgroundImage = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
            this.btnRefreshUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshUsers.Location = new System.Drawing.Point(997, -1);
            this.btnRefreshUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshUsers.TabIndex = 9;
            this.btnRefreshUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshUsers.UseVisualStyleBackColor = true;
            this.btnRefreshUsers.Click += new System.EventHandler(this.BtnRefreshUsers_Click);
            // 
            // StartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbDepartmentUsers);
            this.Controls.Add(this.grbPlannedMaintenances);
            this.Controls.Add(this.grbPersonalData);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "StartPanel";
            this.Size = new System.Drawing.Size(1040, 633);
            this.grbPersonalData.ResumeLayout(false);
            this.grbPlannedMaintenances.ResumeLayout(false);
            this.grbDepartmentUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPersonalData;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox grbPlannedMaintenances;
        private System.Windows.Forms.ListView lsvMaintenances;
        private System.Windows.Forms.GroupBox grbDepartmentUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOwnItSystemPermissions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUserItSystemPermission;
        private System.Windows.Forms.Button btnReadUser;
        private System.Windows.Forms.Button btnRefreshUsers;
        private OwnDataGridView dgvUsers;
        private System.Windows.Forms.Button btnOwnHardwares;
    }
}
