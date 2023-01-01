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
    public partial class QLLopHocPhan : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.LopHocPhanDAO lopHPDAO = new DAO.LopHocPhanDAO();
        DAO.GiangVienDAO giangVienDAO = new DAO.GiangVienDAO();
        public QLLopHocPhan()
        {
            InitializeComponent();
        }
        public void hienTenGV()
        {
            txtTenGV.Text = lopHPDAO.layTenGV(constr,txtMaGV.Text);
        }
        public void hienDSLopHocPhan()
        {
            DataTable t = lopHPDAO.layDS(constr, "select * from showViewAllLopHocPhan", "showViewAllLopHocPhan");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbLopHocPhan.DataSource = t;
            tbLopHocPhan.Columns["STT"].DisplayIndex = 0;

        }
        public void hienTenMon()
        {
            DataTable t = lopHPDAO.layDS(constr, "select * from MonHoc", "MonHoc");
            DataView view = new DataView(t);
            view.Sort = "TenMon";
            txtMaMon.DataSource = view;
            txtMaMon.DisplayMember = "TenMon";
            txtMaMon.ValueMember = "MaMon";

        }
        public void hienMaGiangVien()
        {
            DataTable t = lopHPDAO.layDS(constr, "select * from GiangVien", "GiangVien");
            DataView view = new DataView(t);
            view.Sort = "MaGV";
            txtMaGV.DataSource = view;
            txtMaGV.DisplayMember = "MaGV";
            txtMaGV.ValueMember = "MaGV";

        }

        private void loadDataLopHocPhan(DataTable dsTimkiem)
        {
            tbLopHocPhan.DataSource = dsTimkiem;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLHP.Text != "" && txtMaMon.Text != "" && txtMaGV.Text != "")
            {
                if (lopHPDAO.Check_MaLopHocPhan(constr, txtMaLHP.Text))
                {
                    if (!giangVienDAO.Check_MGV(constr, txtMaGV.Text))
                    {
                        int result = DateTime.Compare(txtThoiGianBatDau.Value, txtThoiGianKetThuc.Value);
                        if (result <= 0)
                        {
                            lopHPDAO.Them_LopHocPhan(constr, txtMaLHP.Text, txtMaMon.SelectedValue.ToString(), txtMaGV.Text, txtThoiGianBatDau.Value, txtThoiGianKetThuc.Value);
                            MessageBox.Show("Thêm Lớp Học Phần thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnTaiLai_Click(sender, e);
                        }
                        else
                            MessageBox.Show("Ngày Kết Thúc Phải lớn hơn hoặc cùng Ngày Bắt Đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                        MessageBox.Show("Không tìm thấy Mã Giảng Viên này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mã Lớp Học Phần không được trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    if (txtMaGV.Text != "" && txtMaLHP.Text != "" && txtMaMon.Text != "")
                    {
                        if (!lopHPDAO.Check_MaLopHocPhan(constr, txtMaLHP.Text))
                        {
                            if (!giangVienDAO.Check_MGV(constr, txtMaGV.Text))
                            {
                                int result = DateTime.Compare(txtThoiGianBatDau.Value, txtThoiGianKetThuc.Value);
                                if (result <= 0)
                                {
                                    lopHPDAO.Sua_LopHP(constr, txtMaLHP.Text, txtMaMon.SelectedValue.ToString(), txtMaGV.Text, txtThoiGianBatDau.Text, txtThoiGianKetThuc.Text);
                                    MessageBox.Show("Cập nhật Lớp Học Phần thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnTaiLai_Click(sender, e);
                                }
                                else
                                    MessageBox.Show("Ngày Kết Thúc Phải lớn hơn hoặc cùng Ngày Bắt Đầu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("Không tìm thấy Mã Giảng Viên này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Không được sửa Mã Lớp Học Phần", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //if (Check_Xoa_MaLopHocPhan(constr, txtMaLHP.Text))
            //{
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lopHPDAO.deleteLopHocPhan(constr,txtMaLHP.Text))
                    {
                        btnTaiLai_Click(sender, e);
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            //else
            //    MessageBox.Show("Không thể xóa Lớp này do đã tồn tại trong bảng Điểm ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
                loadDataLopHocPhan(lopHPDAO.Timkiem_LopHocPhan(constr,txtMaLHP.Text,txtMaMon.Text,txtMaGV.Text));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaLHP.Text = "";
            txtMaMon.Text = "";
            txtMaGV.Text = "";
            QLLopHocPhan_Load(sender, e);
            errorProvider1.Clear();
        }

        private void tbLopHocPhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLHP.Text = tbLopHocPhan.CurrentRow.Cells[0].Value.ToString();
            txtMaMon.Text = tbLopHocPhan.CurrentRow.Cells[1].Value.ToString();
            txtMaGV.Text = tbLopHocPhan.CurrentRow.Cells[2].Value.ToString();
            txtThoiGianBatDau.Text = tbLopHocPhan.CurrentRow.Cells[3].Value.ToString();
            txtThoiGianKetThuc.Text = tbLopHocPhan.CurrentRow.Cells[4].Value.ToString();
        }

        private void txtMaLHP_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaLHP.Text == "")
            {
                errorProvider1.SetError(txtMaLHP, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMaLHP, "");
        }

        private void txtMaMon_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaMon.Text == "")
            {
                errorProvider1.SetError(txtMaMon, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMaMon, "");
        }

        private void txtMaGV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaGV.Text == "")
            {
                errorProvider1.SetError(txtMaGV, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMaGV, "");
        }

        private void QLLopHocPhan_Load(object sender, EventArgs e)
        {
            hienTenMon();
            hienMaGiangVien();
            hienDSLopHocPhan();
            txtMaGV.Text = "";
            txtMaMon.Text = "";
            txtTenGV.Text = "Tên Giảng Viên";
        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {
            hienTenGV();
        }
    }
}
//int result = DateTime.Compare(DateTime.Parse(DateTime.Now.ToString("MM/dd/yyyy")), dttra.Value);
//if (result <= 0)
//DateTime a = DateTime.Now;
//DateTime date = a.AddDays(3);//3 ngày sau
//MessageBox.Show(date.ToString(), "thông báo");
