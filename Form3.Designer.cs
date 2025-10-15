namespace apartment
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            cboRoomStatus = new ComboBox();
            btuRoomEdit = new Button();
            btuRoomClear = new Button();
            btuRoomAdd = new Button();
            btuRoomDel = new Button();
            dgvRoom = new DataGridView();
            label3 = new Label();
            txtRoomfloor = new TextBox();
            txtRoomID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btuFacilityEdit = new Button();
            dgvFacility = new DataGridView();
            btuFacilityClear = new Button();
            btuFacilityAdd = new Button();
            label14 = new Label();
            btuFacilityDel = new Button();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            cboTypeID = new ComboBox();
            cboRoomid = new ComboBox();
            txtDes = new TextBox();
            dtpReID = new DateTimePicker();
            txtFPrice = new TextBox();
            txtFmodel = new TextBox();
            txtFbrand = new TextBox();
            txtFID = new TextBox();
            label8 = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            dgvType = new DataGridView();
            btuTypeEdit = new Button();
            label6 = new Label();
            btuTypeClear = new Button();
            btuTypeAdd = new Button();
            txtFaciltyTypeDesc = new TextBox();
            btuTypeDel = new Button();
            txtFaciltyTypeName = new TextBox();
            label5 = new Label();
            txtFaciltyTypeID = new TextBox();
            label4 = new Label();
            groupBox4 = new GroupBox();
            btuRentaEdit = new Button();
            cboRentaTanantID = new ComboBox();
            btuRentaClear = new Button();
            btuRentaAdd = new Button();
            cboRentaRoomID = new ComboBox();
            btuRentaDel = new Button();
            dtpStaet = new DateTimePicker();
            dgvRenta = new DataGridView();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            dtpEnd = new DateTimePicker();
            txtRentaID = new TextBox();
            label21 = new Label();
            label22 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacility).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvType).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRenta).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboRoomStatus);
            groupBox1.Controls.Add(btuRoomEdit);
            groupBox1.Controls.Add(btuRoomClear);
            groupBox1.Controls.Add(btuRoomAdd);
            groupBox1.Controls.Add(btuRoomDel);
            groupBox1.Controls.Add(dgvRoom);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtRoomfloor);
            groupBox1.Controls.Add(txtRoomID);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(863, 332);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "ข้อมูลห้อง";
            // 
            // cboRoomStatus
            // 
            cboRoomStatus.FormattingEnabled = true;
            cboRoomStatus.Location = new Point(80, 85);
            cboRoomStatus.Name = "cboRoomStatus";
            cboRoomStatus.Size = new Size(214, 28);
            cboRoomStatus.TabIndex = 26;
            cboRoomStatus.SelectedIndexChanged += cboRoomStatus_SelectedIndexChanged;
            // 
            // btuRoomEdit
            // 
            btuRoomEdit.Location = new Point(445, 64);
            btuRoomEdit.Name = "btuRoomEdit";
            btuRoomEdit.Size = new Size(94, 29);
            btuRoomEdit.TabIndex = 10;
            btuRoomEdit.Text = "บันทึก";
            btuRoomEdit.UseVisualStyleBackColor = true;
            btuRoomEdit.Click += btuRoomEdit_Click;
            // 
            // btuRoomClear
            // 
            btuRoomClear.Location = new Point(545, 64);
            btuRoomClear.Name = "btuRoomClear";
            btuRoomClear.Size = new Size(94, 29);
            btuRoomClear.TabIndex = 9;
            btuRoomClear.Text = "ล้าง";
            btuRoomClear.UseVisualStyleBackColor = true;
            btuRoomClear.Click += btuRoomClear_Click;
            // 
            // btuRoomAdd
            // 
            btuRoomAdd.Location = new Point(445, 22);
            btuRoomAdd.Name = "btuRoomAdd";
            btuRoomAdd.Size = new Size(94, 29);
            btuRoomAdd.TabIndex = 8;
            btuRoomAdd.Text = "เพิ่ม";
            btuRoomAdd.UseVisualStyleBackColor = true;
            btuRoomAdd.Click += btuRoomAdd_Click;
            // 
            // btuRoomDel
            // 
            btuRoomDel.Location = new Point(545, 23);
            btuRoomDel.Name = "btuRoomDel";
            btuRoomDel.Size = new Size(94, 29);
            btuRoomDel.TabIndex = 7;
            btuRoomDel.Text = "ลบ";
            btuRoomDel.UseVisualStyleBackColor = true;
            btuRoomDel.Click += btuRoomDel_Click;
            // 
            // dgvRoom
            // 
            dgvRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoom.Location = new Point(6, 125);
            dgvRoom.Name = "dgvRoom";
            dgvRoom.RowHeadersWidth = 51;
            dgvRoom.Size = new Size(851, 201);
            dgvRoom.TabIndex = 6;
            dgvRoom.CellContentClick += dgvRoom_CellContentClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 93);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 5;
            label3.Text = "สภานะ";
            // 
            // txtRoomfloor
            // 
            txtRoomfloor.Location = new Point(80, 53);
            txtRoomfloor.Name = "txtRoomfloor";
            txtRoomfloor.Size = new Size(214, 27);
            txtRoomfloor.TabIndex = 3;
            txtRoomfloor.TextChanged += txtRoomfloor_TextChanged;
            // 
            // txtRoomID
            // 
            txtRoomID.Location = new Point(80, 20);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(214, 27);
            txtRoomID.TabIndex = 2;
            txtRoomID.TextChanged += txtRoomID_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 60);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 1;
            label2.Text = "ชั้น";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "ID Room";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btuFacilityEdit);
            groupBox2.Controls.Add(dgvFacility);
            groupBox2.Controls.Add(btuFacilityClear);
            groupBox2.Controls.Add(btuFacilityAdd);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(btuFacilityDel);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cboTypeID);
            groupBox2.Controls.Add(cboRoomid);
            groupBox2.Controls.Add(txtDes);
            groupBox2.Controls.Add(dtpReID);
            groupBox2.Controls.Add(txtFPrice);
            groupBox2.Controls.Add(txtFmodel);
            groupBox2.Controls.Add(txtFbrand);
            groupBox2.Controls.Add(txtFID);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(12, 350);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(863, 533);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "ข้อมูลสิ่งอำนวยความสะดวก";
            // 
            // btuFacilityEdit
            // 
            btuFacilityEdit.Location = new Point(445, 66);
            btuFacilityEdit.Name = "btuFacilityEdit";
            btuFacilityEdit.Size = new Size(94, 29);
            btuFacilityEdit.TabIndex = 19;
            btuFacilityEdit.Text = "บันทึก";
            btuFacilityEdit.UseVisualStyleBackColor = true;
            btuFacilityEdit.Click += btuFacilityEdit_Click;
            // 
            // dgvFacility
            // 
            dgvFacility.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacility.Location = new Point(6, 292);
            dgvFacility.Name = "dgvFacility";
            dgvFacility.RowHeadersWidth = 51;
            dgvFacility.Size = new Size(851, 235);
            dgvFacility.TabIndex = 11;
            dgvFacility.CellContentClick += dgvFacility_CellContentClick;
            // 
            // btuFacilityClear
            // 
            btuFacilityClear.Location = new Point(545, 66);
            btuFacilityClear.Name = "btuFacilityClear";
            btuFacilityClear.Size = new Size(94, 29);
            btuFacilityClear.TabIndex = 18;
            btuFacilityClear.Text = "ล้าง";
            btuFacilityClear.UseVisualStyleBackColor = true;
            btuFacilityClear.Click += btuFacilityClear_Click;
            // 
            // btuFacilityAdd
            // 
            btuFacilityAdd.Location = new Point(445, 24);
            btuFacilityAdd.Name = "btuFacilityAdd";
            btuFacilityAdd.Size = new Size(94, 29);
            btuFacilityAdd.TabIndex = 17;
            btuFacilityAdd.Text = "เพิ่ม";
            btuFacilityAdd.UseVisualStyleBackColor = true;
            btuFacilityAdd.Click += btuFacilityAdd_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 266);
            label14.Name = "label14";
            label14.Size = new Size(51, 20);
            label14.TabIndex = 25;
            label14.Text = "ประเภท";
            // 
            // btuFacilityDel
            // 
            btuFacilityDel.Location = new Point(545, 25);
            btuFacilityDel.Name = "btuFacilityDel";
            btuFacilityDel.Size = new Size(94, 29);
            btuFacilityDel.TabIndex = 16;
            btuFacilityDel.Text = "ลบ";
            btuFacilityDel.UseVisualStyleBackColor = true;
            btuFacilityDel.Click += btuFacilityDel_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 232);
            label13.Name = "label13";
            label13.Size = new Size(32, 20);
            label13.TabIndex = 24;
            label13.Text = "ห้อง";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 198);
            label12.Name = "label12";
            label12.Size = new Size(72, 20);
            label12.TabIndex = 23;
            label12.Text = "รายละเอียด";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 165);
            label11.Name = "label11";
            label11.Size = new Size(34, 20);
            label11.TabIndex = 22;
            label11.Text = "วันที่";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 132);
            label10.Name = "label10";
            label10.Size = new Size(38, 20);
            label10.TabIndex = 21;
            label10.Text = "ราคา";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 99);
            label9.Name = "label9";
            label9.Size = new Size(24, 20);
            label9.TabIndex = 20;
            label9.Text = "รุ่น";
            // 
            // cboTypeID
            // 
            cboTypeID.FormattingEnabled = true;
            cboTypeID.Location = new Point(113, 258);
            cboTypeID.Name = "cboTypeID";
            cboTypeID.Size = new Size(214, 28);
            cboTypeID.TabIndex = 19;
            // 
            // cboRoomid
            // 
            cboRoomid.FormattingEnabled = true;
            cboRoomid.Location = new Point(113, 224);
            cboRoomid.Name = "cboRoomid";
            cboRoomid.Size = new Size(214, 28);
            cboRoomid.TabIndex = 18;
            // 
            // txtDes
            // 
            txtDes.Location = new Point(113, 191);
            txtDes.Name = "txtDes";
            txtDes.Size = new Size(214, 27);
            txtDes.TabIndex = 17;
            // 
            // dtpReID
            // 
            dtpReID.Location = new Point(113, 158);
            dtpReID.Name = "dtpReID";
            dtpReID.Size = new Size(214, 27);
            dtpReID.TabIndex = 16;
            // 
            // txtFPrice
            // 
            txtFPrice.Location = new Point(113, 125);
            txtFPrice.Name = "txtFPrice";
            txtFPrice.Size = new Size(214, 27);
            txtFPrice.TabIndex = 15;
            // 
            // txtFmodel
            // 
            txtFmodel.Location = new Point(113, 92);
            txtFmodel.Name = "txtFmodel";
            txtFmodel.Size = new Size(214, 27);
            txtFmodel.TabIndex = 14;
            // 
            // txtFbrand
            // 
            txtFbrand.Location = new Point(113, 59);
            txtFbrand.Name = "txtFbrand";
            txtFbrand.Size = new Size(214, 27);
            txtFbrand.TabIndex = 13;
            // 
            // txtFID
            // 
            txtFID.Location = new Point(113, 26);
            txtFID.Name = "txtFID";
            txtFID.Size = new Size(214, 27);
            txtFID.TabIndex = 11;
            txtFID.TextChanged += txtFID_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 66);
            label8.Name = "label8";
            label8.Size = new Size(34, 20);
            label8.TabIndex = 12;
            label8.Text = "ยี่ห้อ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 33);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 11;
            label7.Text = "รหัสอุปกรณ์";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvType);
            groupBox3.Controls.Add(btuTypeEdit);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(btuTypeClear);
            groupBox3.Controls.Add(btuTypeAdd);
            groupBox3.Controls.Add(txtFaciltyTypeDesc);
            groupBox3.Controls.Add(btuTypeDel);
            groupBox3.Controls.Add(txtFaciltyTypeName);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtFaciltyTypeID);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(881, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(773, 332);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "ข้อมูลประเถทอำนวยความสะดวก";
            // 
            // dgvType
            // 
            dgvType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvType.Location = new Point(-6, 125);
            dgvType.Name = "dgvType";
            dgvType.RowHeadersWidth = 51;
            dgvType.Size = new Size(773, 201);
            dgvType.TabIndex = 11;
            dgvType.CellContentClick += dgvType_CellContentClick;
            // 
            // btuTypeEdit
            // 
            btuTypeEdit.Location = new Point(424, 64);
            btuTypeEdit.Name = "btuTypeEdit";
            btuTypeEdit.Size = new Size(94, 29);
            btuTypeEdit.TabIndex = 14;
            btuTypeEdit.Text = "บันทึก";
            btuTypeEdit.UseVisualStyleBackColor = true;
            btuTypeEdit.Click += btuTypeEdit_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 99);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 15;
            label6.Text = "รายละเอียด";
            // 
            // btuTypeClear
            // 
            btuTypeClear.Location = new Point(524, 64);
            btuTypeClear.Name = "btuTypeClear";
            btuTypeClear.Size = new Size(94, 29);
            btuTypeClear.TabIndex = 13;
            btuTypeClear.Text = "ล้าง";
            btuTypeClear.UseVisualStyleBackColor = true;
            btuTypeClear.Click += btuTypeClear_Click;
            // 
            // btuTypeAdd
            // 
            btuTypeAdd.Location = new Point(424, 22);
            btuTypeAdd.Name = "btuTypeAdd";
            btuTypeAdd.Size = new Size(94, 29);
            btuTypeAdd.TabIndex = 12;
            btuTypeAdd.Text = "เพิ่ม";
            btuTypeAdd.UseVisualStyleBackColor = true;
            btuTypeAdd.Click += btuTypeAdd_Click;
            // 
            // txtFaciltyTypeDesc
            // 
            txtFaciltyTypeDesc.Location = new Point(196, 92);
            txtFaciltyTypeDesc.Name = "txtFaciltyTypeDesc";
            txtFaciltyTypeDesc.Size = new Size(214, 27);
            txtFaciltyTypeDesc.TabIndex = 14;
            // 
            // btuTypeDel
            // 
            btuTypeDel.Location = new Point(524, 23);
            btuTypeDel.Name = "btuTypeDel";
            btuTypeDel.Size = new Size(94, 29);
            btuTypeDel.TabIndex = 11;
            btuTypeDel.Text = "ลบ";
            btuTypeDel.UseVisualStyleBackColor = true;
            btuTypeDel.Click += btuTypeDel_Click;
            // 
            // txtFaciltyTypeName
            // 
            txtFaciltyTypeName.Location = new Point(196, 59);
            txtFaciltyTypeName.Name = "txtFaciltyTypeName";
            txtFaciltyTypeName.Size = new Size(214, 27);
            txtFaciltyTypeName.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 64);
            label5.Name = "label5";
            label5.Size = new Size(173, 20);
            label5.TabIndex = 12;
            label5.Text = "ประเภทสิ่งอำนวยความสะดวก";
            // 
            // txtFaciltyTypeID
            // 
            txtFaciltyTypeID.Location = new Point(196, 26);
            txtFaciltyTypeID.Name = "txtFaciltyTypeID";
            txtFaciltyTypeID.Size = new Size(214, 27);
            txtFaciltyTypeID.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 35);
            label4.Name = "label4";
            label4.Size = new Size(184, 20);
            label4.TabIndex = 11;
            label4.Text = "หมายเลขสิ่งอำนวยความสะดวก";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btuRentaEdit);
            groupBox4.Controls.Add(cboRentaTanantID);
            groupBox4.Controls.Add(btuRentaClear);
            groupBox4.Controls.Add(btuRentaAdd);
            groupBox4.Controls.Add(cboRentaRoomID);
            groupBox4.Controls.Add(btuRentaDel);
            groupBox4.Controls.Add(dtpStaet);
            groupBox4.Controls.Add(dgvRenta);
            groupBox4.Controls.Add(label18);
            groupBox4.Controls.Add(label19);
            groupBox4.Controls.Add(label20);
            groupBox4.Controls.Add(dtpEnd);
            groupBox4.Controls.Add(txtRentaID);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(label22);
            groupBox4.Location = new Point(881, 350);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(773, 533);
            groupBox4.TabIndex = 26;
            groupBox4.TabStop = false;
            groupBox4.Text = "ข้อมูลการเช่า";
            // 
            // btuRentaEdit
            // 
            btuRentaEdit.Location = new Point(424, 66);
            btuRentaEdit.Name = "btuRentaEdit";
            btuRentaEdit.Size = new Size(94, 29);
            btuRentaEdit.TabIndex = 19;
            btuRentaEdit.Text = "บันทึก";
            btuRentaEdit.UseVisualStyleBackColor = true;
            btuRentaEdit.Click += btuRentaEdit_Click;
            // 
            // cboRentaTanantID
            // 
            cboRentaTanantID.FormattingEnabled = true;
            cboRentaTanantID.Location = new Point(113, 59);
            cboRentaTanantID.Name = "cboRentaTanantID";
            cboRentaTanantID.Size = new Size(214, 28);
            cboRentaTanantID.TabIndex = 27;
            // 
            // btuRentaClear
            // 
            btuRentaClear.Location = new Point(524, 66);
            btuRentaClear.Name = "btuRentaClear";
            btuRentaClear.Size = new Size(94, 29);
            btuRentaClear.TabIndex = 18;
            btuRentaClear.Text = "ล้าง";
            btuRentaClear.UseVisualStyleBackColor = true;
            btuRentaClear.Click += btuRentaClear_Click;
            // 
            // btuRentaAdd
            // 
            btuRentaAdd.Location = new Point(424, 24);
            btuRentaAdd.Name = "btuRentaAdd";
            btuRentaAdd.Size = new Size(94, 29);
            btuRentaAdd.TabIndex = 17;
            btuRentaAdd.Text = "เพิ่ม";
            btuRentaAdd.UseVisualStyleBackColor = true;
            btuRentaAdd.Click += btuRentaAdd_Click;
            // 
            // cboRentaRoomID
            // 
            cboRentaRoomID.FormattingEnabled = true;
            cboRentaRoomID.Location = new Point(113, 91);
            cboRentaRoomID.Name = "cboRentaRoomID";
            cboRentaRoomID.Size = new Size(214, 28);
            cboRentaRoomID.TabIndex = 26;
            cboRentaRoomID.SelectedIndexChanged += cboRentaRoomID_SelectedIndexChanged;
            // 
            // btuRentaDel
            // 
            btuRentaDel.Location = new Point(524, 25);
            btuRentaDel.Name = "btuRentaDel";
            btuRentaDel.Size = new Size(94, 29);
            btuRentaDel.TabIndex = 16;
            btuRentaDel.Text = "ลบ";
            btuRentaDel.UseVisualStyleBackColor = true;
            btuRentaDel.Click += btuRentaDel_Click;
            // 
            // dtpStaet
            // 
            dtpStaet.Location = new Point(113, 125);
            dtpStaet.Name = "dtpStaet";
            dtpStaet.Size = new Size(214, 27);
            dtpStaet.TabIndex = 23;
            // 
            // dgvRenta
            // 
            dgvRenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRenta.Location = new Point(6, 198);
            dgvRenta.Name = "dgvRenta";
            dgvRenta.RowHeadersWidth = 51;
            dgvRenta.Size = new Size(761, 329);
            dgvRenta.TabIndex = 11;
            dgvRenta.CellContentClick += dgvRenta_CellContentClick;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 165);
            label18.Name = "label18";
            label18.Size = new Size(68, 20);
            label18.TabIndex = 22;
            label18.Text = "วันที่สิ้นสุด";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 132);
            label19.Name = "label19";
            label19.Size = new Size(72, 20);
            label19.TabIndex = 21;
            label19.Text = "วันที่เริ่มเช่า";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 99);
            label20.Name = "label20";
            label20.Size = new Size(32, 20);
            label20.TabIndex = 20;
            label20.Text = "ห้อง";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(113, 158);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(214, 27);
            dtpEnd.TabIndex = 16;
            // 
            // txtRentaID
            // 
            txtRentaID.Location = new Point(113, 26);
            txtRentaID.Name = "txtRentaID";
            txtRentaID.Size = new Size(214, 27);
            txtRentaID.TabIndex = 11;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 66);
            label21.Name = "label21";
            label21.Size = new Size(38, 20);
            label21.TabIndex = 12;
            label21.Text = "ผู้เช่า";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(6, 33);
            label22.Name = "label22";
            label22.Size = new Size(57, 20);
            label22.TabIndex = 11;
            label22.Text = "ID ผู้เช่า";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 895);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form3";
            Text = "จัดการข้อมูลต่างๆ";
            WindowState = FormWindowState.Maximized;
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoom).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacility).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvType).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRenta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btuRoomEdit;
        private Button btuRoomClear;
        private Button btuRoomAdd;
        private Button btuRoomDel;
        private DataGridView dgvRoom;
        private Label label3;
        private TextBox txtRoomfloor;
        private TextBox txtRoomID;
        private Label label2;
        private Label label1;
        private TextBox txtFaciltyTypeID;
        private Label label4;
        private Button btuTypeEdit;
        private Label label6;
        private Button btuTypeClear;
        private Button btuTypeAdd;
        private TextBox txtFaciltyTypeDesc;
        private Button btuTypeDel;
        private TextBox txtFaciltyTypeName;
        private Label label5;
        private DataGridView dgvType;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private ComboBox cboTypeID;
        private ComboBox cboRoomid;
        private TextBox txtDes;
        private DateTimePicker dtpReID;
        private TextBox txtFPrice;
        private TextBox txtFmodel;
        private TextBox txtFbrand;
        private TextBox txtFID;
        private Label label8;
        private Label label7;
        private DataGridView dgvFacility;
        private GroupBox groupBox4;
        private DataGridView dgvRenta;
        private Label label18;
        private Label label19;
        private Label label20;
        private DateTimePicker dtpEnd;
        private Label label21;
        private Button btuFacilityEdit;
        private Button btuFacilityClear;
        private Button btuFacilityAdd;
        private Button btuFacilityDel;
        private Button btuRentaEdit;
        private ComboBox cboRentaTanantID;
        private Button btuRentaClear;
        private Button btuRentaAdd;
        private ComboBox cboRentaRoomID;
        private Button btuRentaDel;
        private DateTimePicker dtpStaet;
        private ComboBox cboRoomStatus;
        private TextBox txtRentaID;
        private Label label22;
    }
}