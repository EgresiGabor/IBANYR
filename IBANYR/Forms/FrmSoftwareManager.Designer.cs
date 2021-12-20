
namespace IBANYR
{
    partial class FrmSoftwareManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSoftwareManager));
            this.label22 = new System.Windows.Forms.Label();
            this.lsbSoftwareItSystems = new System.Windows.Forms.ListBox();
            this.btnRemoveItSystem = new System.Windows.Forms.Button();
            this.lblItSystems = new System.Windows.Forms.Label();
            this.lsbItSystems = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbSoftwareComputerDevices = new System.Windows.Forms.ListBox();
            this.lblComputerDevices = new System.Windows.Forms.Label();
            this.lsbComputerDevices = new System.Windows.Forms.ListBox();
            this.dtpScrappingDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOwnerId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txbAName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbAId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtbOtherDescription = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rtbDocLink = new System.Windows.Forms.RichTextBox();
            this.cmbSoftwareProducer = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbSoftwareDesc = new System.Windows.Forms.TextBox();
            this.numLicenseNumber = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpLicenseDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txbProductKey = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCopyProductKey = new System.Windows.Forms.Button();
            this.btnRemoveComputerDevice = new System.Windows.Forms.Button();
            this.btnAddComputerDevice = new System.Windows.Forms.Button();
            this.btnAddItSystem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numLicenseNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(827, 279);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(187, 21);
            this.label22.TabIndex = 107;
            this.label22.Text = "Kapcsolódó rendszerek";
            // 
            // lsbSoftwareItSystems
            // 
            this.lsbSoftwareItSystems.AccessibleDescription = "Kapcsolódó rendszerek listája";
            this.lsbSoftwareItSystems.AccessibleName = "Kapcsolódó rendszerek listája";
            this.lsbSoftwareItSystems.FormattingEnabled = true;
            this.lsbSoftwareItSystems.ItemHeight = 21;
            this.lsbSoftwareItSystems.Location = new System.Drawing.Point(831, 300);
            this.lsbSoftwareItSystems.Name = "lsbSoftwareItSystems";
            this.lsbSoftwareItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSoftwareItSystems.Size = new System.Drawing.Size(200, 151);
            this.lsbSoftwareItSystems.TabIndex = 22;
            // 
            // btnRemoveItSystem
            // 
            this.btnRemoveItSystem.AccessibleDescription = "Rendszer összekapcsolásának törlése";
            this.btnRemoveItSystem.AccessibleName = "Rendszer összekapcsolásának törlése";
            this.btnRemoveItSystem.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnRemoveItSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemoveItSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveItSystem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveItSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveItSystem.Location = new System.Drawing.Point(776, 378);
            this.btnRemoveItSystem.Name = "btnRemoveItSystem";
            this.btnRemoveItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveItSystem.TabIndex = 21;
            this.btnRemoveItSystem.Text = "<";
            this.btnRemoveItSystem.UseVisualStyleBackColor = false;
            this.btnRemoveItSystem.Click += new System.EventHandler(this.BtnRemoveItSystem_Click);
            // 
            // lblItSystems
            // 
            this.lblItSystems.AutoSize = true;
            this.lblItSystems.Location = new System.Drawing.Point(567, 276);
            this.lblItSystems.Name = "lblItSystems";
            this.lblItSystems.Size = new System.Drawing.Size(97, 21);
            this.lblItSystems.TabIndex = 106;
            this.lblItSystems.Text = "Rendszerek";
            // 
            // lsbItSystems
            // 
            this.lsbItSystems.AccessibleDescription = "Rendszerek listája";
            this.lsbItSystems.AccessibleName = "Rendszerek listája";
            this.lsbItSystems.FormattingEnabled = true;
            this.lsbItSystems.ItemHeight = 21;
            this.lsbItSystems.Location = new System.Drawing.Point(571, 300);
            this.lsbItSystems.Name = "lsbItSystems";
            this.lsbItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbItSystems.Size = new System.Drawing.Size(200, 151);
            this.lsbItSystems.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(882, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Mégsem";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOk.Location = new System.Drawing.Point(726, 492);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(827, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 21);
            this.label1.TabIndex = 113;
            this.label1.Text = "Kapcsolódó számítógépek";
            // 
            // lsbSoftwareComputerDevices
            // 
            this.lsbSoftwareComputerDevices.AccessibleDescription = "Kapcsolódó számítógépek listája";
            this.lsbSoftwareComputerDevices.AccessibleName = "Kapcsolódó számítógépek listája";
            this.lsbSoftwareComputerDevices.FormattingEnabled = true;
            this.lsbSoftwareComputerDevices.ItemHeight = 21;
            this.lsbSoftwareComputerDevices.Location = new System.Drawing.Point(831, 120);
            this.lsbSoftwareComputerDevices.Name = "lsbSoftwareComputerDevices";
            this.lsbSoftwareComputerDevices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbSoftwareComputerDevices.Size = new System.Drawing.Size(200, 151);
            this.lsbSoftwareComputerDevices.TabIndex = 18;
            // 
            // lblComputerDevices
            // 
            this.lblComputerDevices.AutoSize = true;
            this.lblComputerDevices.Location = new System.Drawing.Point(567, 96);
            this.lblComputerDevices.Name = "lblComputerDevices";
            this.lblComputerDevices.Size = new System.Drawing.Size(173, 21);
            this.lblComputerDevices.TabIndex = 112;
            this.lblComputerDevices.Text = "Számítógép eszközök";
            // 
            // lsbComputerDevices
            // 
            this.lsbComputerDevices.AccessibleDescription = "Számítógép eszközök listája";
            this.lsbComputerDevices.AccessibleName = "Számítógép eszközök listája";
            this.lsbComputerDevices.FormattingEnabled = true;
            this.lsbComputerDevices.ItemHeight = 21;
            this.lsbComputerDevices.Location = new System.Drawing.Point(570, 120);
            this.lsbComputerDevices.Name = "lsbComputerDevices";
            this.lsbComputerDevices.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbComputerDevices.Size = new System.Drawing.Size(200, 151);
            this.lsbComputerDevices.TabIndex = 15;
            // 
            // dtpScrappingDate
            // 
            this.dtpScrappingDate.AccessibleDescription = "Selejtezve státuszú szoftver selejtezési dátuma kötelezően megadandó!";
            this.dtpScrappingDate.AccessibleName = "Selejtezés dátuma";
            this.dtpScrappingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpScrappingDate.Location = new System.Drawing.Point(209, 175);
            this.dtpScrappingDate.Name = "dtpScrappingDate";
            this.dtpScrappingDate.Size = new System.Drawing.Size(137, 27);
            this.dtpScrappingDate.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 21);
            this.label6.TabIndex = 125;
            this.label6.Text = "Selejtezés dátuma:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AccessibleDescription = "Státusz megadás kötelező! Rögzített értékek közül választhat.";
            this.cmbStatus.AccessibleName = "Szoftver státusza";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(209, 140);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(177, 29);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 21);
            this.label5.TabIndex = 124;
            this.label5.Text = "Szoftver státusza:";
            // 
            // cmbOwnerId
            // 
            this.cmbOwnerId.AccessibleDescription = "Tulajdonos megadása opcionális. A már rögzített fő szervezeti egységek közül vála" +
    "szthat!";
            this.cmbOwnerId.AccessibleName = "Szoftver tulajdonosa";
            this.cmbOwnerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwnerId.FormattingEnabled = true;
            this.cmbOwnerId.Location = new System.Drawing.Point(209, 105);
            this.cmbOwnerId.Name = "cmbOwnerId";
            this.cmbOwnerId.Size = new System.Drawing.Size(348, 29);
            this.cmbOwnerId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 21);
            this.label4.TabIndex = 123;
            this.label4.Text = "Szoftver tulajdonosa:";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.AccessibleDescription = "Szoftver beszerzési dátumának megadása kötelező!";
            this.dtpPurchaseDate.AccessibleName = "Beszerzés ideje";
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(209, 72);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(137, 27);
            this.dtpPurchaseDate.TabIndex = 3;
            this.dtpPurchaseDate.ValueChanged += new System.EventHandler(this.DtpPurchaseDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 122;
            this.label3.Text = "Beszerzés ideje*:";
            // 
            // txbAName
            // 
            this.txbAName.AccessibleDescription = "Szoftver nevének megadása kötelező, és minimum 3 és maximum 50 karakter hosszú le" +
    "het!";
            this.txbAName.AccessibleName = "Szoftver megnevezése";
            this.txbAName.Location = new System.Drawing.Point(209, 39);
            this.txbAName.MaxLength = 50;
            this.txbAName.Name = "txbAName";
            this.txbAName.Size = new System.Drawing.Size(348, 27);
            this.txbAName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 21);
            this.label7.TabIndex = 121;
            this.label7.Text = "Szoftver megnevezése*:";
            // 
            // txbAId
            // 
            this.txbAId.AccessibleDescription = "Az eszközazonosító megadása/módosítása nem lehetséges! Az adatbázisszerver automa" +
    "tikusan generált értéke.";
            this.txbAId.AccessibleName = "Szoftverazonosító";
            this.txbAId.Location = new System.Drawing.Point(209, 6);
            this.txbAId.Name = "txbAId";
            this.txbAId.ReadOnly = true;
            this.txbAId.Size = new System.Drawing.Size(100, 27);
            this.txbAId.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 21);
            this.label8.TabIndex = 120;
            this.label8.Text = "Szoftverazonosító:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 21);
            this.label9.TabIndex = 129;
            this.label9.Text = "Egyéb megjegyzés:";
            // 
            // rtbOtherDescription
            // 
            this.rtbOtherDescription.AccessibleDescription = "Opcionálisan megadható szöveges érték.";
            this.rtbOtherDescription.AccessibleName = "Egyéb megjegyzés";
            this.rtbOtherDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOtherDescription.Location = new System.Drawing.Point(209, 208);
            this.rtbOtherDescription.MaxLength = 1073741823;
            this.rtbOtherDescription.Name = "rtbOtherDescription";
            this.rtbOtherDescription.Size = new System.Drawing.Size(348, 73);
            this.rtbOtherDescription.TabIndex = 7;
            this.rtbOtherDescription.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(568, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(426, 21);
            this.label19.TabIndex = 128;
            this.label19.Text = "Szoftverhez kapcsolódó dokumentumok hivatkozásai:";
            // 
            // rtbDocLink
            // 
            this.rtbDocLink.AccessibleDescription = "Opcionálisan megadható szöveges érték, mely maximum 4000 karakter hosszú lehet.";
            this.rtbDocLink.AccessibleName = "Szoftverhez kapcsolódó dokumentumok hivatkozásai";
            this.rtbDocLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDocLink.Location = new System.Drawing.Point(571, 33);
            this.rtbDocLink.MaxLength = 4000;
            this.rtbDocLink.Name = "rtbDocLink";
            this.rtbDocLink.Size = new System.Drawing.Size(461, 60);
            this.rtbDocLink.TabIndex = 14;
            this.rtbDocLink.Text = "";
            // 
            // cmbSoftwareProducer
            // 
            this.cmbSoftwareProducer.AccessibleDescription = "Szoftver gyártója opcionálisan megadható. Szabadon adható meg maximum 50 karakter" +
    " hosszúságú új gyártónév, vagy szabadon választható valamely rögzített érték.";
            this.cmbSoftwareProducer.AccessibleName = "Gyártó";
            this.cmbSoftwareProducer.FormattingEnabled = true;
            this.cmbSoftwareProducer.Location = new System.Drawing.Point(209, 287);
            this.cmbSoftwareProducer.Name = "cmbSoftwareProducer";
            this.cmbSoftwareProducer.Size = new System.Drawing.Size(266, 29);
            this.cmbSoftwareProducer.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 21);
            this.label12.TabIndex = 131;
            this.label12.Text = "Gyártó:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(74, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 21);
            this.label10.TabIndex = 133;
            this.label10.Text = "Szoftver leírása:";
            // 
            // txbSoftwareDesc
            // 
            this.txbSoftwareDesc.AccessibleDescription = "A szoftver leírása opcionálisan megadható. Maximum 200 karakter hosszú lehet.";
            this.txbSoftwareDesc.AccessibleName = "Szoftver leírása";
            this.txbSoftwareDesc.Location = new System.Drawing.Point(209, 322);
            this.txbSoftwareDesc.MaxLength = 200;
            this.txbSoftwareDesc.Multiline = true;
            this.txbSoftwareDesc.Name = "txbSoftwareDesc";
            this.txbSoftwareDesc.Size = new System.Drawing.Size(348, 67);
            this.txbSoftwareDesc.TabIndex = 9;
            // 
            // numLicenseNumber
            // 
            this.numLicenseNumber.AccessibleDescription = "A szoftverhez tartozó licenszszám opcionálisan megadható. Maximális értéke 1.000." +
    "000 lehet.";
            this.numLicenseNumber.AccessibleName = "Licenszszám";
            this.numLicenseNumber.Location = new System.Drawing.Point(209, 395);
            this.numLicenseNumber.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numLicenseNumber.Name = "numLicenseNumber";
            this.numLicenseNumber.Size = new System.Drawing.Size(137, 27);
            this.numLicenseNumber.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 397);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 21);
            this.label11.TabIndex = 136;
            this.label11.Text = "Licenszszám:";
            // 
            // dtpLicenseDate
            // 
            this.dtpLicenseDate.AccessibleDescription = "A licensz érvényességi dátuma opcionálisan megadható, mely nem lehet korábbi a be" +
    "szerzés dátumánál.";
            this.dtpLicenseDate.AccessibleName = "Licensz érvényessége";
            this.dtpLicenseDate.Checked = false;
            this.dtpLicenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseDate.Location = new System.Drawing.Point(209, 428);
            this.dtpLicenseDate.Name = "dtpLicenseDate";
            this.dtpLicenseDate.ShowCheckBox = true;
            this.dtpLicenseDate.Size = new System.Drawing.Size(154, 27);
            this.dtpLicenseDate.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 433);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 21);
            this.label13.TabIndex = 138;
            this.label13.Text = "Licensz érvényessége:";
            // 
            // txbProductKey
            // 
            this.txbProductKey.AccessibleDescription = "Opcionálisan megadható termékkulcs, mely titkosítva kerül tárolásra. Maximum 150 " +
    "karakter hosszúságú lehet.";
            this.txbProductKey.AccessibleName = "Termékkulcs";
            this.txbProductKey.Location = new System.Drawing.Point(209, 461);
            this.txbProductKey.MaxLength = 150;
            this.txbProductKey.Name = "txbProductKey";
            this.txbProductKey.PasswordChar = '*';
            this.txbProductKey.Size = new System.Drawing.Size(303, 27);
            this.txbProductKey.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(96, 464);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(107, 21);
            this.label21.TabIndex = 140;
            this.label21.Text = "Termékkulcs:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(568, 464);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 141;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // btnCopyProductKey
            // 
            this.btnCopyProductKey.AccessibleDescription = "Termékkulcs másolása";
            this.btnCopyProductKey.AccessibleName = "Termékkulcs másolása";
            this.btnCopyProductKey.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyProductKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopyProductKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyProductKey.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCopyProductKey.FlatAppearance.BorderSize = 0;
            this.btnCopyProductKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCopyProductKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCopyProductKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyProductKey.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCopyProductKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCopyProductKey.Image = global::IBANYR.Properties.Resources.copyBlue;
            this.btnCopyProductKey.Location = new System.Drawing.Point(518, 459);
            this.btnCopyProductKey.Name = "btnCopyProductKey";
            this.btnCopyProductKey.Size = new System.Drawing.Size(30, 30);
            this.btnCopyProductKey.TabIndex = 13;
            this.btnCopyProductKey.UseVisualStyleBackColor = false;
            this.btnCopyProductKey.Click += new System.EventHandler(this.BtnCopyProductKey_Click);
            // 
            // btnRemoveComputerDevice
            // 
            this.btnRemoveComputerDevice.AccessibleDescription = "Számítógép összekapcsolásának törlése";
            this.btnRemoveComputerDevice.AccessibleName = "Számítógép összekapcsolásának törlése";
            this.btnRemoveComputerDevice.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnRemoveComputerDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemoveComputerDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveComputerDevice.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveComputerDevice.FlatAppearance.BorderSize = 0;
            this.btnRemoveComputerDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveComputerDevice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveComputerDevice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveComputerDevice.Location = new System.Drawing.Point(776, 198);
            this.btnRemoveComputerDevice.Name = "btnRemoveComputerDevice";
            this.btnRemoveComputerDevice.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveComputerDevice.TabIndex = 17;
            this.btnRemoveComputerDevice.Text = "<";
            this.btnRemoveComputerDevice.UseVisualStyleBackColor = false;
            this.btnRemoveComputerDevice.Click += new System.EventHandler(this.BtnRemoveComputerDevice_Click);
            // 
            // btnAddComputerDevice
            // 
            this.btnAddComputerDevice.AccessibleDescription = "Számítógép hozzárendelése";
            this.btnAddComputerDevice.AccessibleName = "Számítógép hozzárendelése";
            this.btnAddComputerDevice.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnAddComputerDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddComputerDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddComputerDevice.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddComputerDevice.FlatAppearance.BorderSize = 0;
            this.btnAddComputerDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComputerDevice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddComputerDevice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddComputerDevice.Location = new System.Drawing.Point(776, 152);
            this.btnAddComputerDevice.Name = "btnAddComputerDevice";
            this.btnAddComputerDevice.Size = new System.Drawing.Size(49, 40);
            this.btnAddComputerDevice.TabIndex = 16;
            this.btnAddComputerDevice.Text = ">";
            this.btnAddComputerDevice.UseVisualStyleBackColor = false;
            this.btnAddComputerDevice.Click += new System.EventHandler(this.BtnAddComputerDevice_Click);
            // 
            // btnAddItSystem
            // 
            this.btnAddItSystem.AccessibleDescription = "arrow";
            this.btnAddItSystem.AccessibleName = "Rendszer hozzárendelése";
            this.btnAddItSystem.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnAddItSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddItSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddItSystem.FlatAppearance.BorderSize = 0;
            this.btnAddItSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddItSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddItSystem.Location = new System.Drawing.Point(776, 332);
            this.btnAddItSystem.Name = "btnAddItSystem";
            this.btnAddItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnAddItSystem.TabIndex = 20;
            this.btnAddItSystem.Text = ">";
            this.btnAddItSystem.UseVisualStyleBackColor = false;
            this.btnAddItSystem.Click += new System.EventHandler(this.BtnAddItSystem_Click);
            // 
            // FrmSoftwareManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1044, 544);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnCopyProductKey);
            this.Controls.Add(this.txbProductKey);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dtpLicenseDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numLicenseNumber);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbSoftwareDesc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbSoftwareProducer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rtbOtherDescription);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rtbDocLink);
            this.Controls.Add(this.dtpScrappingDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbOwnerId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbAName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbAId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbSoftwareComputerDevices);
            this.Controls.Add(this.btnRemoveComputerDevice);
            this.Controls.Add(this.btnAddComputerDevice);
            this.Controls.Add(this.lblComputerDevices);
            this.Controls.Add(this.lsbComputerDevices);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lsbSoftwareItSystems);
            this.Controls.Add(this.btnRemoveItSystem);
            this.Controls.Add(this.btnAddItSystem);
            this.Controls.Add(this.lblItSystems);
            this.Controls.Add(this.lsbItSystems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSoftwareManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szoftverkezelő";
            ((System.ComponentModel.ISupportInitialize)(this.numLicenseNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox lsbSoftwareItSystems;
        private System.Windows.Forms.Button btnRemoveItSystem;
        private System.Windows.Forms.Button btnAddItSystem;
        private System.Windows.Forms.Label lblItSystems;
        private System.Windows.Forms.ListBox lsbItSystems;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbSoftwareComputerDevices;
        private System.Windows.Forms.Button btnRemoveComputerDevice;
        private System.Windows.Forms.Button btnAddComputerDevice;
        private System.Windows.Forms.Label lblComputerDevices;
        private System.Windows.Forms.ListBox lsbComputerDevices;
        private System.Windows.Forms.DateTimePicker dtpScrappingDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOwnerId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbAName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbAId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox rtbOtherDescription;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox rtbDocLink;
        private System.Windows.Forms.ComboBox cmbSoftwareProducer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbSoftwareDesc;
        private System.Windows.Forms.NumericUpDown numLicenseNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpLicenseDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbProductKey;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnCopyProductKey;
        private System.Windows.Forms.Label label23;
    }
}