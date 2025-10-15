using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace apartment
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowRoom();
            ShowFacilityType();
            ShowFacility();

            LoadTenants();
            LoadRooms();
            LoadRentals();

        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ป้องกันคลิกที่ header หรือ row ว่าง
            if (e.RowIndex < 0) return;

            var row = dgvRoom.Rows[e.RowIndex];
            txtRoomID.Text = row.Cells["room_id"].Value?.ToString() ?? "";
            txtRoomfloor.Text = row.Cells["floor"].Value?.ToString() ?? "";

            string statusValue = row.Cells["status"].Value?.ToString();
            if (statusValue == "ว่าง" || statusValue == "มีผู้เช่า")
            {
                cboRoomStatus.SelectedItem = statusValue;
            }
            else
            {
                cboRoomStatus.SelectedIndex = -1;
            }
        }


        private void dgvType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvType.CurrentRow != null)
            {
                txtFaciltyTypeID.Text = dgvType.CurrentRow.Cells["type_id"].Value.ToString();
                txtFaciltyTypeName.Text = dgvType.CurrentRow.Cells["type_name"].Value.ToString();
                txtFaciltyTypeDesc.Text = dgvType.CurrentRow.Cells["description"].Value.ToString();
            }
        }

        private void dgvFacility_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacility.CurrentRow != null)
            {
                txtFID.Text = dgvFacility.CurrentRow.Cells["facility_id"].Value.ToString();
                txtFbrand.Text = dgvFacility.CurrentRow.Cells["brand"].Value.ToString();
                txtFmodel.Text = dgvFacility.CurrentRow.Cells["model"].Value.ToString();
                txtFPrice.Text = dgvFacility.CurrentRow.Cells["price"].Value.ToString();
                txtDes.Text = dgvFacility.CurrentRow.Cells["description"].Value.ToString();
                cboRoomid.SelectedValue = Convert.ToInt32(dgvFacility.CurrentRow.Cells["room_id"].Value);
                cboTypeID.SelectedValue = Convert.ToInt32(dgvFacility.CurrentRow.Cells["type_id"].Value);




            }
        }

        private void dgvRenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtRentaID.Text = dgvRenta.Rows[e.RowIndex].Cells["rental_id"].Value.ToString();
                cboRentaTanantID.SelectedValue = dgvRenta.Rows[e.RowIndex].Cells["tenant_id"].Value;
                cboRentaRoomID.SelectedValue = dgvRenta.Rows[e.RowIndex].Cells["room_id"].Value;
                dtpStaet.Value = Convert.ToDateTime(dgvRenta.Rows[e.RowIndex].Cells["start_date"].Value);
                dtpEnd.Value = Convert.ToDateTime(dgvRenta.Rows[e.RowIndex].Cells["end_date"].Value);
            }
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------

        void ShowRoom()
        {
            SqlConnection conn = DB.apartment();
            string sql = "SELECT * FROM Room";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvRoom.DataSource = dt;

            // Room ID
            txtRoomID.Clear();

            // Status ComboBox
            cboRoomStatus.DropDownStyle = ComboBoxStyle.DropDown;
            cboRoomStatus.Items.Clear();
            cboRoomStatus.Items.Add("ว่าง");
            cboRoomStatus.Items.Add("มีผู้เช่า");
            cboRoomStatus.SelectedIndex = -1;

            conn.Close();
        }



        private void btuRoomAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomID.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข");
                return;
            }



            SqlConnection conn = DB.apartment();

            // ตรวจสอบว่าค่าใหม่ยังไม่มีใน DB
            string checkSql = "SELECT COUNT(*) FROM Room WHERE room_id=@id";
            SqlCommand cmdCheck = new SqlCommand(checkSql, conn);
            cmdCheck.Parameters.AddWithValue("@id", txtRoomID.Text); // <<< ใช้ TextBox
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (count == 0)
            {
                string sql = "INSERT INTO Room (room_id, floor, status) VALUES (@id, @floor, @status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", txtRoomID.Text); // <<< ใช้ TextBox
                cmd.Parameters.AddWithValue("@floor", txtRoomfloor.Text);
                cmd.Parameters.AddWithValue("@status", cboRoomStatus.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Room ID นี้มีอยู่แล้ว");
            }

            conn.Close();
            ShowRoom();
        }

        private void btuRoomDel_Click(object sender, EventArgs e)
        {
            if (txtRoomID.Text == "")
            {
                MessageBox.Show("กรุณากรอกหรือเลือก Room ID");
                return;
            }

            SqlConnection conn = DB.apartment();

            // 1. ลบ Payment ที่เกี่ยวข้องกับ Rental ของ Room
            SqlCommand cmdPayment = new SqlCommand(
                "DELETE FROM Payment WHERE rental_id IN (SELECT rental_id FROM Rental WHERE room_id=@roomId)", conn);
            cmdPayment.Parameters.AddWithValue("@roomId", txtRoomID.Text);
            cmdPayment.ExecuteNonQuery();

            // 2. ลบ Rental ของ Room
            SqlCommand cmdRental = new SqlCommand("DELETE FROM Rental WHERE room_id=@id", conn);
            cmdRental.Parameters.AddWithValue("@id", txtRoomID.Text);
            cmdRental.ExecuteNonQuery();

            // 3. ลบ Facility ของ Room
            SqlCommand cmdFacility = new SqlCommand("DELETE FROM Facility WHERE room_id=@id", conn);
            cmdFacility.Parameters.AddWithValue("@id", txtRoomID.Text);
            cmdFacility.ExecuteNonQuery();

            // 4. ลบ Room
            SqlCommand cmdRoom = new SqlCommand("DELETE FROM Room WHERE room_id=@id", conn);
            cmdRoom.Parameters.AddWithValue("@id", txtRoomID.Text);
            cmdRoom.ExecuteNonQuery();

            conn.Close();

            ShowRoom();
        }



        private void btuRoomClear_Click(object sender, EventArgs e)
        {
            txtRoomID.Clear(); // แค่ล้างค่า ไม่ต้องผูก DataSource
            txtRoomfloor.Clear();
            cboRoomStatus.SelectedIndex = -1;
        }

        private void btuRoomEdit_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Room SET floor=@floor, status=@status WHERE room_id=@id";
            SqlConnection conn = DB.apartment();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@id", txtRoomID.Text);
            cmd.Parameters.AddWithValue("@floor", txtRoomfloor.Text);

            // ใช้ SelectedItem หรือ Text แทน SelectedValue
            string statusValue = cboRoomStatus.SelectedItem?.ToString() ?? cboRoomStatus.Text;
            cmd.Parameters.AddWithValue("@status", statusValue);

            cmd.ExecuteNonQuery();
            conn.Close();

            ShowRoom();
        }


        // ------------------------------------------------------------------------------------------------------------------------------------------


        void ShowFacilityType()
        {
            SqlConnection conn = DB.apartment();
            string sql = "SELECT * FROM FacilityType";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvType.DataSource = dt;

            cboTypeID.DropDownStyle = ComboBoxStyle.DropDown;
            cboTypeID.DisplayMember = "type_name";
            cboTypeID.ValueMember = "type_id";
            cboTypeID.DataSource = dt;

            conn.Close();
        }


        private void btuTypeAdd_Click(object sender, EventArgs e)
        {
            string typeName = txtFaciltyTypeName.Text.Trim();
            string typeDesc = txtFaciltyTypeDesc.Text.Trim();

            if (string.IsNullOrWhiteSpace(typeName))
            {
                MessageBox.Show("กรุณากรอกชื่อประเภทก่อน");
                return;
            }

            SqlConnection conn = DB.apartment();

            // ตรวจสอบว่าชื่อประเภทนี้ยังไม่มีใน DB
            string checkSql = "SELECT COUNT(*) FROM FacilityType WHERE type_name=@name";
            SqlCommand cmdCheck = new SqlCommand(checkSql, conn);
            cmdCheck.Parameters.AddWithValue("@name", typeName);
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (count == 0)
            {
                // สร้าง type_id ใหม่โดยใช้ MAX(type_id)+1
                SqlCommand cmdMax = new SqlCommand("SELECT ISNULL(MAX(type_id),0)+1 FROM FacilityType", conn);
                int newId = Convert.ToInt32(cmdMax.ExecuteScalar());

                // Insert ข้อมูลใหม่
                string sql = "INSERT INTO FacilityType (type_id, type_name, description) VALUES (@id, @name, @desc)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", newId);
                cmd.Parameters.AddWithValue("@name", typeName);
                cmd.Parameters.AddWithValue("@desc", typeDesc);
                cmd.ExecuteNonQuery();

                MessageBox.Show("เพิ่มประเภทเรียบร้อยแล้ว");
            }
            else
            {
                MessageBox.Show("ชื่อประเภทนี้มีอยู่แล้ว");
            }

            conn.Close();

            ShowFacilityType(); // อัพเดต DataGridView
            txtFaciltyTypeName.Clear();
            txtFaciltyTypeDesc.Clear();
        }



        private void btuTypeDel_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DB.apartment();
            string sql = "DELETE FROM FacilityType WHERE type_id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", txtFaciltyTypeID.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            ShowFacilityType();
        }

        private void btuTypeClear_Click(object sender, EventArgs e)
        {
            txtFaciltyTypeID.Clear();
            txtFaciltyTypeName.Clear();
            txtFaciltyTypeDesc.Clear();
        }

        private void btuTypeEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DB.apartment();
            string sql = "UPDATE FacilityType SET type_name=@name, description=@desc WHERE type_id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", txtFaciltyTypeID.Text);
            cmd.Parameters.AddWithValue("@name", txtFaciltyTypeName.Text);
            cmd.Parameters.AddWithValue("@desc", txtFaciltyTypeDesc.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            ShowFacilityType();
        }



        // ------------------------------------------------------------------------------------------------------------------------------------------

        void ShowFacility()
        {
            SqlConnection conn = DB.apartment();
            string sql = "SELECT * FROM Facility";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvFacility.DataSource = dt;

            // ComboBox Room
            SqlDataAdapter daRoom = new SqlDataAdapter("SELECT * FROM Room", conn);
            DataTable dtRoom = new DataTable();
            daRoom.Fill(dtRoom);
            cboRoomid.DropDownStyle = ComboBoxStyle.DropDown;
            cboRoomid.DisplayMember = "room_id";
            cboRoomid.ValueMember = "room_id";
            cboRoomid.DataSource = dtRoom;

            // ComboBox Type
            SqlDataAdapter daType = new SqlDataAdapter("SELECT type_id, type_name FROM FacilityType", conn);
            DataTable dtType = new DataTable();
            daType.Fill(dtType);
            cboTypeID.DropDownStyle = ComboBoxStyle.DropDown;
            cboTypeID.DisplayMember = "type_name";
            cboTypeID.ValueMember = "type_id";
            cboTypeID.DataSource = dtType;

            conn.Close();
        }

        private int GetNextFacilityId()
        {
            SqlConnection conn = DB.apartment(); // สร้าง connection
            SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(facility_id), 0) + 1 FROM Facility", conn);

            int nextId = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return nextId;

        }

        private void btuFacilityAdd_Click(object sender, EventArgs e)
        {


            // ✅ ตรวจสอบช่องว่าง
            if (string.IsNullOrWhiteSpace(txtFbrand.Text) ||
                string.IsNullOrWhiteSpace(txtFmodel.Text) ||
                string.IsNullOrWhiteSpace(txtFPrice.Text) ||
                string.IsNullOrWhiteSpace(txtDes.Text) ||
                cboRoomid.SelectedValue == null ||
                cboTypeID.SelectedValue == null)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ ตรวจสอบราคา
            if (!decimal.TryParse(txtFPrice.Text, out decimal price))
            {
                MessageBox.Show("กรุณากรอกราคาเป็นตัวเลขเท่านั้น เช่น 2500 หรือ 2500.50", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ ตรวจสอบ Brand และ Model
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFbrand.Text, @"^[a-zA-Z0-9\s]+$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(txtFmodel.Text, @"^[a-zA-Z0-9\s]+$"))
            {
                MessageBox.Show("ชื่อแบรนด์และรุ่นต้องเป็นตัวอักษรหรือตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ ดึงค่า facility_id ถัดไป
            int nextId = GetNextFacilityId();

            using (SqlConnection conn = DB.apartment())
            {
                string sql = @"
            INSERT INTO Facility 
            (facility_id, brand, model, price, received_date, description, room_id, type_id)
            VALUES 
            (@id, @brand, @model, @price, @date, @desc, @room, @type)
        ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", nextId);
                    cmd.Parameters.AddWithValue("@brand", txtFbrand.Text.Trim());
                    cmd.Parameters.AddWithValue("@model", txtFmodel.Text.Trim());
                    cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = price;
                    cmd.Parameters.AddWithValue("@date", dtpReID.Value.Date); // จาก DateTimePicker
                    cmd.Parameters.AddWithValue("@desc", txtDes.Text.Trim());
                    cmd.Parameters.AddWithValue("@room", cboRoomid.SelectedValue);
                    cmd.Parameters.AddWithValue("@type", cboTypeID.SelectedValue);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }

            MessageBox.Show("เพิ่มข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowFacility();


        }




        private void btuFacilityDel_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DB.apartment();
            string sql = "DELETE FROM Facility WHERE facility_id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", txtFID.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            ShowFacility();
        }

        private void btuFacilityEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFID.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข");
                return;
            }

            SqlConnection conn = DB.apartment();
            string sql = "UPDATE Facility SET brand=@brand, model=@model, price=@price, description=@desc WHERE facility_id=@id";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", txtFID.Text);
            cmd.Parameters.AddWithValue("@brand", txtFbrand.Text);
            cmd.Parameters.AddWithValue("@model", txtFmodel.Text);
            cmd.Parameters.AddWithValue("@price", txtFPrice.Text);
            cmd.Parameters.AddWithValue("@desc", txtDes.Text);
            cmd.ExecuteNonQuery();

            conn.Close();
            ShowFacility();
        }

        private void btuFacilityClear_Click(object sender, EventArgs e)
        {
            txtFID.Clear();
            txtFbrand.Clear();
            txtFmodel.Clear();
            txtFPrice.Clear();
            txtDes.Clear();
            cboRoomid.SelectedIndex = -1;
            cboTypeID.SelectedIndex = -1;
            dtpReID.Value = DateTime.Now;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------

        private void LoadTenants()
        {
            using (SqlConnection conn = DB.apartment())
            {
                SqlCommand cmd = new SqlCommand("SELECT tenant_id, full_name FROM Tenant", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboRentaTanantID.DataSource = dt;
                cboRentaTanantID.DisplayMember = "full_name";
                cboRentaTanantID.ValueMember = "tenant_id";
            }
        }

        private void LoadRooms()
        {
            using (SqlConnection conn = DB.apartment())
            {
                SqlCommand cmd = new SqlCommand("SELECT room_id, floor FROM Room", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboRentaRoomID.DataSource = dt;
                cboRentaRoomID.DisplayMember = "floor";
                cboRentaRoomID.ValueMember = "room_id";
            }
        }

        private void LoadRentals()
        {
            using (SqlConnection conn = DB.apartment())
            {
                SqlCommand cmd = new SqlCommand("GetRentals", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRenta.DataSource = dt;
            }
        }

        private void btuRentaEdit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtRentaID.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการแก้ไข");
                return;
            }

            SqlConnection conn = DB.apartment();
            SqlCommand cmd = new SqlCommand("UpdateRental", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rental_id", Convert.ToInt32(txtRentaID.Text));
            cmd.Parameters.AddWithValue("@start_date", dtpStaet.Value);
            cmd.Parameters.AddWithValue("@end_date", dtpEnd.Value);
            cmd.Parameters.AddWithValue("@tenant_id", cboRentaTanantID.SelectedValue);
            cmd.Parameters.AddWithValue("@room_id", cboRentaRoomID.SelectedValue);
            cmd.ExecuteNonQuery();

            MessageBox.Show("อัปเดตข้อมูลสำเร็จ");
            conn.Close();
            LoadRentals();
            ClearFields();
        }

        private void btuRentaAdd_Click(object sender, EventArgs e)
        {
            // 1️⃣ ตรวจสอบ TextBox
            if (string.IsNullOrWhiteSpace(txtRentaID.Text))
            {
                MessageBox.Show("กรุณาใส่ Rental ID");
                txtRentaID.Focus();
                return;
            }

            // 2️⃣ แปลงค่า rental_id จาก TextBox
            if (!int.TryParse(txtRentaID.Text, out int newRentalId))
            {
                MessageBox.Show("Rental ID ต้องเป็นตัวเลขเท่านั้น");
                txtRentaID.Focus();
                return;
            }

            using (SqlConnection conn = DB.apartment())
            {

                // 3️⃣ ตรวจสอบ tenant_id และ room_id
                int tenantId = cboRentaTanantID.SelectedValue != null ? Convert.ToInt32(cboRentaTanantID.SelectedValue) : 1;
                int roomId = cboRentaRoomID.SelectedValue != null ? Convert.ToInt32(cboRentaRoomID.SelectedValue) : 1;

                // 4️⃣ ตรวจสอบ Default Tenant
                using (SqlCommand cmdCheckTenant = new SqlCommand(@"
            IF NOT EXISTS(SELECT 1 FROM Tenant WHERE tenant_id = @tid)
            BEGIN
                INSERT INTO Tenant(tenant_id, full_name, citizen_id, address, phone, birth_date, [description])
                VALUES (@tid, 'Default Tenant', '0000000000000', 'Default Address', '0000000000', GETDATE(), 'Default Tenant')
            END
        ", conn))
                {
                    cmdCheckTenant.Parameters.AddWithValue("@tid", tenantId);
                    cmdCheckTenant.ExecuteNonQuery();
                }

                // 5️⃣ ตรวจสอบ Default Room
                using (SqlCommand cmdCheckRoom = new SqlCommand(@"
            IF NOT EXISTS(SELECT 1 FROM Room WHERE room_id = @rid)
            BEGIN
                INSERT INTO Room(room_id, [floor], [status])
                VALUES (@rid, 1, 'มีผู็เช่า')
            END
        ", conn))
                {
                    cmdCheckRoom.Parameters.AddWithValue("@rid", roomId);
                    cmdCheckRoom.ExecuteNonQuery();
                }

                // 6️⃣ เพิ่ม Rental ผ่าน Stored Procedure
                using (SqlCommand cmd = new SqlCommand("AddRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rental_id", newRentalId);
                    cmd.Parameters.AddWithValue("@start_date", dtpStaet.Value.Date);
                    cmd.Parameters.AddWithValue("@end_date", dtpEnd.Value.Date);
                    cmd.Parameters.AddWithValue("@tenant_id", tenantId);
                    cmd.Parameters.AddWithValue("@room_id", roomId);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                LoadRentals(); // โหลดข้อมูลใหม่
            }

            MessageBox.Show("เพิ่มข้อมูลการเช่าเรียบร้อยแล้ว ✅", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void btuRentaDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentaID.Text))
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่จะลบ");
                return;
            }
            SqlConnection conn = DB.apartment();
            SqlCommand cmd = new SqlCommand("DeleteRental", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rental_id", Convert.ToInt32(txtRentaID.Text));
            cmd.ExecuteNonQuery();

            MessageBox.Show("ลบข้อมูลสำเร็จ");
            conn.Close();
            LoadRentals();
            ClearFields();
        }

        private void btuRentaClear_Click(object sender, EventArgs e)
        {
            txtRentaID.Clear();
            cboRentaTanantID.SelectedIndex = -1;
            cboRentaRoomID.SelectedIndex = -1;
            dtpStaet.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }

        // ------------------------------------------------------------------------------------------------------------------------------------------


        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoomfloor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoomStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearFields()
        {
            txtRentaID.Clear();
            cboRentaTanantID.SelectedIndex = -1;
            cboRentaRoomID.SelectedIndex = -1;
            dtpEnd.Value = DateTime.Now;
            dtpStaet.Value = DateTime.Now;
        }

        private void cboRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboRentaRoomID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
