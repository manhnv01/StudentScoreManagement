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
    public partial class QLTaiKhoan : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.TaiKhoanDAO taiKhoanDAO = new DAO.TaiKhoanDAO();
        public QLTaiKhoan()
        {
            InitializeComponent();
        }
        public void hienDSTaiKhoan()
        {
            DataTable t = taiKhoanDAO.layDSTaiKhoan(constr, "select * from DangNhap", "DangNhap");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbTaiKhoan.DataSource = t;
            tbTaiKhoan.Columns["STT"].DisplayIndex = 0;

        }
        
        private void loadDataTaiKhoan(DataTable dsTimkiem)
        {
            tbTaiKhoan.DataSource = dsTimkiem;
        }
        private void ViewTaiKhoan()
        {
            tbTaiKhoan.ReadOnly = true;
            tbTaiKhoan.Columns[0].HeaderText = "Tài Khoản";
            tbTaiKhoan.Columns[1].HeaderText = "Mật Khẩu";
            tbTaiKhoan.Columns[2].HeaderText = "Quyền";
            tbTaiKhoan.Columns[3].HeaderText = "Trạng Thái";
            tbTaiKhoan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            rbMo.Checked = true;
            hienDSTaiKhoan();
            ViewTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtQuyen.Text!="")
            {
                if (taiKhoanDAO.Check_TaiKhoan(constr, txtTaiKhoan.Text))
                {
                    if (rbMo.Checked == true)
                        taiKhoanDAO.Them_DangNhap(constr, txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text, 1);
                    else if (rbDong.Checked == true)
                        taiKhoanDAO.Them_DangNhap(constr, txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text, 0);
                    MessageBox.Show("Thêm tài khoản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QLTaiKhoan_Load(sender, e);
                }
                else
                    MessageBox.Show("Tài Khoản này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "" && txtQuyen.Text != "")
            {
                if (taiKhoanDAO.Check_TaiKhoan(constr, txtTaiKhoan.Text))
                    MessageBox.Show("Không thế sửa Tài Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (rbMo.Checked == true)
                        taiKhoanDAO.Sua_TaiKhoan(constr, txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text, 1);
                    else
                        taiKhoanDAO.Sua_TaiKhoan(constr, txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text, 0);
                    MessageBox.Show("Cập nhật Tài Khoản: " + txtTaiKhoan.Text + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienDSTaiKhoan();
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static string TaiKhoan;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!TaiKhoan.Equals(txtTaiKhoan.Text))
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (taiKhoanDAO.deleteTaiKhoan(constr,txtTaiKhoan.Text))
                    {
                        btnTaiLai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if(MessageBox.Show("Tài khoản này bạn đang đăng nhập nếu xóa sẽ thoát ứng dụng, Bạn có chắc muốn xóa ?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (taiKhoanDAO.deleteTaiKhoan(constr,txtTaiKhoan.Text))
                    {
                        btnTaiLai_Click(sender, e);
                        Application.Restart();
                        Environment.Exit(0);
                        //Application.Exit();
                        //System.Diagnostics.Process.Start(Application.ExecutablePath);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rbMo.Checked == true)
                loadDataTaiKhoan(taiKhoanDAO.Timkiem_TaiKhoan(constr,txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text,"1"));
            else if (rbDong.Checked == true)
                loadDataTaiKhoan(taiKhoanDAO.Timkiem_TaiKhoan(constr,txtTaiKhoan.Text, txtMatKhau.Text, txtQuyen.Text,"0"));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            QLTaiKhoan_Load(sender, e);
        }

        private void tbTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbTaiKhoan.CurrentRow.Cells[3].Value.ToString() == "1")
                rbMo.Checked = true;
            else if (tbTaiKhoan.CurrentRow.Cells[3].Value.ToString() == "0")
                rbDong.Checked = true;
            txtTaiKhoan.Text = tbTaiKhoan.CurrentRow.Cells[0].Value.ToString();
            txtMatKhau.Text = tbTaiKhoan.CurrentRow.Cells[1].Value.ToString();
            txtQuyen.Text = tbTaiKhoan.CurrentRow.Cells[2].Value.ToString();
        }

        private void txtTaiKhoan_Validating(object sender, CancelEventArgs e)
        {

            if (txtTaiKhoan.Text == "")
            {
                errorProvider1.SetError(txtTaiKhoan, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtTaiKhoan, "");
        }

        private void txtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                errorProvider1.SetError(txtMatKhau, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtMatKhau, "");
        }

        private void txtQuyen_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuyen.Text == "")
            {
                errorProvider1.SetError(txtQuyen, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtQuyen, "");
        }
    }
}
