namespace apartment
{
    partial class Form2
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
            dgvTenant = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btuSearch = new Button();
            cboTenant = new ComboBox();
            cboNum = new ComboBox();
            cboStatus = new ComboBox();
            label4 = new Label();
            btuDef = new Button();
            label6 = new Label();
            dgvPament = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTenant).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPament).BeginInit();
            SuspendLayout();
            // 
            // dgvTenant
            // 
            dgvTenant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTenant.Location = new Point(12, 98);
            dgvTenant.Name = "dgvTenant";
            dgvTenant.RowHeadersWidth = 51;
            dgvTenant.Size = new Size(1157, 281);
            dgvTenant.TabIndex = 0;
            dgvTenant.CellContentClick += dgvTenant_CellContentClick;
            dgvTenant.CellMouseClick += dgvTenant_CellMouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "ชื่อผู้เช่า";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 38);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "หมายเลขห้อง";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(546, 38);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 3;
            label3.Text = "สถานะ";
            // 
            // btuSearch
            // 
            btuSearch.Location = new Point(734, 34);
            btuSearch.Name = "btuSearch";
            btuSearch.Size = new Size(143, 29);
            btuSearch.TabIndex = 6;
            btuSearch.Text = "ค้นหา";
            btuSearch.UseVisualStyleBackColor = true;
            btuSearch.Click += btuSearch_Click;
            // 
            // cboTenant
            // 
            cboTenant.FormattingEnabled = true;
            cboTenant.Location = new Point(73, 33);
            cboTenant.Name = "cboTenant";
            cboTenant.Size = new Size(252, 28);
            cboTenant.TabIndex = 8;
            cboTenant.SelectedIndexChanged += cboTenant_SelectedIndexChanged;
            // 
            // cboNum
            // 
            cboNum.FormattingEnabled = true;
            cboNum.Location = new Point(435, 33);
            cboNum.Name = "cboNum";
            cboNum.Size = new Size(105, 28);
            cboNum.TabIndex = 9;
            cboNum.SelectedIndexChanged += cboNum_SelectedIndexChanged;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(599, 34);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(105, 28);
            cboStatus.TabIndex = 10;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 75);
            label4.Name = "label4";
            label4.Size = new Size(114, 20);
            label4.TabIndex = 11;
            label4.Text = "รายละเอียดห้องพัก";
            // 
            // btuDef
            // 
            btuDef.Location = new Point(883, 34);
            btuDef.Name = "btuDef";
            btuDef.Size = new Size(143, 29);
            btuDef.TabIndex = 12;
            btuDef.Text = "ล้างค่า";
            btuDef.UseVisualStyleBackColor = true;
            btuDef.Click += btuDef_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 382);
            label6.Name = "label6";
            label6.Size = new Size(135, 20);
            label6.TabIndex = 13;
            label6.Text = "รายละเอียดชำระค่าเช่า";
            // 
            // dgvPament
            // 
            dgvPament.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPament.Location = new Point(12, 414);
            dgvPament.Name = "dgvPament";
            dgvPament.RowHeadersWidth = 51;
            dgvPament.Size = new Size(1157, 355);
            dgvPament.TabIndex = 14;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1181, 781);
            Controls.Add(dgvPament);
            Controls.Add(label6);
            Controls.Add(btuDef);
            Controls.Add(label4);
            Controls.Add(cboStatus);
            Controls.Add(cboNum);
            Controls.Add(cboTenant);
            Controls.Add(btuSearch);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvTenant);
            Name = "Form2";
            Text = "ค้นหาห้องพัก /  ชำระค่าเช่า";
            WindowState = FormWindowState.Maximized;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTenant).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPament).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTenant;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btuSearch;
        private DataGridView dgvRoom;
        private ComboBox cboTenant;
        private ComboBox cboNum;
        private ComboBox cboStatus;
        private Label label4;
        private Label label5;
        private Button btuDef;
        private Label label6;
        private DataGridView dgvPament;
    }
}