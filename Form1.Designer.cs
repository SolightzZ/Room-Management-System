namespace apartment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            label17 = new Label();
            dtpBirth = new DateTimePicker();
            txtDescription = new TextBox();
            txtCitizenID = new TextBox();
            txtBirth = new Label();
            label4 = new Label();
            txtAddress = new TextBox();
            label3 = new Label();
            txtPhone = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label1 = new Label();
            cboFloor = new ComboBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            label11 = new Label();
            btuAdd = new Button();
            txtBaht = new TextBox();
            btuClear = new Button();
            btuEdit = new Button();
            btuDel = new Button();
            cboType = new ComboBox();
            label6 = new Label();
            cboRoom = new ComboBox();
            label5 = new Label();
            dgvTenant = new DataGridView();
            dgvroom = new DataGridView();
            label7 = new Label();
            label8 = new Label();
            groupBox3 = new GroupBox();
            txtID = new TextBox();
            label10 = new Label();
            txtmoanth = new TextBox();
            label16 = new Label();
            txtInstallment = new TextBox();
            txtAmount = new TextBox();
            btuAdd2 = new Button();
            txtYear = new TextBox();
            btuClear2 = new Button();
            btuEdit2 = new Button();
            btuDel2 = new Button();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvroom).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(dtpBirth);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(txtCitizenID);
            groupBox1.Controls.Add(txtBirth);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(483, 283);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "ข้อมูลผู้เช่า";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, 223);
            label17.Name = "label17";
            label17.Size = new Size(115, 20);
            label17.TabIndex = 13;
            label17.Text = "รายละเอียดเพิ่มเติม";
            // 
            // dtpBirth
            // 
            dtpBirth.Location = new Point(128, 154);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(328, 27);
            dtpBirth.TabIndex = 12;
            dtpBirth.ValueChanged += dtpBirth_ValueChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(128, 220);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(328, 27);
            txtDescription.TabIndex = 11;
            // 
            // txtCitizenID
            // 
            txtCitizenID.Location = new Point(128, 187);
            txtCitizenID.Name = "txtCitizenID";
            txtCitizenID.Size = new Size(328, 27);
            txtCitizenID.TabIndex = 10;
            txtCitizenID.TextChanged += textBox1_TextChanged_1;
            // 
            // txtBirth
            // 
            txtBirth.AutoSize = true;
            txtBirth.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            txtBirth.Location = new Point(71, 154);
            txtBirth.Name = "txtBirth";
            txtBirth.Size = new Size(47, 20);
            txtBirth.TabIndex = 9;
            txtBirth.Text = "วันเกิด";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 82);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 7;
            label4.Text = "โทรศํพท์";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(128, 113);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(328, 27);
            txtAddress.TabIndex = 6;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 120);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 5;
            label3.Text = "ที่อยู่ทะเบียน";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(128, 75);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(328, 27);
            txtPhone.TabIndex = 4;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 190);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 3;
            label2.Text = "หมายเลขประชาชน";
            // 
            // txtName
            // 
            txtName.Location = new Point(128, 36);
            txtName.Name = "txtName";
            txtName.Size = new Size(328, 27);
            txtName.TabIndex = 2;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 43);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 1;
            label1.Text = "ชื่อ-นามสกุล";
            // 
            // cboFloor
            // 
            cboFloor.FormattingEnabled = true;
            cboFloor.Location = new Point(128, 72);
            cboFloor.Name = "cboFloor";
            cboFloor.Size = new Size(328, 28);
            cboFloor.TabIndex = 9;
            cboFloor.SelectedIndexChanged += cboFloor_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(88, 80);
            label9.Name = "label9";
            label9.Size = new Size(27, 20);
            label9.TabIndex = 1;
            label9.Text = "ชั้น";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(btuAdd);
            groupBox2.Controls.Add(txtBaht);
            groupBox2.Controls.Add(btuClear);
            groupBox2.Controls.Add(btuEdit);
            groupBox2.Controls.Add(btuDel);
            groupBox2.Controls.Add(cboType);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cboRoom);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(cboFloor);
            groupBox2.Location = new Point(501, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(483, 286);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "ข้อมูลห้องพัก";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(54, 147);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 19;
            label11.Text = "จำนวนเงิน";
            // 
            // btuAdd
            // 
            btuAdd.Location = new Point(54, 184);
            btuAdd.Name = "btuAdd";
            btuAdd.Size = new Size(94, 29);
            btuAdd.TabIndex = 17;
            btuAdd.Text = "เพิ่ม";
            btuAdd.UseVisualStyleBackColor = true;
            btuAdd.Click += btuAdd_Click;
            // 
            // txtBaht
            // 
            txtBaht.Location = new Point(128, 140);
            txtBaht.Name = "txtBaht";
            txtBaht.Size = new Size(328, 27);
            txtBaht.TabIndex = 14;
            txtBaht.TextChanged += txtBaht_TextChanged;
            // 
            // btuClear
            // 
            btuClear.Location = new Point(356, 184);
            btuClear.Name = "btuClear";
            btuClear.Size = new Size(94, 29);
            btuClear.TabIndex = 10;
            btuClear.Text = "ล้าง";
            btuClear.UseVisualStyleBackColor = true;
            btuClear.Click += button1_Click;
            // 
            // btuEdit
            // 
            btuEdit.Location = new Point(256, 184);
            btuEdit.Name = "btuEdit";
            btuEdit.Size = new Size(94, 29);
            btuEdit.TabIndex = 11;
            btuEdit.Text = "แก้ไข";
            btuEdit.UseVisualStyleBackColor = true;
            btuEdit.Click += btuEdit_Click;
            // 
            // btuDel
            // 
            btuDel.Location = new Point(156, 184);
            btuDel.Name = "btuDel";
            btuDel.Size = new Size(94, 29);
            btuDel.TabIndex = 12;
            btuDel.Text = "ลบ";
            btuDel.UseVisualStyleBackColor = true;
            btuDel.Click += btuDel_Click;
            // 
            // cboType
            // 
            cboType.FormattingEnabled = true;
            cboType.Location = new Point(128, 38);
            cboType.Name = "cboType";
            cboType.Size = new Size(328, 28);
            cboType.TabIndex = 13;
            cboType.SelectedIndexChanged += cboType_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 46);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 12;
            label6.Text = "ประเภท";
            // 
            // cboRoom
            // 
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(128, 106);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(328, 28);
            cboRoom.TabIndex = 11;
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(83, 114);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 10;
            label5.Text = "ห้อง";
            // 
            // dgvTenant
            // 
            dgvTenant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenant.Location = new Point(12, 321);
            dgvTenant.Name = "dgvTenant";
            dgvTenant.RowHeadersWidth = 51;
            dgvTenant.Size = new Size(1754, 333);
            dgvTenant.TabIndex = 10;
            dgvTenant.CellContentClick += dataGridView1_CellContentClick;
            dgvTenant.CellMouseClick += dgvTenant_CellMouseClick;
            // 
            // dgvroom
            // 
            dgvroom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvroom.Location = new Point(12, 680);
            dgvroom.Name = "dgvroom";
            dgvroom.RowHeadersWidth = 51;
            dgvroom.Size = new Size(1754, 274);
            dgvroom.TabIndex = 11;
            dgvroom.CellContentClick += dgvroom_CellContentClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 298);
            label7.Name = "label7";
            label7.Size = new Size(101, 20);
            label7.TabIndex = 9;
            label7.Text = "รายละเอียดผู้เช่า";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 657);
            label8.Name = "label8";
            label8.Size = new Size(153, 20);
            label8.TabIndex = 12;
            label8.Text = "รายละเอียดการจ่ายค่าเช่า";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtID);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(txtmoanth);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(txtInstallment);
            groupBox3.Controls.Add(txtAmount);
            groupBox3.Controls.Add(btuAdd2);
            groupBox3.Controls.Add(txtYear);
            groupBox3.Controls.Add(btuClear2);
            groupBox3.Controls.Add(btuEdit2);
            groupBox3.Controls.Add(btuDel2);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Location = new Point(1283, 13);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(483, 286);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "ข้อมูลการจ่ายค่าเช่า";
            // 
            // txtID
            // 
            txtID.Location = new Point(128, 39);
            txtID.Name = "txtID";
            txtID.Size = new Size(328, 27);
            txtID.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(50, 46);
            label10.Name = "label10";
            label10.Size = new Size(74, 20);
            label10.TabIndex = 24;
            label10.Text = "รหัสการเช่า";
            // 
            // txtmoanth
            // 
            txtmoanth.Location = new Point(128, 138);
            txtmoanth.Name = "txtmoanth";
            txtmoanth.Size = new Size(328, 27);
            txtmoanth.TabIndex = 23;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(79, 178);
            label16.Name = "label16";
            label16.Size = new Size(39, 20);
            label16.TabIndex = 22;
            label16.Text = "รายปี";
            // 
            // txtInstallment
            // 
            txtInstallment.Location = new Point(128, 105);
            txtInstallment.Name = "txtInstallment";
            txtInstallment.Size = new Size(328, 27);
            txtInstallment.TabIndex = 21;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(128, 72);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(328, 27);
            txtAmount.TabIndex = 20;
            // 
            // btuAdd2
            // 
            btuAdd2.Location = new Point(56, 223);
            btuAdd2.Name = "btuAdd2";
            btuAdd2.Size = new Size(94, 29);
            btuAdd2.TabIndex = 17;
            btuAdd2.Text = "เพิ่ม";
            btuAdd2.UseVisualStyleBackColor = true;
            btuAdd2.Click += btuAdd2_Click_1;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(128, 171);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(328, 27);
            txtYear.TabIndex = 14;
            // 
            // btuClear2
            // 
            btuClear2.Location = new Point(356, 223);
            btuClear2.Name = "btuClear2";
            btuClear2.Size = new Size(94, 29);
            btuClear2.TabIndex = 10;
            btuClear2.Text = "ล้าง";
            btuClear2.UseVisualStyleBackColor = true;
            btuClear2.Click += btuClear2_Click;
            // 
            // btuEdit2
            // 
            btuEdit2.Location = new Point(256, 223);
            btuEdit2.Name = "btuEdit2";
            btuEdit2.Size = new Size(94, 29);
            btuEdit2.TabIndex = 11;
            btuEdit2.Text = "แก้ไข";
            btuEdit2.UseVisualStyleBackColor = true;
            btuEdit2.Click += btuEdit2_Click_1;
            // 
            // btuDel2
            // 
            btuDel2.Location = new Point(156, 223);
            btuDel2.Name = "btuDel2";
            btuDel2.Size = new Size(94, 29);
            btuDel2.TabIndex = 12;
            btuDel2.Text = "ลบ";
            btuDel2.UseVisualStyleBackColor = true;
            btuDel2.Click += btuDel2_Click_1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(50, 75);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 12;
            label12.Text = "จำนวนเงิน";
            label12.Click += label12_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(58, 145);
            label13.Name = "label13";
            label13.Size = new Size(60, 20);
            label13.TabIndex = 10;
            label13.Text = "รายเดือน";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(78, 105);
            label14.Name = "label14";
            label14.Size = new Size(40, 20);
            label14.TabIndex = 1;
            label14.Text = "งวดที่";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1778, 966);
            Controls.Add(groupBox3);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dgvroom);
            Controls.Add(dgvTenant);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "หน้าเพิ่มข้อมูล / การจ่ายค่าเช่า";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvroom).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtPhone;
        private Label label3;
        private TextBox txtId;
        private Label label4;
        private TextBox txtAddress;
        private ComboBox cboFloor;
        private Label label9;
        private GroupBox groupBox2;
        private ComboBox cboType;
        private Label label6;
        private ComboBox cboRoom;
        private Label label5;
        private Button btuClear;
        private Button btuEdit;
        private Button btuDel;
        private DataGridView dgvTenant;
        private DataGridView dgvroom;
        private Label label7;
        private Label label8;
        private TextBox txtBaht;
        private Button btuAdd;
        private TextBox txtCitizenID;
        private Label txtBirth;
        private TextBox txtDescription;
        private DateTimePicker dtpBirth;
        private Label label17;
        private Label label11;
        private GroupBox groupBox3;
        private Button btuAdd2;
        private TextBox txtYear;
        private Button btuClear2;
        private Button btuEdit2;
        private Button btuDel2;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtAmount;
        private TextBox txtInstallment;
        private TextBox txtmoanth;
        private Label label16;
        private TextBox txtID;
        private Label label10;
    }
}
