using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;

namespace apartment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ShowAllTenants();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dgvTenant
        }

        private void cboTenant_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cboTenant
        }

        private void cboNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cboNum
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cboStatus
        }

        // โหลดค่า ComboBox อัตโนมัติ
        private void LoadComboBoxes()
        {
            using (SqlConnection conn = DB.apartment())
            {
                // ชื่อผู้เช่า
                DataTable dtTenant = new DataTable();
                new SqlDataAdapter("SELECT DISTINCT full_name FROM Tenant", conn).Fill(dtTenant);
                cboTenant.DataSource = dtTenant;
                cboTenant.DisplayMember = "full_name";
                cboTenant.ValueMember = "full_name";
                cboTenant.SelectedIndex = -1;

                dgvTenant.Columns[0].Visible = false;

                // ห้อง
                DataTable dtRoom = new DataTable();
                new SqlDataAdapter("SELECT DISTINCT room_id FROM Room", conn).Fill(dtRoom);
                cboNum.DataSource = dtRoom;
                cboNum.DisplayMember = "room_id";
                cboNum.ValueMember = "room_id";
                cboNum.SelectedIndex = -1;

                // สถานะ
                DataTable dtStatus = new DataTable();
                new SqlDataAdapter("SELECT DISTINCT [status] FROM Room", conn).Fill(dtStatus);
                cboStatus.DataSource = dtStatus;
                cboStatus.DisplayMember = "status";
                cboStatus.ValueMember = "status";
                cboStatus.SelectedIndex = -1;
                conn.Close();
            }
        }
        // แสดงข้อมูลผู้เช่าทั้งหมด
        private void ShowAllTenants()
        {
            using (SqlConnection conn = DB.apartment())
            {
                string sql = @"
            SELECT t.tenant_id, t.full_name, r.room_id, r.[status], r.floor
            FROM Tenant t
            INNER JOIN Rental rn ON t.tenant_id = rn.tenant_id
            INNER JOIN Room r ON rn.room_id = r.room_id";
                DataTable dt = new DataTable();
                new SqlDataAdapter(sql, conn).Fill(dt);
                dgvTenant.DataSource = dt;
                conn.Close();
            }

            using (SqlConnection conn = DB.apartment())
            {
                string sql2 = "SELECT payment_id, amount, payment_date, installment, [month], [year], rental_id  FROM Payment";
                DataTable ds = new DataTable();
                new SqlDataAdapter(sql2, conn).Fill(ds);
                dgvPament.DataSource = ds;
                conn.Close();

                dgvPament.Columns[0].Visible = false;

            }




        }
        private void btuSearch_Click(object sender, EventArgs e)
        {
            // btuSearch
            try
            {
                using (SqlConnection conn = DB.apartment())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_SearchTenantRoomStatus", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // ส่งค่าพารามิเตอร์ (ถ้าไม่เลือก ให้เป็น DBNull)
                        cmd.Parameters.AddWithValue("@FullName", string.IsNullOrEmpty(cboTenant.Text) ? (object)DBNull.Value : cboTenant.Text);
                        cmd.Parameters.AddWithValue("@RoomId", string.IsNullOrEmpty(cboNum.Text) ? (object)DBNull.Value : int.Parse(cboNum.Text));
                        cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(cboStatus.Text) ? (object)DBNull.Value : cboStatus.Text);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvTenant.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching tenant: " + ex.Message);
            }
        }

        private void dgvTenant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dgvTenant
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Form2
            LoadComboBoxes();
        }

        private void btuDef_Click(object sender, EventArgs e)
        {

            LoadComboBoxes();
            ShowAllTenants();
        }

        private void dgvTenant_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (!dgvTenant.Columns.Contains("tenant_id"))
            {
                MessageBox.Show("ไม่พบคอลัมน์ 'tenant_id' ใน dgvTenant — โปรดตรวจสอบชื่อคอลัมน์ใน SQL หรือ DataSource");
                return;
            }

            int tenantId = Convert.ToInt32(dgvTenant.Rows[e.RowIndex].Cells["tenant_id"].Value);

            using (SqlConnection conn = DB.apartment())
            {
                string sql = @"
            SELECT 
                p.payment_id,
                p.amount,
                p.payment_date,
                p.installment,
                p.[month],
                p.[year],
                p.rental_id
            FROM Payment p
            INNER JOIN Rental r ON p.rental_id = r.rental_id
            WHERE r.tenant_id = @tenant_id
            ORDER BY p.payment_date DESC;
        ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenant_id", tenantId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPament.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("ยังไม่มีข้อมูลการชำระเงินสำหรับผู้เช่าคนนี้", "ข้อมูลว่าง", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }





    }
}
