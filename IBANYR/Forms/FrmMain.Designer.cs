
namespace IBANYR
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnStartPage = new System.Windows.Forms.Button();
            this.btnSoftwares = new System.Windows.Forms.Button();
            this.panelActive = new System.Windows.Forms.Panel();
            this.btnSystems = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnHardwares = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsiStartPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSystems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiHardwares = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiSoftwares = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLeft.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.panelTop.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(69)))));
            this.panelLeft.Controls.Add(this.panelMenu);
            this.panelLeft.Controls.Add(this.btnClose);
            this.panelLeft.Controls.Add(this.picMain);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(210, 681);
            this.panelLeft.TabIndex = 7;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.AutoScroll = true;
            this.panelMenu.Controls.Add(this.btnMaintenance);
            this.panelMenu.Controls.Add(this.btnStartPage);
            this.panelMenu.Controls.Add(this.btnSoftwares);
            this.panelMenu.Controls.Add(this.panelActive);
            this.panelMenu.Controls.Add(this.btnSystems);
            this.panelMenu.Controls.Add(this.btnUsers);
            this.panelMenu.Controls.Add(this.btnDepartments);
            this.panelMenu.Controls.Add(this.btnHardwares);
            this.panelMenu.Controls.Add(this.btnLogs);
            this.panelMenu.Location = new System.Drawing.Point(0, 118);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(210, 488);
            this.panelMenu.TabIndex = 10;
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.AccessibleDescription = "Karbantartási napló  főpanel megjelenítésére szolgáló menügomb";
            this.btnMaintenance.AccessibleName = "Karbantartási napló";
            this.btnMaintenance.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnMaintenance.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMaintenance.Image = global::IBANYR.Properties.Resources.maintenance;
            this.btnMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintenance.Location = new System.Drawing.Point(10, 430);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(200, 56);
            this.btnMaintenance.TabIndex = 5;
            this.btnMaintenance.Text = "Karbantartási napló";
            this.btnMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaintenance.UseVisualStyleBackColor = true;
            this.btnMaintenance.Visible = false;
            // 
            // btnStartPage
            // 
            this.btnStartPage.AccessibleDescription = "Kezdőlap főpanel megjelenítésére szolgáló menügomb";
            this.btnStartPage.AccessibleName = "Kezdőlap";
            this.btnStartPage.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartPage.FlatAppearance.BorderSize = 0;
            this.btnStartPage.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnStartPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPage.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartPage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStartPage.Image = global::IBANYR.Properties.Resources.home;
            this.btnStartPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartPage.Location = new System.Drawing.Point(10, 1);
            this.btnStartPage.Name = "btnStartPage";
            this.btnStartPage.Size = new System.Drawing.Size(200, 56);
            this.btnStartPage.TabIndex = 1;
            this.btnStartPage.Text = "Kezdőlap";
            this.btnStartPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartPage.UseVisualStyleBackColor = true;
            this.btnStartPage.Click += new System.EventHandler(this.MainButton_Click);
            this.btnStartPage.Enter += new System.EventHandler(this.MainButton_OnMouseEnter);
            this.btnStartPage.MouseEnter += new System.EventHandler(this.MainButton_OnMouseEnter);
            this.btnStartPage.MouseLeave += new System.EventHandler(this.MainButton_OnMouseLeave);
            // 
            // btnSoftwares
            // 
            this.btnSoftwares.AccessibleDescription = "Szoftver leltár főpanel megjelenítésére szolgáló menügomb";
            this.btnSoftwares.AccessibleName = "Szoftver leltár";
            this.btnSoftwares.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnSoftwares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoftwares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSoftwares.FlatAppearance.BorderSize = 0;
            this.btnSoftwares.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSoftwares.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSoftwares.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSoftwares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoftwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSoftwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSoftwares.Image = global::IBANYR.Properties.Resources.software;
            this.btnSoftwares.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoftwares.Location = new System.Drawing.Point(10, 372);
            this.btnSoftwares.Name = "btnSoftwares";
            this.btnSoftwares.Size = new System.Drawing.Size(200, 56);
            this.btnSoftwares.TabIndex = 4;
            this.btnSoftwares.Text = "Szoftver leltár";
            this.btnSoftwares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoftwares.UseVisualStyleBackColor = true;
            this.btnSoftwares.Visible = false;
            // 
            // panelActive
            // 
            this.panelActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panelActive.Location = new System.Drawing.Point(0, 0);
            this.panelActive.Name = "panelActive";
            this.panelActive.Size = new System.Drawing.Size(10, 57);
            this.panelActive.TabIndex = 15;
            // 
            // btnSystems
            // 
            this.btnSystems.AccessibleDescription = "Rendszerek főpanel megjelenítésére szolgáló menügomb";
            this.btnSystems.AccessibleName = "Rendszerek";
            this.btnSystems.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnSystems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystems.FlatAppearance.BorderSize = 0;
            this.btnSystems.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnSystems.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSystems.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSystems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystems.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSystems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSystems.Image = global::IBANYR.Properties.Resources.system;
            this.btnSystems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystems.Location = new System.Drawing.Point(10, 310);
            this.btnSystems.Name = "btnSystems";
            this.btnSystems.Size = new System.Drawing.Size(200, 56);
            this.btnSystems.TabIndex = 2;
            this.btnSystems.Text = "Rendszerek";
            this.btnSystems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystems.UseVisualStyleBackColor = true;
            this.btnSystems.Visible = false;
            // 
            // btnUsers
            // 
            this.btnUsers.AccessibleDescription = "Felhasználók főpanel megjelenítésére szolgáló menügomb";
            this.btnUsers.AccessibleName = "Felhasználók";
            this.btnUsers.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUsers.Image = global::IBANYR.Properties.Resources.users;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(10, 63);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(200, 56);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Felhasználók";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Visible = false;
            // 
            // btnDepartments
            // 
            this.btnDepartments.AccessibleDescription = "Szervezeti egységek főpanel megjelenítésére szolgáló menügomb";
            this.btnDepartments.AccessibleName = "Szervezeti egységek";
            this.btnDepartments.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDepartments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDepartments.FlatAppearance.BorderSize = 0;
            this.btnDepartments.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDepartments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDepartments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepartments.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDepartments.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDepartments.Image = global::IBANYR.Properties.Resources.company;
            this.btnDepartments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartments.Location = new System.Drawing.Point(10, 125);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(200, 56);
            this.btnDepartments.TabIndex = 7;
            this.btnDepartments.Text = "Szervezeti egységek";
            this.btnDepartments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Visible = false;
            // 
            // btnHardwares
            // 
            this.btnHardwares.AccessibleDescription = "Hardver leltár főpanel megjelenítésére szolgáló menügomb";
            this.btnHardwares.AccessibleName = "Hardver leltár";
            this.btnHardwares.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnHardwares.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHardwares.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHardwares.FlatAppearance.BorderSize = 0;
            this.btnHardwares.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnHardwares.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHardwares.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHardwares.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHardwares.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHardwares.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHardwares.Image = global::IBANYR.Properties.Resources.computer;
            this.btnHardwares.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHardwares.Location = new System.Drawing.Point(10, 248);
            this.btnHardwares.Name = "btnHardwares";
            this.btnHardwares.Size = new System.Drawing.Size(200, 56);
            this.btnHardwares.TabIndex = 3;
            this.btnHardwares.Text = "Hardver leltár";
            this.btnHardwares.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHardwares.UseVisualStyleBackColor = true;
            this.btnHardwares.Visible = false;
            // 
            // btnLogs
            // 
            this.btnLogs.AccessibleDescription = "Naplózás főpanel megjelenítésére szolgáló menügomb";
            this.btnLogs.AccessibleName = "Naplózás";
            this.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogs.FlatAppearance.BorderSize = 0;
            this.btnLogs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnLogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogs.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLogs.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogs.Image = global::IBANYR.Properties.Resources.logs;
            this.btnLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.Location = new System.Drawing.Point(10, 187);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(200, 56);
            this.btnLogs.TabIndex = 8;
            this.btnLogs.Text = "Naplózás";
            this.btnLogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = "Kilépés";
            this.btnClose.AccessibleName = "Kilépés";
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(10, 612);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 56);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Kilépés";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.MainButton_OnMouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.MainButton_OnMouseLeave);
            // 
            // picMain
            // 
            this.picMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picMain.BackgroundImage = global::IBANYR.Properties.Resources.shield_medium;
            this.picMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMain.Location = new System.Drawing.Point(3, 3);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(201, 109);
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.btnConfiguration);
            this.panelTop.Controls.Add(this.btnAbout);
            this.panelTop.Controls.Add(this.btnPassword);
            this.panelTop.Controls.Add(this.lblUser);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(210, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1054, 42);
            this.panelTop.TabIndex = 9;
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.AccessibleDescription = "A beállítások szerkesztésére szolgáló ablak megnyitása";
            this.btnConfiguration.AccessibleName = "Beállítások";
            this.btnConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfiguration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguration.Enabled = false;
            this.btnConfiguration.FlatAppearance.BorderSize = 0;
            this.btnConfiguration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfiguration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguration.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfiguration.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnConfiguration.Image = global::IBANYR.Properties.Resources.config;
            this.btnConfiguration.Location = new System.Drawing.Point(695, 0);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(42, 42);
            this.btnConfiguration.TabIndex = 9;
            this.btnConfiguration.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Visible = false;
            this.btnConfiguration.Click += new System.EventHandler(this.BtnConfiguration_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.AccessibleDescription = "Program névjegyének megnyitása";
            this.btnAbout.AccessibleName = "Program névjegye";
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAbout.Image = global::IBANYR.Properties.Resources.about;
            this.btnAbout.Location = new System.Drawing.Point(743, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(42, 42);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.AccessibleDescription = "Jelszó módosítására szolgáló ablak megnyitása";
            this.btnPassword.AccessibleName = "Jelszó módosítása";
            this.btnPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassword.FlatAppearance.BorderSize = 0;
            this.btnPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPassword.Image = global::IBANYR.Properties.Resources.key;
            this.btnPassword.Location = new System.Drawing.Point(791, 0);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(42, 42);
            this.btnPassword.TabIndex = 11;
            this.btnPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPassword.UseVisualStyleBackColor = true;
            this.btnPassword.Click += new System.EventHandler(this.BtnPassword_Click);
            // 
            // lblUser
            // 
            this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUser.Location = new System.Drawing.Point(983, 13);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(59, 19);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "lblUser";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(512, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kezdőlap";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "A program továbbra is fut! Az ikonra duplán kattintva visszanyithatja!";
            this.notifyIcon.BalloonTipTitle = "Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiStartPage,
            this.tsiSystems,
            this.tsiHardwares,
            this.tsiSoftwares,
            this.tsiMaintenance,
            this.tsiUsers,
            this.tsiDepartments,
            this.tsiLogs,
            this.tsiClose});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(227, 220);
            // 
            // tsiStartPage
            // 
            this.tsiStartPage.Image = global::IBANYR.Properties.Resources.home_tiny_dark;
            this.tsiStartPage.Name = "tsiStartPage";
            this.tsiStartPage.Size = new System.Drawing.Size(226, 24);
            this.tsiStartPage.Text = "Kezdőlap";
            // 
            // tsiSystems
            // 
            this.tsiSystems.Enabled = false;
            this.tsiSystems.Image = global::IBANYR.Properties.Resources.system_tiny_dark;
            this.tsiSystems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiSystems.Name = "tsiSystems";
            this.tsiSystems.Size = new System.Drawing.Size(226, 24);
            this.tsiSystems.Text = "Rendszerek";
            this.tsiSystems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiSystems.Visible = false;
            // 
            // tsiHardwares
            // 
            this.tsiHardwares.Enabled = false;
            this.tsiHardwares.Image = global::IBANYR.Properties.Resources.computer_tiny_dark;
            this.tsiHardwares.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiHardwares.Name = "tsiHardwares";
            this.tsiHardwares.Size = new System.Drawing.Size(226, 24);
            this.tsiHardwares.Text = "Hardver leltár";
            this.tsiHardwares.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiHardwares.Visible = false;
            // 
            // tsiSoftwares
            // 
            this.tsiSoftwares.Enabled = false;
            this.tsiSoftwares.Image = global::IBANYR.Properties.Resources.software_tiny_dark;
            this.tsiSoftwares.Name = "tsiSoftwares";
            this.tsiSoftwares.Size = new System.Drawing.Size(226, 24);
            this.tsiSoftwares.Text = "Szoftver leltár";
            // 
            // tsiMaintenance
            // 
            this.tsiMaintenance.Enabled = false;
            this.tsiMaintenance.Image = global::IBANYR.Properties.Resources.maintenance_tiny_dark;
            this.tsiMaintenance.Name = "tsiMaintenance";
            this.tsiMaintenance.Size = new System.Drawing.Size(226, 24);
            this.tsiMaintenance.Text = "Karbantartási napló";
            // 
            // tsiUsers
            // 
            this.tsiUsers.Enabled = false;
            this.tsiUsers.Image = global::IBANYR.Properties.Resources.users_tiny_dark;
            this.tsiUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiUsers.Name = "tsiUsers";
            this.tsiUsers.Size = new System.Drawing.Size(226, 24);
            this.tsiUsers.Text = "Felhasználók";
            this.tsiUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiUsers.Visible = false;
            // 
            // tsiDepartments
            // 
            this.tsiDepartments.Enabled = false;
            this.tsiDepartments.Image = global::IBANYR.Properties.Resources.company_tiny_dark;
            this.tsiDepartments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiDepartments.Name = "tsiDepartments";
            this.tsiDepartments.Size = new System.Drawing.Size(226, 24);
            this.tsiDepartments.Text = "Szervezeti egységek";
            this.tsiDepartments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiDepartments.Visible = false;
            // 
            // tsiLogs
            // 
            this.tsiLogs.Enabled = false;
            this.tsiLogs.Image = global::IBANYR.Properties.Resources.logs_tiny_dark;
            this.tsiLogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiLogs.Name = "tsiLogs";
            this.tsiLogs.Size = new System.Drawing.Size(226, 24);
            this.tsiLogs.Text = "Naplózás";
            this.tsiLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiLogs.Visible = false;
            // 
            // tsiClose
            // 
            this.tsiClose.Image = global::IBANYR.Properties.Resources.close_tiny_dark;
            this.tsiClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsiClose.Name = "tsiClose";
            this.tsiClose.Size = new System.Drawing.Size(226, 24);
            this.tsiClose.Text = "Kilépés";
            this.tsiClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informatikai Biztonsági Adminisztratív Nyilvántartó Rendszer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.panelLeft.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnSystems;
        private System.Windows.Forms.Button btnHardwares;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnDepartments;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelActive;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnStartPage;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsiClose;
        private System.Windows.Forms.ToolStripMenuItem tsiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsiDepartments;
        private System.Windows.Forms.ToolStripMenuItem tsiLogs;
        private System.Windows.Forms.ToolStripMenuItem tsiSystems;
        private System.Windows.Forms.ToolStripMenuItem tsiHardwares;
        private System.Windows.Forms.Button btnSoftwares;
        private System.Windows.Forms.ToolStripMenuItem tsiSoftwares;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.ToolStripMenuItem tsiMaintenance;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.ToolStripMenuItem tsiStartPage;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnConfiguration;
        //private ConfigPanel configPanel;
    }
}

