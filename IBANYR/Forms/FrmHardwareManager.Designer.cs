
namespace IBANYR
{
    partial class FrmHardwareManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHardwareManager));
            this.txbAId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbAName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbOwnerId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rtbDocLink = new System.Windows.Forms.RichTextBox();
            this.dtpScrappingDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbOtherDescription = new System.Windows.Forms.RichTextBox();
            this.cmbUId = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbPlace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbSerialNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numWarrantyYears = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbHardwareType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chbPortable = new System.Windows.Forms.CheckBox();
            this.chbVirtual = new System.Windows.Forms.CheckBox();
            this.grbNetworkDatas = new System.Windows.Forms.GroupBox();
            this.btnDeleteNIC = new System.Windows.Forms.Button();
            this.btnReadNIC = new System.Windows.Forms.Button();
            this.btnAddNIC = new System.Windows.Forms.Button();
            this.btnEditNIC = new System.Windows.Forms.Button();
            this.lsbNICs = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txbHostName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbProcessor = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txbOtherComponent = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chbEncrypted = new System.Windows.Forms.CheckBox();
            this.txbRecoveryKey = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lsbHardwareItSystems = new System.Windows.Forms.ListBox();
            this.btnRemoveItSystem = new System.Windows.Forms.Button();
            this.btnAddItSystem = new System.Windows.Forms.Button();
            this.lblItSystems = new System.Windows.Forms.Label();
            this.lsbItSystems = new System.Windows.Forms.ListBox();
            this.btnCopyRecoveryKey = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.numStorageCapacity = new IBANYR.NumericUpDownDynamicUnit();
            this.numRam = new IBANYR.NumericUpDownDynamicUnit();
            ((System.ComponentModel.ISupportInitialize)(this.numWarrantyYears)).BeginInit();
            this.grbNetworkDatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStorageCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRam)).BeginInit();
            this.SuspendLayout();
            // 
            // txbAId
            // 
            this.txbAId.AccessibleDescription = "A hardverazonosító megadása/módosítása nem lehetséges! Az adatbázisszerver automa" +
    "tikusan generált értéke.";
            this.txbAId.AccessibleName = "Hardverazonosító";
            this.txbAId.Location = new System.Drawing.Point(194, 6);
            this.txbAId.Name = "txbAId";
            this.txbAId.ReadOnly = true;
            this.txbAId.Size = new System.Drawing.Size(100, 27);
            this.txbAId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 21);
            this.label1.TabIndex = 41;
            this.label1.Text = "Hardverazonosító:";
            // 
            // txbAName
            // 
            this.txbAName.AccessibleDescription = "Hardver nevének megadása kötelező, és minimum 3 és maximum 50 karakter hosszú leh" +
    "et!";
            this.txbAName.AccessibleName = "Hardver neve";
            this.txbAName.Location = new System.Drawing.Point(194, 39);
            this.txbAName.MaxLength = 50;
            this.txbAName.Name = "txbAName";
            this.txbAName.Size = new System.Drawing.Size(360, 27);
            this.txbAName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 21);
            this.label2.TabIndex = 43;
            this.label2.Text = "Hardver neve*:";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.AccessibleDescription = "Hardver beszerzési dátumának megadása kötelező!";
            this.dtpPurchaseDate.AccessibleName = "Beszerzés ideje";
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(194, 72);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(137, 27);
            this.dtpPurchaseDate.TabIndex = 3;
            this.dtpPurchaseDate.ValueChanged += new System.EventHandler(this.DtpPurchaseDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 21);
            this.label3.TabIndex = 44;
            this.label3.Text = "Beszerzés ideje*:";
            // 
            // cmbOwnerId
            // 
            this.cmbOwnerId.AccessibleDescription = "Tulajdonos megadása opcionális. A már rögzített fő szervezeti egységek közül vála" +
    "szthat!";
            this.cmbOwnerId.AccessibleName = "Hardver tulajdonosa";
            this.cmbOwnerId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOwnerId.FormattingEnabled = true;
            this.cmbOwnerId.Location = new System.Drawing.Point(194, 105);
            this.cmbOwnerId.Name = "cmbOwnerId";
            this.cmbOwnerId.Size = new System.Drawing.Size(360, 29);
            this.cmbOwnerId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 21);
            this.label4.TabIndex = 47;
            this.label4.Text = "Hardver tulajdonosa:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AccessibleDescription = "Státusz megadás kötelező! Rögzített értékek közül választhat.";
            this.cmbStatus.AccessibleName = "Hardver státusza";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(194, 140);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(177, 29);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 21);
            this.label5.TabIndex = 49;
            this.label5.Text = "Hardver státusza:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(569, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(427, 21);
            this.label19.TabIndex = 60;
            this.label19.Text = "Hardverhez kapcsolódó dokumentumok hivatkozásai:";
            // 
            // rtbDocLink
            // 
            this.rtbDocLink.AccessibleDescription = "Opcionálisan megadható szöveges érték, mely maximum 4000 karakter hosszú lehet.";
            this.rtbDocLink.AccessibleName = "Hardverhez kapcsolódó dokumentumok hivatkozásai";
            this.rtbDocLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDocLink.Location = new System.Drawing.Point(572, 33);
            this.rtbDocLink.MaxLength = 4000;
            this.rtbDocLink.Name = "rtbDocLink";
            this.rtbDocLink.Size = new System.Drawing.Size(460, 49);
            this.rtbDocLink.TabIndex = 22;
            this.rtbDocLink.Text = "";
            // 
            // dtpScrappingDate
            // 
            this.dtpScrappingDate.AccessibleDescription = "Selejtezve státuszú hardver selejtezési dátuma kötelezően megadandó!";
            this.dtpScrappingDate.AccessibleName = "Selejtezés dátuma";
            this.dtpScrappingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpScrappingDate.Location = new System.Drawing.Point(194, 175);
            this.dtpScrappingDate.Name = "dtpScrappingDate";
            this.dtpScrappingDate.Size = new System.Drawing.Size(137, 27);
            this.dtpScrappingDate.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 21);
            this.label6.TabIndex = 61;
            this.label6.Text = "Selejtezés dátuma:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(569, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 21);
            this.label7.TabIndex = 64;
            this.label7.Text = "Egyéb megjegyzés:";
            // 
            // rtbOtherDescription
            // 
            this.rtbOtherDescription.AccessibleDescription = "Opcionálisan megadható szöveges érték.";
            this.rtbOtherDescription.AccessibleName = "Egyéb megjegyzés";
            this.rtbOtherDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOtherDescription.Location = new System.Drawing.Point(572, 109);
            this.rtbOtherDescription.MaxLength = 1073741823;
            this.rtbOtherDescription.Name = "rtbOtherDescription";
            this.rtbOtherDescription.Size = new System.Drawing.Size(460, 49);
            this.rtbOtherDescription.TabIndex = 23;
            this.rtbOtherDescription.Text = "";
            // 
            // cmbUId
            // 
            this.cmbUId.AccessibleDescription = "Hardver használója opcionálisan megadható. A rögzített felhasználók közül választ" +
    "hat.";
            this.cmbUId.AccessibleName = "Hardver használója";
            this.cmbUId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUId.FormattingEnabled = true;
            this.cmbUId.Location = new System.Drawing.Point(194, 208);
            this.cmbUId.Name = "cmbUId";
            this.cmbUId.Size = new System.Drawing.Size(360, 29);
            this.cmbUId.TabIndex = 7;
            this.cmbUId.SelectedIndexChanged += new System.EventHandler(this.CmbUId_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 21);
            this.label8.TabIndex = 66;
            this.label8.Text = "Hardver használója:";
            // 
            // txbPlace
            // 
            this.txbPlace.AccessibleDescription = "Hardver helye opcionálisan megadható. Maximum 50 karakter hosszú lehet.";
            this.txbPlace.AccessibleName = "Hardver helye";
            this.txbPlace.Location = new System.Drawing.Point(194, 243);
            this.txbPlace.MaxLength = 50;
            this.txbPlace.Name = "txbPlace";
            this.txbPlace.Size = new System.Drawing.Size(360, 27);
            this.txbPlace.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(66, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 21);
            this.label9.TabIndex = 68;
            this.label9.Text = "Hardver helye:";
            // 
            // txbSerialNumber
            // 
            this.txbSerialNumber.AccessibleDescription = "A hardver sorozatszáma kötelezően megadandó érték, melynek maximális hossza 50 ka" +
    "rakter lehet.";
            this.txbSerialNumber.AccessibleName = "Sorozatszám";
            this.txbSerialNumber.Location = new System.Drawing.Point(194, 276);
            this.txbSerialNumber.MaxLength = 50;
            this.txbSerialNumber.Name = "txbSerialNumber";
            this.txbSerialNumber.Size = new System.Drawing.Size(360, 27);
            this.txbSerialNumber.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 21);
            this.label10.TabIndex = 70;
            this.label10.Text = "Sorozatszám*:";
            // 
            // numWarrantyYears
            // 
            this.numWarrantyYears.AccessibleDescription = "A hardverre nyújtott garanciaévek száma opcionálisan megadható, maximális értéke " +
    "255 lehet.";
            this.numWarrantyYears.AccessibleName = "Garanciaévek száma";
            this.numWarrantyYears.Location = new System.Drawing.Point(194, 309);
            this.numWarrantyYears.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numWarrantyYears.Name = "numWarrantyYears";
            this.numWarrantyYears.Size = new System.Drawing.Size(137, 27);
            this.numWarrantyYears.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 21);
            this.label11.TabIndex = 72;
            this.label11.Text = "Garanciaévek száma:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.AccessibleDescription = "A hardver kategóriája kötelezően megadandó. Szabadon adható meg maximum 50 karakt" +
    "er hosszúságú új kategórianév, vagy szabadon választható valamely rögzített érté" +
    "k.";
            this.cmbCategory.AccessibleName = "Kategória";
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(194, 342);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(266, 29);
            this.cmbCategory.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 21);
            this.label12.TabIndex = 74;
            this.label12.Text = "Kategória*:";
            // 
            // cmbHardwareType
            // 
            this.cmbHardwareType.AccessibleDescription = "A hardver típusa kötelezően kiválasztandó. A választásnak megfelelően kitöltendőe" +
    "k a további hardveradatok.";
            this.cmbHardwareType.AccessibleName = "Hardver típusa";
            this.cmbHardwareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHardwareType.FormattingEnabled = true;
            this.cmbHardwareType.Location = new System.Drawing.Point(194, 377);
            this.cmbHardwareType.Name = "cmbHardwareType";
            this.cmbHardwareType.Size = new System.Drawing.Size(266, 29);
            this.cmbHardwareType.TabIndex = 12;
            this.cmbHardwareType.SelectedIndexChanged += new System.EventHandler(this.CmbHardwareType_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 380);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 21);
            this.label13.TabIndex = 76;
            this.label13.Text = "Hardver típusa*:";
            // 
            // chbPortable
            // 
            this.chbPortable.AccessibleDescription = "A mező kijelölésével állítja be, hogy a hardver hordozható.";
            this.chbPortable.AccessibleName = "Hordozható";
            this.chbPortable.AutoSize = true;
            this.chbPortable.Location = new System.Drawing.Point(86, 412);
            this.chbPortable.Name = "chbPortable";
            this.chbPortable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbPortable.Size = new System.Drawing.Size(195, 25);
            this.chbPortable.TabIndex = 13;
            this.chbPortable.Text = "Hordozható (X - Igen)";
            this.chbPortable.UseVisualStyleBackColor = true;
            // 
            // chbVirtual
            // 
            this.chbVirtual.AccessibleDescription = "A mező kijelölésével állítja be, hogy a hardver virtuális.";
            this.chbVirtual.AccessibleName = "Virtuális";
            this.chbVirtual.AutoSize = true;
            this.chbVirtual.Location = new System.Drawing.Point(314, 412);
            this.chbVirtual.Name = "chbVirtual";
            this.chbVirtual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbVirtual.Size = new System.Drawing.Size(162, 25);
            this.chbVirtual.TabIndex = 14;
            this.chbVirtual.Text = "Virtuális (X - Igen)";
            this.chbVirtual.UseVisualStyleBackColor = true;
            // 
            // grbNetworkDatas
            // 
            this.grbNetworkDatas.Controls.Add(this.btnDeleteNIC);
            this.grbNetworkDatas.Controls.Add(this.btnReadNIC);
            this.grbNetworkDatas.Controls.Add(this.btnAddNIC);
            this.grbNetworkDatas.Controls.Add(this.btnEditNIC);
            this.grbNetworkDatas.Controls.Add(this.lsbNICs);
            this.grbNetworkDatas.Controls.Add(this.label15);
            this.grbNetworkDatas.Controls.Add(this.txbHostName);
            this.grbNetworkDatas.Controls.Add(this.label14);
            this.grbNetworkDatas.Enabled = false;
            this.grbNetworkDatas.Location = new System.Drawing.Point(573, 164);
            this.grbNetworkDatas.Name = "grbNetworkDatas";
            this.grbNetworkDatas.Size = new System.Drawing.Size(459, 207);
            this.grbNetworkDatas.TabIndex = 24;
            this.grbNetworkDatas.TabStop = false;
            this.grbNetworkDatas.Text = "Hálózati adatok";
            // 
            // btnDeleteNIC
            // 
            this.btnDeleteNIC.AccessibleDescription = "Hálózati adapter törlése";
            this.btnDeleteNIC.AccessibleName = "Hálózati adapter törlése";
            this.btnDeleteNIC.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteNIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteNIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteNIC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteNIC.FlatAppearance.BorderSize = 0;
            this.btnDeleteNIC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteNIC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDeleteNIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteNIC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteNIC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteNIC.Image = global::IBANYR.Properties.Resources.deleteBlue;
            this.btnDeleteNIC.Location = new System.Drawing.Point(423, 59);
            this.btnDeleteNIC.Name = "btnDeleteNIC";
            this.btnDeleteNIC.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteNIC.TabIndex = 29;
            this.btnDeleteNIC.UseVisualStyleBackColor = false;
            this.btnDeleteNIC.Click += new System.EventHandler(this.BtnDeleteNIC_Click);
            // 
            // btnReadNIC
            // 
            this.btnReadNIC.AccessibleDescription = "Hálózati adapter adatainak megtekintése";
            this.btnReadNIC.AccessibleName = "Hálózati adapter adatainak megtekintése";
            this.btnReadNIC.BackColor = System.Drawing.Color.Transparent;
            this.btnReadNIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnReadNIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadNIC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnReadNIC.FlatAppearance.BorderSize = 0;
            this.btnReadNIC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnReadNIC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnReadNIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadNIC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnReadNIC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReadNIC.Image = global::IBANYR.Properties.Resources.seeBlue;
            this.btnReadNIC.Location = new System.Drawing.Point(315, 59);
            this.btnReadNIC.Name = "btnReadNIC";
            this.btnReadNIC.Size = new System.Drawing.Size(30, 30);
            this.btnReadNIC.TabIndex = 26;
            this.btnReadNIC.UseVisualStyleBackColor = false;
            this.btnReadNIC.Click += new System.EventHandler(this.BtnReadNIC_Click);
            // 
            // btnAddNIC
            // 
            this.btnAddNIC.AccessibleDescription = "Hálózati adapter hozzáadása";
            this.btnAddNIC.AccessibleName = "Hálózati adapter hozzáadása";
            this.btnAddNIC.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddNIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNIC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddNIC.FlatAppearance.BorderSize = 0;
            this.btnAddNIC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAddNIC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAddNIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNIC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddNIC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddNIC.Image = global::IBANYR.Properties.Resources.addBlue;
            this.btnAddNIC.Location = new System.Drawing.Point(387, 59);
            this.btnAddNIC.Name = "btnAddNIC";
            this.btnAddNIC.Size = new System.Drawing.Size(30, 30);
            this.btnAddNIC.TabIndex = 28;
            this.btnAddNIC.UseVisualStyleBackColor = false;
            this.btnAddNIC.Click += new System.EventHandler(this.BtnAddNIC_Click);
            // 
            // btnEditNIC
            // 
            this.btnEditNIC.AccessibleDescription = "Hálózati adapter adatainak módosítása";
            this.btnEditNIC.AccessibleName = "Hálózati adapter adatainak módosítása";
            this.btnEditNIC.BackColor = System.Drawing.Color.Transparent;
            this.btnEditNIC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditNIC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditNIC.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnEditNIC.FlatAppearance.BorderSize = 0;
            this.btnEditNIC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEditNIC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEditNIC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNIC.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditNIC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditNIC.Image = global::IBANYR.Properties.Resources.editBlue;
            this.btnEditNIC.Location = new System.Drawing.Point(351, 59);
            this.btnEditNIC.Name = "btnEditNIC";
            this.btnEditNIC.Size = new System.Drawing.Size(30, 30);
            this.btnEditNIC.TabIndex = 27;
            this.btnEditNIC.UseVisualStyleBackColor = false;
            this.btnEditNIC.Click += new System.EventHandler(this.BtnEditNIC_Click);
            // 
            // lsbNICs
            // 
            this.lsbNICs.AccessibleDescription = "Hálózati adapterek listája";
            this.lsbNICs.AccessibleName = "Hálózati adapterek listája";
            this.lsbNICs.FormattingEnabled = true;
            this.lsbNICs.ItemHeight = 21;
            this.lsbNICs.Location = new System.Drawing.Point(10, 93);
            this.lsbNICs.Name = "lsbNICs";
            this.lsbNICs.Size = new System.Drawing.Size(443, 109);
            this.lsbNICs.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(165, 21);
            this.label15.TabIndex = 82;
            this.label15.Text = "Hálózati adapterek:";
            // 
            // txbHostName
            // 
            this.txbHostName.AccessibleDescription = "A hoszt név megadása kötelező, és maximum 50 karakter hosszú lehet!";
            this.txbHostName.AccessibleName = "Hoszt név";
            this.txbHostName.Location = new System.Drawing.Point(107, 26);
            this.txbHostName.MaxLength = 50;
            this.txbHostName.Name = "txbHostName";
            this.txbHostName.Size = new System.Drawing.Size(346, 27);
            this.txbHostName.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 21);
            this.label14.TabIndex = 81;
            this.label14.Text = "Hoszt név*:";
            // 
            // txbProcessor
            // 
            this.txbProcessor.AccessibleDescription = "Opcionálisan megadható szöveges érték, mely maximum 50 karakter hosszú lehet.";
            this.txbProcessor.AccessibleName = "Processzor";
            this.txbProcessor.Enabled = false;
            this.txbProcessor.Location = new System.Drawing.Point(194, 443);
            this.txbProcessor.MaxLength = 50;
            this.txbProcessor.Name = "txbProcessor";
            this.txbProcessor.Size = new System.Drawing.Size(360, 27);
            this.txbProcessor.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(96, 446);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 21);
            this.label16.TabIndex = 81;
            this.label16.Text = "Processzor:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(35, 478);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(153, 21);
            this.label17.TabIndex = 83;
            this.label17.Text = "RAM mérete (MB):";
            // 
            // txbOtherComponent
            // 
            this.txbOtherComponent.AccessibleDescription = "Az opcionálisan megadható szöveg maximum 200 karakter hosszú lehet.";
            this.txbOtherComponent.AccessibleName = "Egyéb komponensek";
            this.txbOtherComponent.Enabled = false;
            this.txbOtherComponent.Location = new System.Drawing.Point(194, 509);
            this.txbOtherComponent.MaxLength = 200;
            this.txbOtherComponent.Multiline = true;
            this.txbOtherComponent.Name = "txbOtherComponent";
            this.txbOtherComponent.Size = new System.Drawing.Size(360, 62);
            this.txbOtherComponent.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 512);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(175, 21);
            this.label18.TabIndex = 86;
            this.label18.Text = "Egyéb komponensek:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 579);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(179, 21);
            this.label20.TabIndex = 87;
            this.label20.Text = "Tárolókapacitás (MB):";
            // 
            // chbEncrypted
            // 
            this.chbEncrypted.AccessibleDescription = "A mező kijelölésével állítja be, hogy az adattároló típusú hardver titkosított.";
            this.chbEncrypted.AccessibleName = "Titkosított";
            this.chbEncrypted.AutoSize = true;
            this.chbEncrypted.Location = new System.Drawing.Point(375, 579);
            this.chbEncrypted.Name = "chbEncrypted";
            this.chbEncrypted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbEncrypted.Size = new System.Drawing.Size(179, 25);
            this.chbEncrypted.TabIndex = 19;
            this.chbEncrypted.Text = "Titkosított (X - Igen)";
            this.chbEncrypted.UseVisualStyleBackColor = true;
            // 
            // txbRecoveryKey
            // 
            this.txbRecoveryKey.AccessibleDescription = "A megadott kulcs titkosítva kerül letárolásra. A megadható kulcs maximális hossza" +
    " 150 karakter.";
            this.txbRecoveryKey.AccessibleName = "Helyreállítási kulcs";
            this.txbRecoveryKey.Location = new System.Drawing.Point(194, 610);
            this.txbRecoveryKey.MaxLength = 150;
            this.txbRecoveryKey.Name = "txbRecoveryKey";
            this.txbRecoveryKey.PasswordChar = '*';
            this.txbRecoveryKey.Size = new System.Drawing.Size(303, 27);
            this.txbRecoveryKey.TabIndex = 20;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 613);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(149, 21);
            this.label21.TabIndex = 91;
            this.label21.Text = "Helyreállítási kulcs:";
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
            this.btnCancel.Location = new System.Drawing.Point(882, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 36;
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
            this.btnOk.Location = new System.Drawing.Point(726, 611);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 35;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(828, 380);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(187, 21);
            this.label22.TabIndex = 99;
            this.label22.Text = "Kapcsolódó rendszerek";
            // 
            // lsbHardwareItSystems
            // 
            this.lsbHardwareItSystems.AccessibleDescription = "Hardverhez kapcsolódó rendszerek listája";
            this.lsbHardwareItSystems.AccessibleName = "Hardverhez kapcsolódó rendszerek listája";
            this.lsbHardwareItSystems.FormattingEnabled = true;
            this.lsbHardwareItSystems.ItemHeight = 21;
            this.lsbHardwareItSystems.Location = new System.Drawing.Point(832, 401);
            this.lsbHardwareItSystems.Name = "lsbHardwareItSystems";
            this.lsbHardwareItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbHardwareItSystems.Size = new System.Drawing.Size(200, 172);
            this.lsbHardwareItSystems.TabIndex = 34;
            // 
            // btnRemoveItSystem
            // 
            this.btnRemoveItSystem.AccessibleDescription = "Rendszer összekapcsolásának törlése";
            this.btnRemoveItSystem.AccessibleName = "Rendszer összekapcsolásának törlése";
            this.btnRemoveItSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemoveItSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveItSystem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveItSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveItSystem.Location = new System.Drawing.Point(778, 494);
            this.btnRemoveItSystem.Name = "btnRemoveItSystem";
            this.btnRemoveItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveItSystem.TabIndex = 33;
            this.btnRemoveItSystem.Text = "<";
            this.btnRemoveItSystem.UseVisualStyleBackColor = false;
            this.btnRemoveItSystem.Click += new System.EventHandler(this.BtnRemoveItSystem_Click);
            // 
            // btnAddItSystem
            // 
            this.btnAddItSystem.AccessibleDescription = "Rendszer hozzárendelése";
            this.btnAddItSystem.AccessibleName = "Rendszer hozzárendelése";
            this.btnAddItSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddItSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddItSystem.FlatAppearance.BorderSize = 0;
            this.btnAddItSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddItSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddItSystem.Location = new System.Drawing.Point(778, 448);
            this.btnAddItSystem.Name = "btnAddItSystem";
            this.btnAddItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnAddItSystem.TabIndex = 32;
            this.btnAddItSystem.Text = ">";
            this.btnAddItSystem.UseVisualStyleBackColor = false;
            this.btnAddItSystem.Click += new System.EventHandler(this.BtnAddItSystem_Click);
            // 
            // lblItSystems
            // 
            this.lblItSystems.AutoSize = true;
            this.lblItSystems.Location = new System.Drawing.Point(568, 377);
            this.lblItSystems.Name = "lblItSystems";
            this.lblItSystems.Size = new System.Drawing.Size(97, 21);
            this.lblItSystems.TabIndex = 98;
            this.lblItSystems.Text = "Rendszerek";
            // 
            // lsbItSystems
            // 
            this.lsbItSystems.AccessibleDescription = "Informatikai rendszerek listája";
            this.lsbItSystems.AccessibleName = "Informatikai rendszerek listája";
            this.lsbItSystems.FormattingEnabled = true;
            this.lsbItSystems.ItemHeight = 21;
            this.lsbItSystems.Location = new System.Drawing.Point(572, 401);
            this.lsbItSystems.Name = "lsbItSystems";
            this.lsbItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbItSystems.Size = new System.Drawing.Size(200, 172);
            this.lsbItSystems.TabIndex = 31;
            // 
            // btnCopyRecoveryKey
            // 
            this.btnCopyRecoveryKey.AccessibleDescription = "Helyreállítási kulcs másolása";
            this.btnCopyRecoveryKey.AccessibleName = "Helyreállítási kulcs másolása";
            this.btnCopyRecoveryKey.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyRecoveryKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopyRecoveryKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopyRecoveryKey.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCopyRecoveryKey.FlatAppearance.BorderSize = 0;
            this.btnCopyRecoveryKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCopyRecoveryKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCopyRecoveryKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRecoveryKey.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCopyRecoveryKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCopyRecoveryKey.Image = global::IBANYR.Properties.Resources.copyBlue;
            this.btnCopyRecoveryKey.Location = new System.Drawing.Point(503, 608);
            this.btnCopyRecoveryKey.Name = "btnCopyRecoveryKey";
            this.btnCopyRecoveryKey.Size = new System.Drawing.Size(30, 30);
            this.btnCopyRecoveryKey.TabIndex = 21;
            this.btnCopyRecoveryKey.UseVisualStyleBackColor = false;
            this.btnCopyRecoveryKey.Click += new System.EventHandler(this.BtnCopyRecoveryKey_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(569, 583);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 100;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // numStorageCapacity
            // 
            this.numStorageCapacity.AccessibleDescription = "Az értéket MB-ban lehet megadni, melynek maximális értéke 1.000.000.000 lehet.";
            this.numStorageCapacity.AccessibleName = "Tárolókapacitás";
            this.numStorageCapacity.Location = new System.Drawing.Point(194, 577);
            this.numStorageCapacity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numStorageCapacity.Name = "numStorageCapacity";
            this.numStorageCapacity.Size = new System.Drawing.Size(150, 27);
            this.numStorageCapacity.TabIndex = 18;
            this.numStorageCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStorageCapacity.UnitAndGearNum = ((System.Collections.Generic.Dictionary<string, int>)(resources.GetObject("numStorageCapacity.UnitAndGearNum")));
            this.numStorageCapacity.UniteType = IBANYR.UnitTypes.Storage;
            // 
            // numRam
            // 
            this.numRam.AccessibleDescription = "Az értéket MB-ban lehet megadni, melynek maximális értéke 1.000.000 lehet.";
            this.numRam.AccessibleName = "RAM mérete";
            this.numRam.Enabled = false;
            this.numRam.Location = new System.Drawing.Point(194, 476);
            this.numRam.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numRam.Name = "numRam";
            this.numRam.Size = new System.Drawing.Size(150, 27);
            this.numRam.TabIndex = 16;
            this.numRam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numRam.UnitAndGearNum = ((System.Collections.Generic.Dictionary<string, int>)(resources.GetObject("numRam.UnitAndGearNum")));
            this.numRam.UniteType = IBANYR.UnitTypes.Storage;
            // 
            // FrmHardwareManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1044, 661);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnCopyRecoveryKey);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lsbHardwareItSystems);
            this.Controls.Add(this.btnRemoveItSystem);
            this.Controls.Add(this.btnAddItSystem);
            this.Controls.Add(this.lblItSystems);
            this.Controls.Add(this.lsbItSystems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbRecoveryKey);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.chbEncrypted);
            this.Controls.Add(this.numStorageCapacity);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txbOtherComponent);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numRam);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txbProcessor);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.grbNetworkDatas);
            this.Controls.Add(this.chbVirtual);
            this.Controls.Add(this.chbPortable);
            this.Controls.Add(this.cmbHardwareType);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numWarrantyYears);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txbSerialNumber);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txbPlace);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbUId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtbOtherDescription);
            this.Controls.Add(this.dtpScrappingDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rtbDocLink);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbOwnerId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbAName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbAId);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmHardwareManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardverkezelő";
            ((System.ComponentModel.ISupportInitialize)(this.numWarrantyYears)).EndInit();
            this.grbNetworkDatas.ResumeLayout(false);
            this.grbNetworkDatas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStorageCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbOwnerId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox rtbDocLink;
        private System.Windows.Forms.DateTimePicker dtpScrappingDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbOtherDescription;
        private System.Windows.Forms.ComboBox cmbUId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbPlace;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbSerialNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numWarrantyYears;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbHardwareType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chbPortable;
        private System.Windows.Forms.CheckBox chbVirtual;
        private System.Windows.Forms.GroupBox grbNetworkDatas;
        private System.Windows.Forms.ListBox lsbNICs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbHostName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReadNIC;
        private System.Windows.Forms.Button btnAddNIC;
        private System.Windows.Forms.Button btnEditNIC;
        private System.Windows.Forms.TextBox txbProcessor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private NumericUpDownDynamicUnit numRam;
        private System.Windows.Forms.TextBox txbOtherComponent;
        private System.Windows.Forms.Label label18;
        private NumericUpDownDynamicUnit numStorageCapacity;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chbEncrypted;
        private System.Windows.Forms.TextBox txbRecoveryKey;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnDeleteNIC;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox lsbHardwareItSystems;
        private System.Windows.Forms.Button btnRemoveItSystem;
        private System.Windows.Forms.Button btnAddItSystem;
        private System.Windows.Forms.Label lblItSystems;
        private System.Windows.Forms.ListBox lsbItSystems;
        private System.Windows.Forms.Button btnCopyRecoveryKey;
        private System.Windows.Forms.Label label23;
    }
}