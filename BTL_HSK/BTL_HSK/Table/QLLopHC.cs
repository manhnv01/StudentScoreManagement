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
    public partial class QLLopHC : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.LopHanhChinhDAO lopHCDAO = new DAO.LopHanhChinhDAO();
        public QLLopHC()
        {
            InitializeComponent();
        }
        public void hienDSLopHC()
        {
            DataTable t = lopHCDAO.layDSLopHC(constr, "select * from LopHanhChinh", "LopHanhChinh");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbLopHC.DataSource = t;
            tbLopHC.Columns["STT"].DisplayIndex = 0;

        }
        
        private void ViewLopHC()
        {
            tbLopHC.ReadOnly = true;
            tbLopHC.Columns[0].HeaderText = "Mã Lớp Hành Chính";
            tbLopHC.Columns[1].HeaderText = "Tên Lớp Hành Chính";
        }
        private void QLLopHC_Load(object sender, EventArgs e)
        {
            hienDSLopHC();
            ViewLopHC();
        }
        
        private void loadDataLopHC(DataTable dsTimkiem)
        {
            tbLopHC.DataSource = dsTimkiem;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text != "" && txtTenLop.Text != "")
            {
                if (lopHCDAO.Check_MaLopHC(constr, txtMaLop.Text))
                {
                    if (lopHCDAO.Check_TenLopHC(constr, txtTenLop.Text))
                    {
                        MessageBox.Show("Thêm Lớp Hành Chính thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lopHCDAO.Them_LopHC(constr, txtMaLop.Text, txtTenLop.Text);
                        btnTaiLai_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Tên Lớp Hành Chính này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mã Lớp Hành Chính không được trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text != "" && txtTenLop.Text != "")
            {
                if (lopHCDAO.Check_MaLopHC(constr, txtMaLop.Text))
                    MessageBox.Show("Không thế sửa Mã Lớp Hành Chính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if(lopHCDAO.Check_TenLopHC(constr, txtTenLop.Text))
                    {
                        lopHCDAO.Sua_LopHC(constr, txtMaLop.Text, txtTenLop.Text);
                        MessageBox.Show("Cập nhật Lớp Hành Chính có mã: " + txtMaLop.Text + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnTaiLai_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Tên Lớp Hành Chính này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string MaLop = txtMaLop.Text;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lopHCDAO.deleteLopHC(constr, MaLop))
                    btnTaiLai_Click(sender, e);
                else
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string TenLop = txtTenLop.Text;
            string MaLop = txtMaLop.Text;
                loadDataLopHC(lopHCDAO.Timkiem_LopHC(constr,MaLop, TenLop));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            QLLopHC_Load(sender, e);
            errorProvider1.Clear();
        }

        private void tbLopHC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLop.Text = tbLopHC.CurrentRow.Cells[0].Value.ToString();
            txtTenLop.Text = tbLopHC.CurrentRow.Cells[1].Value.ToString();
            errorProvider1.Clear();
        }

        private void txtMaLop_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaLop.Text == "")
            {
                errorProvider1.SetError(txtMaLop, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtMaLop, "");
        }

        private void txtTenLop_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenLop.Text == "")
            {
                errorProvider1.SetError(txtTenLop, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtTenLop, "");
        }
    }
}
