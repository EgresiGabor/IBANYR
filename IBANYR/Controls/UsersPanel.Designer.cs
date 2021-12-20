
namespace IBANYR
{
    partial class UsersPanel
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumberOfUsers = new System.Windows.Forms.Label();
            this.btnUserItSystemPermission = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnReadUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnRefreshUsers = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.grbUserFilter = new System.Windows.Forms.GroupBox();
            this.cmbUserGroup = new System.Windows.Forms.ComboBox();
            this.btnDeleteFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbLocked = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRegDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpRegDateStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvUsers = new IBANYR.OwnDataGridView();
            this.panel1.SuspendLayout();
            this.grbUserFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNumberOfUsers);
            this.panel1.Controls.Add(this.btnUserItSystemPermission);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.btnReadUser);
            this.panel1.Controls.Add(this.btnEditUser);
            this.panel1.Controls.Add(this.btnRefreshUsers);
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Location = new System.Drawing.Point(4, 138);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 30);
            this.panel1.TabIndex = 1;
            // 
            // lblNumberOfUsers
            // 
            this.lblNumberOfUsers.AutoSize = true;
            this.lblNumberOfUsers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNumberOfUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNumberOfUsers.Location = new System.Drawing.Point(182, 5);
            this.lblNumberOfUsers.Name = "lblNumberOfUsers";
            this.lblNumberOfUsers.Size = new System.Drawing.Size(229, 19);
            this.lblNumberOfUsers.TabIndex = 22;
            this.lblNumberOfUsers.Text = "Listázott felhasználók száma: ";
            // 
            // btnUserItSystemPermission
            // 
            this.btnUserItSystemPermission.AccessibleDescription = "Felhasználó rendszerjogosultságainak kezelése";
            this.btnUserItSystemPermission.AccessibleName = "Felhasználó rendszerjogosultságainak kezelése";
            this.btnUserItSystemPermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserItSystemPermission.FlatAppearance.BorderSize = 0;
            this.btnUserItSystemPermission.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUserItSystemPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserItSystemPermission.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUserItSystemPermission.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUserItSystemPermission.Image = global::IBANYR.Properties.Resources.list;
            this.btnUserItSystemPermission.Location = new System.Drawing.Point(149, -2);
            this.btnUserItSystemPermission.Margin = new System.Windows.Forms.Padding(0);
            this.btnUserItSystemPermission.Name = "btnUserItSystemPermission";
            this.btnUserItSystemPermission.Size = new System.Drawing.Size(30, 30);
            this.btnUserItSystemPermission.TabIndex = 14;
            this.btnUserItSystemPermission.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUserItSystemPermission.UseVisualStyleBackColor = true;
            this.btnUserItSystemPermission.Click += new System.EventHandler(this.BtnUserItSystemPermission_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.AccessibleDescription = "Felhasználó jelszavának módosítása";
            this.btnChangePassword.AccessibleName = "Felhasználó jelszavának módosítása";
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChangePassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnChangePassword.Image = global::IBANYR.Properties.Resources.editKey;
            this.btnChangePassword.Location = new System.Drawing.Point(89, -2);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(30, 30);
            this.btnChangePassword.TabIndex = 12;
            this.btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.BtnChangePassword_Click);
            // 
            // btnReadUser
            // 
            this.btnReadUser.AccessibleDescription = "Felhasználó adatainak megtekintése";
            this.btnReadUser.AccessibleName = "Felhasználó adatainak megtekintése";
            this.btnReadUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadUser.FlatAppearance.BorderSize = 0;
            this.btnReadUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadUser.Image = global::IBANYR.Properties.Resources.see;
            this.btnReadUser.Location = new System.Drawing.Point(119, -2);
            this.btnReadUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnReadUser.Name = "btnReadUser";
            this.btnReadUser.Size = new System.Drawing.Size(30, 30);
            this.btnReadUser.TabIndex = 13;
            this.btnReadUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReadUser.UseVisualStyleBackColor = true;
            this.btnReadUser.Click += new System.EventHandler(this.BtnReadUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.AccessibleDescription = "Felhasználó adatainak szerkesztése";
            this.btnEditUser.AccessibleName = "Felhasználó adatainak szerkesztése";
            this.btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditUser.FlatAppearance.BorderSize = 0;
            this.btnEditUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnEditUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditUser.Image = global::IBANYR.Properties.Resources.edit;
            this.btnEditUser.Location = new System.Drawing.Point(59, -2);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(30, 30);
            this.btnEditUser.TabIndex = 11;
            this.btnEditUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.BtnEditUser_Click);
            // 
            // btnRefreshUsers
            // 
            this.btnRefreshUsers.AccessibleDescription = "Lista frissítése";
            this.btnRefreshUsers.AccessibleName = "Lista frissítése";
            this.btnRefreshUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
            this.btnRefreshUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshUsers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRefreshUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefreshUsers.Image = global::IBANYR.Properties.Resources.refresh;
            this.btnRefreshUsers.Location = new System.Drawing.Point(1001, -2);
            this.btnRefreshUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefreshUsers.Name = "btnRefreshUsers";
            this.btnRefreshUsers.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshUsers.TabIndex = 15;
            this.btnRefreshUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefreshUsers.UseVisualStyleBackColor = true;
            this.btnRefreshUsers.Click += new System.EventHandler(this.BtnRefreshUsers_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.AccessibleDescription = "Felhasználó törlése";
            this.btnDeleteUser.AccessibleName = "Felhasználó törlése";
            this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteUser.FlatAppearance.BorderSize = 0;
            this.btnDeleteUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteUser.Image = global::IBANYR.Properties.Resources.delete;
            this.btnDeleteUser.Location = new System.Drawing.Point(29, -2);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteUser.TabIndex = 10;
            this.btnDeleteUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.BtnDeleteUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.AccessibleDescription = "Új felhasználó rögzítése";
            this.btnAddUser.AccessibleName = "Új felhasználó rögzítése";
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddUser.Image = global::IBANYR.Properties.Resources.add;
            this.btnAddUser.Location = new System.Drawing.Point(-1, -2);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(30, 30);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // grbUserFilter
            // 
            this.grbUserFilter.AccessibleDescription = "Felhasználók szűrési feltételei";
            this.grbUserFilter.AccessibleName = "Felhasználók szűrési feltételei";
            this.grbUserFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUserFilter.Controls.Add(this.cmbUserGroup);
            this.grbUserFilter.Controls.Add(this.btnDeleteFilter);
            this.grbUserFilter.Controls.Add(this.label5);
            this.grbUserFilter.Controls.Add(this.btnFilter);
            this.grbUserFilter.Controls.Add(this.cmbLocked);
            this.grbUserFilter.Controls.Add(this.label4);
            this.grbUserFilter.Controls.Add(this.dtpRegDateEnd);
            this.grbUserFilter.Controls.Add(this.label2);
            this.grbUserFilter.Controls.Add(this.dtpRegDateStart);
            this.grbUserFilter.Controls.Add(this.label1);
            this.grbUserFilter.Controls.Add(this.txbUName);
            this.grbUserFilter.Controls.Add(this.label3);
            this.grbUserFilter.Location = new System.Drawing.Point(4, 4);
            this.grbUserFilter.Name = "grbUserFilter";
            this.grbUserFilter.Size = new System.Drawing.Size(1033, 128);
            this.grbUserFilter.TabIndex = 1;
            this.grbUserFilter.TabStop = false;
            this.grbUserFilter.Text = "Felhasználók szűrési feltételei";
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.AccessibleDescription = "Felhasználó jogosultsági csoporttagsága. Üres érték esetén nincs hatása a szűrésr" +
    "e.";
            this.cmbUserGroup.AccessibleName = "Jogosultsági csoporttagság";
            this.cmbUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserGroup.FormattingEnabled = true;
            this.cmbUserGroup.Location = new System.Drawing.Point(244, 92);
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.Size = new System.Drawing.Size(237, 29);
            this.cmbUserGroup.TabIndex = 6;
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
            this.btnDeleteFilter.Location = new System.Drawing.Point(897, 81);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteFilter.TabIndex = 8;
            this.btnDeleteFilter.Text = "Szűrés törlése";
            this.btnDeleteFilter.UseVisualStyleBackColor = false;
            this.btnDeleteFilter.Click += new System.EventHandler(this.BtnDeleteFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 21);
            this.label5.TabIndex = 23;
            this.label5.Text = "Jogosultsági csoporttagság:";
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
            this.btnFilter.Location = new System.Drawing.Point(761, 81);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(130, 40);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Szűrés";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // cmbLocked
            // 
            this.cmbLocked.AccessibleDescription = "Felhasználói fiók zárolva van-e. Üres érték esetén nincs hatása a szűrésre.";
            this.cmbLocked.AccessibleName = "Zárolva";
            this.cmbLocked.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocked.FormattingEnabled = true;
            this.cmbLocked.Items.AddRange(new object[] {
            "",
            "Igen",
            "Nem"});
            this.cmbLocked.Location = new System.Drawing.Point(668, 26);
            this.cmbLocked.Name = "cmbLocked";
            this.cmbLocked.Size = new System.Drawing.Size(111, 29);
            this.cmbLocked.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 21;
            this.label4.Text = "Zárolva:";
            // 
            // dtpRegDateEnd
            // 
            this.dtpRegDateEnd.AccessibleDescription = "Regisztráció dátumának felső határa";
            this.dtpRegDateEnd.AccessibleName = "Regisztráció dátumának felső határa";
            this.dtpRegDateEnd.Checked = false;
            this.dtpRegDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegDateEnd.Location = new System.Drawing.Point(426, 59);
            this.dtpRegDateEnd.Name = "dtpRegDateEnd";
            this.dtpRegDateEnd.ShowCheckBox = true;
            this.dtpRegDateEnd.Size = new System.Drawing.Size(155, 27);
            this.dtpRegDateEnd.TabIndex = 5;
            this.dtpRegDateEnd.ValueChanged += new System.EventHandler(this.DtpRegDateEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "-";
            // 
            // dtpRegDateStart
            // 
            this.dtpRegDateStart.AccessibleDescription = "Regisztráció dátumának alsó határa";
            this.dtpRegDateStart.AccessibleName = "Regisztráció dátumának alsó határa";
            this.dtpRegDateStart.Checked = false;
            this.dtpRegDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegDateStart.Location = new System.Drawing.Point(244, 59);
            this.dtpRegDateStart.Name = "dtpRegDateStart";
            this.dtpRegDateStart.ShowCheckBox = true;
            this.dtpRegDateStart.Size = new System.Drawing.Size(155, 27);
            this.dtpRegDateStart.TabIndex = 4;
            this.dtpRegDateStart.ValueChanged += new System.EventHandler(this.DtpRegDateStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Regisztráció dátuma:";
            // 
            // txbUName
            // 
            this.txbUName.AccessibleDescription = "Felhasználó neve részben vagy egészben. Üresen hagyva nincs hatása a szűrésre. Ma" +
    "ximum 50 karakter hosszú szöveg adható meg.";
            this.txbUName.AccessibleName = "Név";
            this.txbUName.Location = new System.Drawing.Point(244, 26);
            this.txbUName.MaxLength = 50;
            this.txbUName.Name = "txbUName";
            this.txbUName.Size = new System.Drawing.Size(337, 27);
            this.txbUName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Név:";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AccessibleDescription = "Felhasználók listája";
            this.dgvUsers.AccessibleName = "Felhasználók listája";
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(4, 168);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(0);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1033, 429);
            this.dgvUsers.TabIndex = 16;
            // 
            // UsersPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.grbUserFilter);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1040, 600);
            this.Name = "UsersPanel";
            this.Size = new System.Drawing.Size(1040, 600);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbUserFilter.ResumeLayout(false);
            this.grbUserFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.GroupBox grbUserFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpRegDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLocked;
        private System.Windows.Forms.ComboBox cmbUserGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDeleteFilter;
        private System.Windows.Forms.Button btnReadUser;
        private System.Windows.Forms.Button btnChangePassword;
        private OwnDataGridView dgvUsers;
        private System.Windows.Forms.Button btnUserItSystemPermission;
        private System.Windows.Forms.DateTimePicker dtpRegDateStart;
        private System.Windows.Forms.Label lblNumberOfUsers;
    }
}
