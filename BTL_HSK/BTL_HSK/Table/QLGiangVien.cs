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
    public partial class QLGiangVien : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.GiangVienDAO giangVienDAO = new DAO.GiangVienDAO();
        DAO.TaiKhoanDAO taiKhoanDAO = new DAO.TaiKhoanDAO();
        public QLGiangVien()
        {
            InitializeComponent();
        }
        public void hienDSGiangVien()
        {
            DataTable t = giangVienDAO.layDSGiangVien(constr, "select * from GiangVien", "GiangVien");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbGiangVien.DataSource = t;
            tbGiangVien.Columns["STT"].DisplayIndex = 0;
        }
        
        private void loadDataGV(DataTable dsTimkiem)
        {
            tbGiangVien.DataSource = dsTimkiem;
        }
        private void ViewGiangVien()
        {
            tbGiangVien.ReadOnly = true;
            tbGiangVien.Columns[0].HeaderText = "Mã Giảng Viên";
            tbGiangVien.Columns[1].HeaderText = "Tên Giảng Viên";
            tbGiangVien.Columns[2].HeaderText = "Số Điện Thoại";
            tbGiangVien.Columns[3].HeaderText = "Email";
            tbGiangVien.Columns[4].HeaderText = "CCCD";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text != "" && txtTenGV.Text != "" && txtSDT.Text != "" && txtEmail.Text != "" && txtCCCD.Text != "")
            {
                if (giangVienDAO.Check_MGV(constr, txtMaGV.Text))
                {
                    if (txtCCCD.Text.Length == 12)
                    {
                        if (!giangVienDAO.IsValidVietNamPhoneNumber(txtSDT.Text))
                            MessageBox.Show("Không phải số điện thoại của Việt Nam", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            if (giangVienDAO.Check_CCCD(constr, txtCCCD.Text))
                            {
                                giangVienDAO.Them_GV(constr, txtMaGV.Text, txtTenGV.Text, txtSDT.Text, txtEmail.Text, txtCCCD.Text);
                                MessageBox.Show("Thêm Giảng Viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                taiKhoanDAO.Them_DangNhap(constr, txtMaGV.Text, txtMaGV.Text, "GiangVien", 1);
                                btnTaiLai_Click(sender, e);
                            }
                            else
                                MessageBox.Show("CCCD là duy nhất không được trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("CCCD phải có 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mã Giảng Viên không được trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaGV.Text != "" && txtTenGV.Text != "" && txtEmail.Text != "" && txtCCCD.Text != "" && txtSDT.Text != "")
            {
                if (giangVienDAO.Check_MGV(constr, txtMaGV.Text))
                    MessageBox.Show("Không thế sửa Mã Giảng Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (txtCCCD.Text.Length == 12)
                    {
                        if (!giangVienDAO.IsValidVietNamPhoneNumber(txtSDT.Text))
                            MessageBox.Show("Không phải số điện thoại của Việt Nam", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                            if (Regex.IsMatch(txtEmail.Text, pattern))
                            {
                                giangVienDAO.Sua_GiangVien(constr, txtMaGV.Text, txtTenGV.Text, txtSDT.Text, txtEmail.Text, txtCCCD.Text);
                                MessageBox.Show("Cập nhật Giảng Viên có mã: " + txtMaGV.Text + " thành công", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                btnTaiLai_Click(sender,e);
                            }
                            else
                                MessageBox.Show("Không phải Email", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                        MessageBox.Show("CCCD phải có 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (giangVienDAO.deleteGV(constr,txtMaGV.Text))
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
            string TenGV = txtTenGV.Text;
            string MaGV = txtMaGV.Text;
            string CCCD = txtCCCD.Text;
            string Email = txtEmail.Text;
            string SDT = txtSDT.Text;
            loadDataGV(giangVienDAO.Timkiem_GV(constr,TenGV, MaGV, CCCD, Email, SDT));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtMaGV.Text = "";
            txtTenGV.Text = "";
            txtSDT.Text = "";
            QLGiangVien_Load(sender, e);
            errorProvider1.Clear();
        }

        private void tbGiangVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGV.Text = tbGiangVien.CurrentRow.Cells[0].Value.ToString();
            txtTenGV.Text = tbGiangVien.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = tbGiangVien.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tbGiangVien.CurrentRow.Cells[3].Value.ToString();
            txtCCCD.Text = tbGiangVien.CurrentRow.Cells[4].Value.ToString();
            errorProvider1.Clear();
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaGV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                errorProvider1.SetError(txtMaGV, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtMaGV, "");
        }

        private void txtTenGV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenGV.Text == "")
            {
                errorProvider1.SetError(txtTenGV, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtTenGV, "");
        }

        private void txtSDT_Validating(object sender, CancelEventArgs e)
        {
            if (txtSDT.Text == "")
            {
                errorProvider1.SetError(txtSDT, "Không được để trống !");
            }
            else if (txtSDT.Text.Length != 10)
                errorProvider1.SetError(txtSDT, "Số Điện Thoại chỉ có 10 số");
            else if (!giangVienDAO.IsValidVietNamPhoneNumber(txtSDT.Text))
                errorProvider1.SetError(txtSDT, "Không phải số điện thoại Việt Nam");
            else
                errorProvider1.SetError(txtSDT, "");
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCCCD_Validating(object sender, CancelEventArgs e)
        {
            if (txtCCCD.Text == "")
            {
                errorProvider1.SetError(txtCCCD, "Không được để trống !");
            }
            else if (txtCCCD.Text.Length != 12)
                errorProvider1.SetError(txtCCCD, "CCCD phải có 12 số");
            else
                errorProvider1.SetError(txtCCCD, "");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            if (txtEmail.Text == "")
            {
                errorProvider1.SetError(txtEmail, "Không được để trống !");
            }
            else
            {
                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    errorProvider1.SetError(txtEmail, "");
                }
                else
                    errorProvider1.SetError(txtEmail, "Không phải Email");
            }
        }

        private void QLGiangVien_Load(object sender, EventArgs e)
        {
            hienDSGiangVien();
            ViewGiangVien();
        }
    }
}
