using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace apartment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
            LoadComboBoxes();
        }

        private void LoadTenantPayments(int tenantId)
        {
            using (SqlConnection conn = DB.apartment())
            {
                string sql = @"
            SELECT p.payment_id, p.amount, p.payment_date, p.installment, p.[month], p.[year]
            FROM Payment p
            INNER JOIN Rental r ON r.rental_id = p.rental_id
            WHERE r.tenant_id = @tenant_id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tenant_id", tenantId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvroom.DataSource = dt;
                }
            }
        }


        void loadData()
        {
            using (SqlConnection conn = DB.apartment())
            {

                // 1️⃣ Load DataGridView
                string sql = "sp_GetTenantBasic";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTenant.DataSource = dt;
                }


                dgvTenant.Columns[9].Visible = false; // room staus
                dgvTenant.Columns[10].Visible = false;
                dgvTenant.Columns[11].Visible = false;
                dgvTenant.Columns[12].Visible = false;
                dgvTenant.Columns[13].Visible = false;
                dgvTenant.Columns[14].Visible = false;
                dgvTenant.Columns[15].Visible = false; // model
                dgvTenant.Columns[17].Visible = false; // Date
                dgvTenant.Columns[18].Visible = false;
                dgvTenant.Columns[19].Visible = false;
                dgvTenant.Columns[21].Visible = false; // Dex
                dgvTenant.Columns[22].Visible = false;
                dgvTenant.Columns[24].Visible = false;
                dgvTenant.Columns[25].Visible = false;
                dgvTenant.Columns[26].Visible = false;
                dgvTenant.Columns[27].Visible = false;



                // 2️⃣ Load Type (จาก FacilityType)
                string sqlType = "SELECT * FROM FacilityType";
                DataTable dtType = new DataTable();
                using (SqlCommand cmdType = new SqlCommand(sqlType, conn))
                {
                    SqlDataAdapter daType = new SqlDataAdapter(cmdType);
                    daType.Fill(dtType);
                }

                cboType.DataSource = dtType;
                cboType.DisplayMember = "type_name";
                cboType.ValueMember = "type_id";
                cboType.SelectedIndex = -1; // ไม่เลือกค่าเริ่มต้น

                // 3️⃣ Load Room
                // Load Floor
                string sqlFloor = "SELECT DISTINCT floor FROM Room ORDER BY floor";
                DataTable dtFloor = new DataTable();
                using (SqlCommand cmdFloor = new SqlCommand(sqlFloor, conn))
                {
                    SqlDataAdapter daFloor = new SqlDataAdapter(cmdFloor);
                    daFloor.Fill(dtFloor);
                }

                cboFloor.DataSource = dtFloor;
                cboFloor.DisplayMember = "floor";
                cboFloor.ValueMember = "floor";
                cboFloor.SelectedIndex = -1; // ไม่เลือกค่าเริ่มต้น

                // Load Room
                string sqlRoom = "SELECT * FROM Room ORDER BY room_id";
                DataTable dtRoom = new DataTable();
                using (SqlCommand cmdRoom = new SqlCommand(sqlRoom, conn))
                {
                    SqlDataAdapter daRoom = new SqlDataAdapter(cmdRoom);
                    daRoom.Fill(dtRoom);
                }

                cboRoom.DataSource = dtRoom;
                cboRoom.DisplayMember = "room_id";
                cboRoom.ValueMember = "room_id";
                cboRoom.SelectedIndex = -1; // ไม่เลือกค่าเริ่มต้น




                // Payment DataGridView
                string sqlPayment = "SELECT *  FROM Payment;";
                using (SqlCommand cmdPayment = new SqlCommand(sqlPayment, conn))
                {
                    SqlDataAdapter daPayment = new SqlDataAdapter(cmdPayment);
                    DataTable dtPayment = new DataTable();
                    daPayment.Fill(dtPayment);

                    dgvroom.DataSource = dtPayment;
                }
                conn.Close();



            }
        }

        void loaddgvroom(int rowIndex)
        {
            txtID.Text = dgvroom.Rows[rowIndex].Cells["payment_id"].Value.ToString();
            txtAmount.Text = dgvroom.Rows[rowIndex].Cells["amount"].Value.ToString();
            txtInstallment.Text = dgvroom.Rows[rowIndex].Cells["installment"].Value.ToString();
            txtmoanth.Text = dgvroom.Rows[rowIndex].Cells["month"].Value.ToString();
            txtYear.Text = dgvroom.Rows[rowIndex].Cells["year"].Value.ToString();
        }

        void ClearFields()
        {
            txtBaht.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCitizenID.Clear();
            txtDescription.Clear();
            dtpBirth.Value = DateTime.Now;
            cboType.SelectedIndex = -1;
            cboFloor.SelectedIndex = -1;
            cboRoom.SelectedIndex = -1;
            txtBaht.Clear();
       }

        private void button1_Click(object sender, EventArgs e)
        {
            //btuAdds
            ClearFields();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadTenant(e.RowIndex);
            }
        }


        private void LoadComboBoxes()
        {
            using (SqlConnection conn = DB.apartment())
            {
                // Type
                DataTable dtType = new DataTable();
                new SqlDataAdapter("SELECT * FROM FacilityType", conn).Fill(dtType);
                cboType.DataSource = dtType;
                cboType.DisplayMember = "type_name";
                cboType.ValueMember = "type_id";
                cboType.SelectedIndex = -1;

                

                // Floor
                DataTable dtFloor = new DataTable();
                new SqlDataAdapter("SELECT DISTINCT floor FROM Room ORDER BY floor", conn).Fill(dtFloor);
                cboFloor.DataSource = dtFloor;
                cboFloor.DisplayMember = "floor";
                cboFloor.ValueMember = "floor";
                cboFloor.SelectedIndex = -1;


                // Room
                DataTable dtRoom = new DataTable();
                new SqlDataAdapter("SELECT * FROM Room ORDER BY room_id", conn).Fill(dtRoom);
                cboRoom.DataSource = dtRoom;
                cboRoom.DisplayMember = "room_id";
                cboRoom.ValueMember = "room_id";
                cboRoom.SelectedIndex = -1;

                
            }
        }



        void LoadTenant(int rowIndex)
        {
            var row = dgvTenant.Rows[rowIndex];
            txtName.Text = row.Cells["full_name"].Value.ToString();
            txtPhone.Text = row.Cells["phone"].Value.ToString();
            txtAddress.Text = row.Cells["address"].Value.ToString();
            txtCitizenID.Text = row.Cells["citizen_id"].Value.ToString();
            dtpBirth.Value = Convert.ToDateTime(row.Cells["birth_date"].Value);
            txtDescription.Text = row.Cells["t_description"].Value.ToString();
            txtBaht.Text = row.Cells["price"].Value?.ToString() ?? "";

            // ตั้งค่า ComboBox
            cboType.SelectedValue = row.Cells["ft_type_id"].Value != DBNull.Value ? row.Cells["ft_type_id"].Value : -1;
            cboFloor.SelectedValue = row.Cells["floor"].Value != DBNull.Value ? row.Cells["floor"].Value : -1;
            cboRoom.SelectedValue = row.Cells["room_id"].Value != DBNull.Value ? row.Cells["room_id"].Value : -1;

            // ✅ Test ค่า
            MessageBox.Show(
                $"txtBaht: {txtBaht.Text}\n" +
                $"cboType.SelectedValue: {cboType.SelectedValue}\n" +
                $"cboType.Text: {cboType.Text}\n" +
                $"cboFloor.SelectedValue: {cboFloor.SelectedValue}\n" +
                $"cboFloor.Text: {cboFloor.Text}\n" +
                $"cboRoom.SelectedValue: {cboRoom.SelectedValue}\n" +
                $"cboRoom.Text: {cboRoom.Text}"
            );
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //txtName
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboType

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            //txtPhone
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            //txtAddress
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            //txtId
        }

        private void cboFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboFloor
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboRoom
        }

        private void cboTypeRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboTypeRoom
        }

        private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboPayment
        }

        private void btuDel_Click(object sender, EventArgs e)
        {
            if (dgvTenant.CurrentRow == null) return;

            int tenantId = Convert.ToInt32(dgvTenant.CurrentRow.Cells["tenant_id"].Value);

            if (MessageBox.Show("คุณต้องการลบผู้เช่านี้หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteTenant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenant_id", tenantId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("ลบผู้เช่าสำเร็จ");
            ClearFields();
            loadData();
        }


        private void btuEdit_Click(object sender, EventArgs e)
        {
            // btuEdit
            if (dgvTenant.CurrentRow == null) return;

            // 1️⃣ ตรวจสอบ TextBox ว่าง
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้เช่า");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("กรุณากรอกเบอร์โทร");
                txtPhone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("กรุณากรอกที่อยู่");
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCitizenID.Text))
            {
                MessageBox.Show("กรุณากรอกเลขบัตรประชาชน");
                txtCitizenID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBaht.Text) || !decimal.TryParse(txtBaht.Text, out decimal price))
            {
                MessageBox.Show("กรุณากรอกราคาที่ถูกต้อง");
                txtBaht.Focus();
                return;
            }

            // 2️⃣ ตรวจสอบ ComboBox
            if (cboType.SelectedValue == null)
            {
                MessageBox.Show("กรุณาเลือกประเภทอุปกรณ์");
                cboType.Focus();
                return;
            }

            if (cboRoom.SelectedValue == null)
            {
                MessageBox.Show("กรุณาเลือกห้อง");
                cboRoom.Focus();
                return;
            }

            // 3️⃣ ตรวจสอบ DateTimePicker
            if (dtpBirth.Value == null)
            {
                MessageBox.Show("กรุณาเลือกวันเกิด");
                dtpBirth.Focus();
                return;
            }

            // ดึง tenant_id จาก DataGridView
            int tenantId = Convert.ToInt32(dgvTenant.CurrentRow.Cells["tenant_id"].Value);

            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditTenant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tenant_id", tenantId);
                    cmd.Parameters.AddWithValue("@full_name", txtName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@citizen_id", txtCitizenID.Text);
                    cmd.Parameters.AddWithValue("@birth_date", dtpBirth.Value.Date);
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@type_id", Convert.ToInt32(cboType.SelectedValue));
                    cmd.Parameters.AddWithValue("@room_id", Convert.ToInt32(cboRoom.SelectedValue));
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            MessageBox.Show("แก้ไขข้อมูลผู้เช่าสำเร็จ");
            ClearFields();
            loadData();
        }



        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            //txtDate
        }

        private void txtInstallment_TextChanged(object sender, EventArgs e)
        {
            //txtInstallment
        }

        private void cboTypeRoom2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboTypeRoom2
        }

        private void cboPayment2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboPayment2
        }

        private void txtBaht_TextChanged(object sender, EventArgs e)
        {
            //txtBaht
        }

        private void btuDel2_Click(object sender, EventArgs e)
        {
            //btuDel2
        }

        private void btuEdit2_Click(object sender, EventArgs e)
        {
            //btuEdit2
        }

        private void btuSave2_Click(object sender, EventArgs e)
        {
            //btuSave2
        }

        private void dgvroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvroom
            if (e.RowIndex >= 0)
            {
                loaddgvroom(e.RowIndex);
            }

        }

        private void dgvTenant_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }



        private void btuAdd_Click(object sender, EventArgs e)
        {
            // 🧩 ตรวจสอบ TextBox
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("กรุณากรอกชื่อผู้เช่า"); txtName.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) { MessageBox.Show("กรุณากรอกเบอร์โทร"); txtPhone.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) { MessageBox.Show("กรุณากรอกที่อยู่"); txtAddress.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtCitizenID.Text)) { MessageBox.Show("กรุณากรอกเลขบัตรประชาชน"); txtCitizenID.Focus(); return; }
            if (!decimal.TryParse(txtBaht.Text, out decimal price)) { MessageBox.Show("กรุณากรอกราคาที่ถูกต้อง"); txtBaht.Focus(); return; }

            // 🧩 ตรวจสอบค่า ComboBox
            if (string.IsNullOrWhiteSpace(cboType.Text) || string.IsNullOrWhiteSpace(cboFloor.Text) || string.IsNullOrWhiteSpace(cboRoom.Text))
            {
                MessageBox.Show("กรุณาเลือกหรือกรอกค่าใน Type / Floor / Room");
                return;
            }

            // --- แปลงค่า ---
            int typeId, floor, roomId;

            // ✅ cboType ต้องเลือกจากรายการ (SelectedValue)
            if (cboType.SelectedValue == null || !int.TryParse(cboType.SelectedValue.ToString(), out typeId))
            {
                MessageBox.Show("กรุณาเลือก Type จากรายการที่มี");
                cboType.Focus(); return;
            }

            // ✅ cboFloor และ cboRoom สามารถพิมพ์ได้
            if (!int.TryParse(cboFloor.Text, out floor))
            {
                MessageBox.Show("ค่า Floor ต้องเป็นตัวเลขเท่านั้น");
                cboFloor.Focus(); return;
            }

            if (!int.TryParse(cboRoom.Text, out roomId))
            {
                MessageBox.Show("ค่า Room ต้องเป็นตัวเลขเท่านั้น");
                cboRoom.Focus(); return;
            }

            // --- บันทึกข้อมูล ---
            using (SqlConnection conn = DB.apartment())
            using (SqlCommand cmd = new SqlCommand("sp_AddTenant", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@full_name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@citizen_id", txtCitizenID.Text);
                cmd.Parameters.AddWithValue("@birth_date", dtpBirth.Value.Date);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@type_id", typeId);
                cmd.Parameters.AddWithValue("@floor", floor);
                cmd.Parameters.AddWithValue("@room_id", roomId);
                cmd.Parameters.AddWithValue("@price", price);

                
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("เพิ่มข้อมูลผู้เช่าสำเร็จ");
            ClearFields();
            loadData();
        }



        private void btuAdd2_Click(object sender, EventArgs e)
        {
            // btuAdd2
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private bool ValidatePaymentFields()
        {
            // ตรวจ Amount
            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง");
                txtAmount.Focus();
                return false;
            }

            // ตรวจ Installment
            if (string.IsNullOrWhiteSpace(txtInstallment.Text) || !int.TryParse(txtInstallment.Text, out _))
            {
                MessageBox.Show("กรุณากรอกงวดที่ถูกต้อง");
                txtInstallment.Focus();
                return false;
            }

            // ตรวจ Month (txtmoanth)
            if (string.IsNullOrWhiteSpace(txtmoanth.Text) || !int.TryParse(txtmoanth.Text, out int month) || month < 1 || month > 12)
            {
                MessageBox.Show("กรุณากรอกเดือนที่ถูกต้อง (1-12)");
                txtmoanth.Focus();
                return false;
            }

            // ตรวจ Year
            if (string.IsNullOrWhiteSpace(txtYear.Text) || !int.TryParse(txtYear.Text, out int year) || year < 2000)
            {
                MessageBox.Show("กรุณากรอกปีที่ถูกต้อง");
                txtYear.Focus();
                return false;
            }

            return true;
        }


        private void btuAdd2_Click_1(object sender, EventArgs e)
        {
            if (dgvTenant.CurrentRow == null) return;

            // บังคับกรอกข้อมูล Payment
            if (!ValidatePaymentFields()) return;

            int tenantId = Convert.ToInt32(dgvTenant.CurrentRow.Cells["tenant_id"].Value);

            // ดึง rental_id ล่าสุดของ tenant
            int rentalId;
            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 1 rental_id FROM Rental WHERE tenant_id=@tenant_id ORDER BY rental_id DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@tenant_id", tenantId);
                    rentalId = (int)cmd.ExecuteScalar();
                }
                conn.Close();
            }

            // เพิ่ม Payment
            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand("sp_AddPayment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rental_id", rentalId);
                    cmd.Parameters.AddWithValue("@amount", decimal.Parse(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@installment", int.Parse(txtInstallment.Text));
                    cmd.Parameters.AddWithValue("@month", int.Parse(txtmoanth.Text));
                    cmd.Parameters.AddWithValue("@year", int.Parse(txtYear.Text));

                    cmd.ExecuteNonQuery();


                }
                conn.Close();
            }

            LoadTenantPayments(tenantId);
            ClearFields();
        }

        private void btuEdit2_Click_1(object sender, EventArgs e)
        {
            // 1️⃣ ตรวจสอบ TextBox ว่าง
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("กรุณากรอก ID ของ Payment");
                txtID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("กรุณากรอกจำนวนเงินที่ถูกต้อง");
                txtAmount.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInstallment.Text) || !int.TryParse(txtInstallment.Text, out int inst))
            {
                MessageBox.Show("กรุณากรอกงวดที่ถูกต้อง");
                txtInstallment.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtmoanth.Text) || !int.TryParse(txtmoanth.Text, out int month))
            {
                MessageBox.Show("กรุณากรอกเดือนที่ถูกต้อง");
                txtmoanth.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtYear.Text) || !int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("กรุณากรอกปีที่ถูกต้อง");
                txtYear.Focus();
                return;
            }

            int paymentId = Convert.ToInt32(txtID.Text);

            // 2️⃣ เรียกใช้ SP แก้ไข Payment
            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand("sp_EditPayment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@payment_id", paymentId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@installment", inst);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    cmd.ExecuteNonQuery();

                }
            }

            // 3️⃣ โหลด Payment ของ Tenant อีกครั้ง
            if (dgvTenant.CurrentRow != null)
                LoadTenantPayments(Convert.ToInt32(dgvTenant.CurrentRow.Cells["tenant_id"].Value));

            MessageBox.Show("แก้ไขข้อมูล Payment สำเร็จ");
            ClearFields();
            loadData();
        }


        private void btuDel2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)) return;

            int paymentId = Convert.ToInt32(txtID.Text);

            if (MessageBox.Show("คุณต้องการลบข้อมูลชำระเงินนี้หรือไม่?", "ยืนยัน", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (SqlConnection conn = DB.apartment())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeletePayment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@payment_id", paymentId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            if (dgvTenant.CurrentRow != null)
                LoadTenantPayments(Convert.ToInt32(dgvTenant.CurrentRow.Cells["tenant_id"].Value));
        }

        private void btuClear2_Click(object sender, EventArgs e)
        {
            clear2();
        }

        void clear2()
        {
            txtID.Clear();
            txtAmount.Clear();
            txtInstallment.Clear();
            txtmoanth.Clear();
            txtYear.Clear();
        }
    }
}
