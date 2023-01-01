using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BTL_HSK
{
    public partial class QLMonHoc : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.MonHocDAO monHocDAO = new DAO.MonHocDAO();
        public QLMonHoc()
        {
            InitializeComponent();
        }
        public void hienDSMonHoc()
        {
            DataTable t = monHocDAO.layDSMonHoc(constr, "select * from MonHoc", "MonHoc");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbMonHoc.DataSource = t;
            tbMonHoc.Columns["STT"].DisplayIndex = 0;

        }
        
        private void ViewMonHoc()
        {
            tbMonHoc.ReadOnly = true;
            tbMonHoc.Columns[0].HeaderText = "Mã Môn Học";
            tbMonHoc.Columns[1].HeaderText = "Tên Môn Học";
            tbMonHoc.Columns[2].HeaderText = "Số Tín Chỉ";
        }
       
        private void loadDataMonHoc(DataTable dsTimkiem)
        {
            tbMonHoc.DataSource = dsTimkiem;
        }

        private void QLMonHoc_Load(object sender, EventArgs e)
        {
            hienDSMonHoc();
            ViewMonHoc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text != "" && txtTenMon.Text != "" && txtSoTinChi.Text != "")
            {
                if (monHocDAO.Check_MaMonHoc(constr, txtMaMon.Text))
                {
                    if (monHocDAO.Check_TenMonHoc(constr, txtTenMon.Text))
                    {
                        MessageBox.Show("Thêm Môn Học thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        monHocDAO.Them_MonHoc(constr, txtMaMon.Text, txtTenMon.Text,int.Parse(txtSoTinChi.Text));
                        btnTaiLai_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Tên Môn Học này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mã Môn Học không được trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text != "" && txtTenMon.Text != "" && txtSoTinChi.Text != "")
            {
                if (!monHocDAO.Check_MaMonHoc(constr, txtMaMon.Text))
                {
                    monHocDAO.Sua_MonHoc(constr, txtMaMon.Text, txtTenMon.Text, int.Parse(txtSoTinChi.Text));
                    MessageBox.Show("Cập nhật Môn Học có mã: " + txtMaMon.Text + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnTaiLai_Click(sender, e);
                }
                else
                    MessageBox.Show("Không được Sửa Mã Môn Học", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaMon = txtMaMon.Text;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (monHocDAO.deleteMonHoc(constr,MaMon))
                {
                    btnTaiLai_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenMon = txtTenMon.Text;
            string MaMon = txtMaMon.Text;
            string SoTinChi = txtSoTinChi.Text;
                loadDataMonHoc(monHocDAO.Timkiem_MonHoc(constr,MaMon, TenMon, SoTinChi));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtSoTinChi.Text = "";
            QLMonHoc_Load(sender, e);
            errorProvider1.Clear();
        }

        private void txtMaMon_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaMon.Text == "")
            {
                errorProvider1.SetError(txtMaMon, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtMaMon, "");
        }

        private void txtTenMon_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenMon.Text == "")
            {
                errorProvider1.SetError(txtTenMon, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtTenMon, "");
        }

        private void txtSoTinChi_Validating(object sender, CancelEventArgs e)
        {
            if (txtSoTinChi.Text == "")
            {
                errorProvider1.SetError(txtSoTinChi, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtSoTinChi, "");
        }

        private void txtSoTinChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Text = tbMonHoc.CurrentRow.Cells[0].Value.ToString();
            txtTenMon.Text = tbMonHoc.CurrentRow.Cells[1].Value.ToString();
            txtSoTinChi.Text = tbMonHoc.CurrentRow.Cells[2].Value.ToString();
            errorProvider1.Clear();
        }
    }
}
