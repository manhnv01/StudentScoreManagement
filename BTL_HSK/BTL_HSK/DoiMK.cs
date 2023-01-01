using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK
{
    public partial class DoiMK : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.TaiKhoanDAO taiKhoanDAO = new DAO.TaiKhoanDAO();
        public DoiMK()
        {
            InitializeComponent();
        }
        public static string TaiKhoan;
        public static string MatKhauOld;

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            if (txtMatKhauOld.Text != "" && txtMatKhauNew.Text != "" && txtNhapLaiMatKhauNew.Text != "")
            {
                if (txtMatKhauOld.Text == MatKhauOld)
                {
                    if (txtMatKhauNew.Text == txtNhapLaiMatKhauNew.Text)
                    {
                        if (taiKhoanDAO.IsValidPass(txtMatKhauNew.Text))
                        {
                            taiKhoanDAO.DoiMK(constr, TaiKhoan, txtMatKhauNew.Text);
                            MessageBox.Show("Đổi Mật Khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MatKhauOld = txtMatKhauNew.Text;
                            btnLamTrong_Click(sender, e);
                        }
                        else
                            MessageBox.Show("Mật Khẩu phải có độ dài tối thiểu 8 và có ít nhất 1 chữ hoa, 1 chữ thường, 1 số, 1 ký tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Nhập lại mật khẩu mới không đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mật Khẩu hiện tại không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtMatKhauOld_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhauOld.Text == "")
            {
                errorProvider1.SetError(txtMatKhauOld, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMatKhauOld, "");
        }

        private void txtMatKhauNew_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhauNew.Text == "")
            {
                errorProvider1.SetError(txtMatKhauNew, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMatKhauNew, "");
        }

        private void txtNhapLaiMatKhauNew_Validating(object sender, CancelEventArgs e)
        {
            if (txtNhapLaiMatKhauNew.Text == "")
            {
                errorProvider1.SetError(txtNhapLaiMatKhauNew, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtNhapLaiMatKhauNew, "");
        }


        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtMatKhauNew.Text = "";
            txtMatKhauOld.Text = "";
            txtNhapLaiMatKhauNew.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhienmk.Checked == true)
            {
                txtMatKhauOld.UseSystemPasswordChar = false;
                txtMatKhauNew.UseSystemPasswordChar = false;
                txtNhapLaiMatKhauNew.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauOld.UseSystemPasswordChar = true;
                txtMatKhauNew.UseSystemPasswordChar = true;
                txtNhapLaiMatKhauNew.UseSystemPasswordChar = true;
            }  
        }
    }
}
