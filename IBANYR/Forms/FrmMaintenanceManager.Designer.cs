
namespace IBANYR
{
    partial class FrmMaintenanceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaintenanceManager));
            this.txbLogId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbMType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbActivitiesDesc = new System.Windows.Forms.RichTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.rtbDocLink = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lsbAffectedComponents = new System.Windows.Forms.ListBox();
            this.btnRemoveHardware = new System.Windows.Forms.Button();
            this.btnAddHardware = new System.Windows.Forms.Button();
            this.lblHardwares = new System.Windows.Forms.Label();
            this.lsbHardwares = new System.Windows.Forms.ListBox();
            this.txbMName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.lsbAffectedItSystems = new System.Windows.Forms.ListBox();
            this.btnRemoveItSystem = new System.Windows.Forms.Button();
            this.btnAddItSystem = new System.Windows.Forms.Button();
            this.lblItSystems = new System.Windows.Forms.Label();
            this.lsbItSystems = new System.Windows.Forms.ListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txbLogId
            // 
            this.txbLogId.AccessibleDescription = "A bejegyzésazonosító megadása/módosítása nem lehetséges!\\nAz adatbázisszerver aut" +
    "omatikusan generált értéke.";
            this.txbLogId.AccessibleName = "Bejegyzésazonosító";
            this.txbLogId.Location = new System.Drawing.Point(200, 3);
            this.txbLogId.Name = "txbLogId";
            this.txbLogId.ReadOnly = true;
            this.txbLogId.Size = new System.Drawing.Size(100, 27);
            this.txbLogId.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 21);
            this.label8.TabIndex = 122;
            this.label8.Text = "Bejegyzésazonosító:";
            // 
            // cmbMType
            // 
            this.cmbMType.AccessibleDescription = "Karbantartás típusát rögzített értékek közül választhatja ki.";
            this.cmbMType.AccessibleName = "Karbantartás típusa";
            this.cmbMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMType.FormattingEnabled = true;
            this.cmbMType.Location = new System.Drawing.Point(200, 36);
            this.cmbMType.Name = "cmbMType";
            this.cmbMType.Size = new System.Drawing.Size(177, 29);
            this.cmbMType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 21);
            this.label5.TabIndex = 126;
            this.label5.Text = "Karbantartás típusa:";
            // 
            // cmbMMethod
            // 
            this.cmbMMethod.AccessibleDescription = "A karbantartás módját rögzített értékek közül választhatja ki.";
            this.cmbMMethod.AccessibleName = "Karbantartás módja";
            this.cmbMMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMMethod.FormattingEnabled = true;
            this.cmbMMethod.Location = new System.Drawing.Point(200, 71);
            this.cmbMMethod.Name = "cmbMMethod";
            this.cmbMMethod.Size = new System.Drawing.Size(177, 29);
            this.cmbMMethod.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 21);
            this.label1.TabIndex = 128;
            this.label1.Text = "Karbantartás módja:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AccessibleDescription = "A karbantartási tevékenység kezdő időpontja.";
            this.dtpStartDate.AccessibleName = "Karbantartás kezdés időpontja";
            this.dtpStartDate.CustomFormat = "yyyy.MM.dd HH:mm";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(200, 106);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(177, 27);
            this.dtpStartDate.TabIndex = 4;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 21);
            this.label6.TabIndex = 130;
            this.label6.Text = "Kezdés időpontja:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AccessibleDescription = "A karbantartási tevékenység befejező időpontja.";
            this.dtpEndDate.AccessibleName = "Karbantartás befejezés időpontja";
            this.dtpEndDate.CustomFormat = "yyyy.MM.dd HH:mm";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(200, 174);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(177, 27);
            this.dtpEndDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 21);
            this.label2.TabIndex = 132;
            this.label2.Text = "Befejezés időpontja:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.AccessibleDescription = "Rögzített értékek közül választhat. Folyamatban érték választása esetén a befejez" +
    "és időpontja nem adható meg.";
            this.cmbStatus.AccessibleName = "Karbantartás státusza";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(200, 139);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(177, 29);
            this.cmbStatus.TabIndex = 5;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 21);
            this.label3.TabIndex = 134;
            this.label3.Text = "Karbantartás státusza:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 21);
            this.label10.TabIndex = 135;
            this.label10.Text = "Végzett tevékenységek*:";
            // 
            // rtbActivitiesDesc
            // 
            this.rtbActivitiesDesc.AccessibleDescription = "Végzett tevékenység leírása";
            this.rtbActivitiesDesc.AccessibleName = "Végzett tevékenység leírása";
            this.rtbActivitiesDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbActivitiesDesc.Location = new System.Drawing.Point(11, 240);
            this.rtbActivitiesDesc.MaxLength = 1073741823;
            this.rtbActivitiesDesc.Name = "rtbActivitiesDesc";
            this.rtbActivitiesDesc.Size = new System.Drawing.Size(456, 73);
            this.rtbActivitiesDesc.TabIndex = 7;
            this.rtbActivitiesDesc.Text = "";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 404);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(334, 21);
            this.label19.TabIndex = 138;
            this.label19.Text = "Kapcsolódó dokumentumok hivatkozásai:";
            // 
            // rtbDocLink
            // 
            this.rtbDocLink.AccessibleDescription = "Karbantartáshoz kapcsolódó dokumentumok hivatkozásai";
            this.rtbDocLink.AccessibleName = "Karbantartáshoz kapcsolódó dokumentumok hivatkozásai";
            this.rtbDocLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDocLink.Location = new System.Drawing.Point(11, 428);
            this.rtbDocLink.MaxLength = 4000;
            this.rtbDocLink.Name = "rtbDocLink";
            this.rtbDocLink.Size = new System.Drawing.Size(456, 60);
            this.rtbDocLink.TabIndex = 9;
            this.rtbDocLink.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(733, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 21);
            this.label4.TabIndex = 144;
            this.label4.Text = "Érintett hardverek";
            // 
            // lsbAffectedComponents
            // 
            this.lsbAffectedComponents.AccessibleDescription = "Karbantartásban érintett hardverek listája";
            this.lsbAffectedComponents.AccessibleName = "Karbantartásban érintett hardverek listája";
            this.lsbAffectedComponents.FormattingEnabled = true;
            this.lsbAffectedComponents.ItemHeight = 21;
            this.lsbAffectedComponents.Location = new System.Drawing.Point(737, 33);
            this.lsbAffectedComponents.Name = "lsbAffectedComponents";
            this.lsbAffectedComponents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbAffectedComponents.Size = new System.Drawing.Size(200, 172);
            this.lsbAffectedComponents.TabIndex = 13;
            // 
            // btnRemoveHardware
            // 
            this.btnRemoveHardware.AccessibleDescription = "Hardver hozzárendelésének törlése";
            this.btnRemoveHardware.AccessibleName = "Hardver hozzárendelésének törlése";
            this.btnRemoveHardware.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnRemoveHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnRemoveHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveHardware.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRemoveHardware.FlatAppearance.BorderSize = 0;
            this.btnRemoveHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRemoveHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRemoveHardware.Location = new System.Drawing.Point(683, 126);
            this.btnRemoveHardware.Name = "btnRemoveHardware";
            this.btnRemoveHardware.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveHardware.TabIndex = 12;
            this.btnRemoveHardware.Text = "<";
            this.btnRemoveHardware.UseVisualStyleBackColor = false;
            this.btnRemoveHardware.Click += new System.EventHandler(this.BtnRemoveHardware_Click);
            // 
            // btnAddHardware
            // 
            this.btnAddHardware.AccessibleDescription = "Hardver hozzárendelése";
            this.btnAddHardware.AccessibleName = "Hardver hozzárendelése";
            this.btnAddHardware.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnAddHardware.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddHardware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHardware.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddHardware.FlatAppearance.BorderSize = 0;
            this.btnAddHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHardware.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddHardware.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddHardware.Location = new System.Drawing.Point(683, 80);
            this.btnAddHardware.Name = "btnAddHardware";
            this.btnAddHardware.Size = new System.Drawing.Size(49, 40);
            this.btnAddHardware.TabIndex = 11;
            this.btnAddHardware.Text = ">";
            this.btnAddHardware.UseVisualStyleBackColor = false;
            this.btnAddHardware.Click += new System.EventHandler(this.BtnAddHardware_Click);
            // 
            // lblHardwares
            // 
            this.lblHardwares.AutoSize = true;
            this.lblHardwares.Location = new System.Drawing.Point(473, 9);
            this.lblHardwares.Name = "lblHardwares";
            this.lblHardwares.Size = new System.Drawing.Size(143, 21);
            this.lblHardwares.TabIndex = 143;
            this.lblHardwares.Text = "Hardver eszközök";
            // 
            // lsbHardwares
            // 
            this.lsbHardwares.AccessibleDescription = "Hardver eszközök listája";
            this.lsbHardwares.AccessibleName = "Hardver eszközök listája";
            this.lsbHardwares.FormattingEnabled = true;
            this.lsbHardwares.ItemHeight = 21;
            this.lsbHardwares.Location = new System.Drawing.Point(477, 33);
            this.lsbHardwares.Name = "lsbHardwares";
            this.lsbHardwares.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbHardwares.Size = new System.Drawing.Size(200, 172);
            this.lsbHardwares.TabIndex = 10;
            // 
            // txbMName
            // 
            this.txbMName.AccessibleDescription = "Karbantartást végző személy vagy szervezet megnevezése";
            this.txbMName.AccessibleName = "Karbantartást végző személy vagy szervezet megnevezése";
            this.txbMName.Location = new System.Drawing.Point(11, 340);
            this.txbMName.MaxLength = 300;
            this.txbMName.Multiline = true;
            this.txbMName.Name = "txbMName";
            this.txbMName.Size = new System.Drawing.Size(456, 61);
            this.txbMName.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(325, 21);
            this.label7.TabIndex = 145;
            this.label7.Text = "Karbantartást végző szervezet/személy*:";
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
            this.btnCancel.Location = new System.Drawing.Point(784, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 19;
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
            this.btnOk.Location = new System.Drawing.Point(628, 451);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 40);
            this.btnOk.TabIndex = 18;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(733, 219);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(154, 21);
            this.label22.TabIndex = 154;
            this.label22.Text = "Érintett rendszerek";
            // 
            // lsbAffectedItSystems
            // 
            this.lsbAffectedItSystems.AccessibleDescription = "Karbantartásban érintett rendszerek listája";
            this.lsbAffectedItSystems.AccessibleName = "Karbantartásban érintett rendszerek listája";
            this.lsbAffectedItSystems.FormattingEnabled = true;
            this.lsbAffectedItSystems.ItemHeight = 21;
            this.lsbAffectedItSystems.Location = new System.Drawing.Point(737, 240);
            this.lsbAffectedItSystems.Name = "lsbAffectedItSystems";
            this.lsbAffectedItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbAffectedItSystems.Size = new System.Drawing.Size(200, 172);
            this.lsbAffectedItSystems.TabIndex = 17;
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
            this.btnRemoveItSystem.Location = new System.Drawing.Point(683, 333);
            this.btnRemoveItSystem.Name = "btnRemoveItSystem";
            this.btnRemoveItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnRemoveItSystem.TabIndex = 16;
            this.btnRemoveItSystem.Text = "<";
            this.btnRemoveItSystem.UseVisualStyleBackColor = false;
            this.btnRemoveItSystem.Click += new System.EventHandler(this.BtnRemoveItSystem_Click);
            // 
            // btnAddItSystem
            // 
            this.btnAddItSystem.AccessibleDescription = "Rendszer hozzárendelése";
            this.btnAddItSystem.AccessibleName = "Rendszer hozzárendelése";
            this.btnAddItSystem.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.btnAddItSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(138)))), ((int)(((byte)(219)))));
            this.btnAddItSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddItSystem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddItSystem.FlatAppearance.BorderSize = 0;
            this.btnAddItSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItSystem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddItSystem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddItSystem.Location = new System.Drawing.Point(683, 287);
            this.btnAddItSystem.Name = "btnAddItSystem";
            this.btnAddItSystem.Size = new System.Drawing.Size(49, 40);
            this.btnAddItSystem.TabIndex = 15;
            this.btnAddItSystem.Text = ">";
            this.btnAddItSystem.UseVisualStyleBackColor = false;
            this.btnAddItSystem.Click += new System.EventHandler(this.BtnAddItSystem_Click);
            // 
            // lblItSystems
            // 
            this.lblItSystems.AutoSize = true;
            this.lblItSystems.Location = new System.Drawing.Point(473, 216);
            this.lblItSystems.Name = "lblItSystems";
            this.lblItSystems.Size = new System.Drawing.Size(97, 21);
            this.lblItSystems.TabIndex = 153;
            this.lblItSystems.Text = "Rendszerek";
            // 
            // lsbItSystems
            // 
            this.lsbItSystems.AccessibleDescription = "Rendszerek listája";
            this.lsbItSystems.AccessibleName = "Rendszerek listája";
            this.lsbItSystems.FormattingEnabled = true;
            this.lsbItSystems.ItemHeight = 21;
            this.lsbItSystems.Location = new System.Drawing.Point(477, 240);
            this.lsbItSystems.Name = "lsbItSystems";
            this.lsbItSystems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbItSystems.Size = new System.Drawing.Size(200, 172);
            this.lsbItSystems.TabIndex = 14;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(473, 415);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(324, 21);
            this.label23.TabIndex = 155;
            this.label23.Text = "*-gal jelölt aktív mezők kitöltése kötelező!";
            // 
            // FrmMaintenanceManager
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(946, 503);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lsbAffectedItSystems);
            this.Controls.Add(this.btnRemoveItSystem);
            this.Controls.Add(this.btnAddItSystem);
            this.Controls.Add(this.lblItSystems);
            this.Controls.Add(this.lsbItSystems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txbMName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lsbAffectedComponents);
            this.Controls.Add(this.btnRemoveHardware);
            this.Controls.Add(this.btnAddHardware);
            this.Controls.Add(this.lblHardwares);
            this.Controls.Add(this.lsbHardwares);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.rtbDocLink);
            this.Controls.Add(this.rtbActivitiesDesc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMMethod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbLogId);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMaintenanceManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karbantartási napló kezelő";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLogId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbMType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rtbActivitiesDesc;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox rtbDocLink;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lsbAffectedComponents;
        private System.Windows.Forms.Button btnRemoveHardware;
        private System.Windows.Forms.Button btnAddHardware;
        private System.Windows.Forms.Label lblHardwares;
        private System.Windows.Forms.ListBox lsbHardwares;
        private System.Windows.Forms.TextBox txbMName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox lsbAffectedItSystems;
        private System.Windows.Forms.Button btnRemoveItSystem;
        private System.Windows.Forms.Button btnAddItSystem;
        private System.Windows.Forms.Label lblItSystems;
        private System.Windows.Forms.ListBox lsbItSystems;
        private System.Windows.Forms.Label label23;
    }
}