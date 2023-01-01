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
    public partial class QLDiem : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.DiemDAO diemDAO = new DAO.DiemDAO();
        DAO.SinhVienDAO sinhVienDAO = new DAO.SinhVienDAO();
        DAO.LopHocPhanDAO lopHPDAO = new DAO.LopHocPhanDAO();

        public static string TaiKhoan;
        public static string Quyen;
        public QLDiem()
        {
            InitializeComponent();
        }
        public void hienDSDiem()
        {
            DataTable t = diemDAO.layDS(constr,"select * from Diem", "Diem");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbDiem.DataSource = t;
            tbDiem.Columns["STT"].DisplayIndex = 0;
        }
        public void hienMaSV()
        {
            DataTable t = diemDAO.layDS(constr, "select * from SinhVien", "SinhVien");
            DataView view = new DataView(t);
            view.Sort = "MaSV";
            txtMaSV.DataSource = view;
            txtMaSV.DisplayMember = "MaSV";
            txtMaSV.ValueMember = "MaSV";
        }
        public void hienMaLHP()
        {
            DataTable t = diemDAO.layDS(constr, "select * from LopHocPhan", "LopHocPhan");
            DataView view = new DataView(t);
            view.Sort = "MaLHP";
            txtMaLHP.DataSource = view;
            txtMaLHP.DisplayMember = "MaLHP";
            txtMaLHP.ValueMember = "MaLHP";

        }
        public void hienMaLHPtheoGiangVien()
        {
            DataTable t = diemDAO.layDS(constr, "select * from LopHocPhan where MaGV='"+TaiKhoan+"'", "LopHocPhan");
            DataView view = new DataView(t);
            view.Sort = "MaLHP";
            txtMaLHP.DataSource = view;
            txtMaLHP.DisplayMember = "MaLHP";
            txtMaLHP.ValueMember = "MaLHP";

        }
        public void hienTenSV()
        {
            txtTenSV.Text = diemDAO.layTenSV(constr,txtMaSV.Text);
        }
        public void hienTenMon()
        {
            txtTenMon.Text = diemDAO.layTenMon(constr,txtMaLHP.Text);
        }
        
        private void ViewDiem()
        {
            tbDiem.ReadOnly = true;
            tbDiem.Columns[0].HeaderText = "Mã Sinh Viên";
            tbDiem.Columns[1].HeaderText = "Mã Lớp Học Phần";
            tbDiem.Columns[2].HeaderText = "Điểm Chuyên Cần";
            tbDiem.Columns[3].HeaderText = "Điểm Giữa Kỳ";
            tbDiem.Columns[4].HeaderText = "Điểm Thi";
        }
        private void loadDataDiem(DataTable dsTimkiem)
        {
            tbDiem.DataSource = dsTimkiem;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double DiemCC = 0;
            double DiemGK = 0;
            double DiemThi = 0;
            bool checkDiemCC = double.TryParse(txtDiemChuyenCan.Text, out DiemCC);
            bool checkDiemGK = double.TryParse(txtDiemGiuaKy.Text, out DiemGK);
            bool checkDiemThi = double.TryParse(txtDiemThi.Text, out DiemThi);
            

                if (txtMaSV.Text != "" && txtMaLHP.Text != "" && txtDiemChuyenCan.Text != "" && txtDiemGiuaKy.Text != "" && txtDiemThi.Text != "")
                {

                    if (!lopHPDAO.Check_MaLopHocPhan(constr, txtMaLHP.Text) && !sinhVienDAO.Check_MSV(constr, txtMaSV.Text))
                    {
                        if (diemDAO.Check_Ma_ThemDiem(constr, txtMaSV.Text, txtMaLHP.Text))
                        {
                            
                                if (checkDiemCC && checkDiemGK && checkDiemThi)
                                {
                                    if (DiemCC >= 0 && DiemCC <= 10 && DiemGK >= 0 && DiemGK <= 10 && DiemThi >= 0 && DiemThi <= 10)
                                    {
                                        if (diemDAO.Check_Solanhoc(constr,txtMaSV.Text,txtTenMon.Text))
                                        {
                                            diemDAO.Them_Diem(constr, txtMaSV.Text, txtMaLHP.Text, DiemCC, DiemGK, DiemThi);
                                            MessageBox.Show("Thêm Điểm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            btnTaiLai_Click(sender, e);
                                        }
                                        else
                                            MessageBox.Show("Sinh viên này học đã học môn này 3 lần", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                        MessageBox.Show("Vui lòng nhập Điểm trong khoảng từ 0-10", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                    MessageBox.Show("Sai Định dạng Điểm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                            MessageBox.Show("Trùng Dữ liệu, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Không tìm thấy Sinh Viên hoặc Lớp Học Phần có mã này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text != "" && txtMaLHP.Text != "" && txtDiemChuyenCan.Text != "" && txtDiemGiuaKy.Text != "" && txtDiemThi.Text != "")
            {
                if (!lopHPDAO.Check_MaLopHocPhan(constr, txtMaLHP.Text) && !sinhVienDAO.Check_MSV(constr, txtMaSV.Text))
                {
                    if (diemDAO.Check_Ma_ThemDiem(constr, txtMaSV.Text, txtMaLHP.Text))
                        MessageBox.Show("Chỉ được sửa Điểm, Không được sửa mã", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        double DiemCC = 0;
                        double DiemGK = 0;
                        double DiemThi = 0;
                        bool checkDiemCC = double.TryParse(txtDiemChuyenCan.Text, out DiemCC);
                        bool checkDiemGK = double.TryParse(txtDiemGiuaKy.Text, out DiemGK);
                        bool checkDiemThi = double.TryParse(txtDiemThi.Text, out DiemThi);
                        if (checkDiemCC && checkDiemGK && checkDiemThi)
                        {
                            if (DiemCC >= 0 && DiemCC <= 10 && DiemGK >= 0 && DiemGK <= 10 && DiemThi >= 0 && DiemThi <= 10)
                            {
                                diemDAO.Sua_Diem(constr, txtMaSV.Text, txtMaLHP.Text, DiemCC, DiemGK, DiemThi);
                                MessageBox.Show("Cập nhật Điêm Sinh Viên có mã: " + txtMaSV.Text + " thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnTaiLai_Click(sender, e);
                            }
                            else
                                MessageBox.Show("Vui lòng nhập Điểm trong khoảng từ 0-10", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Sai Định dạng Điểm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Không tìm thấy Sinh Viên hoặc Lớp Học Phần có mã này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (diemDAO.deleteDiem(constr,txtMaSV.Text, txtMaLHP.Text))
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
            loadDataDiem(diemDAO.Timkiem_Diem(constr,txtMaSV.Text, txtMaLHP.Text, txtDiemChuyenCan.Text, txtDiemGiuaKy.Text, txtDiemThi.Text));
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtMaLHP.Text = "";
            txtDiemChuyenCan.Text = "";
            txtDiemGiuaKy.Text = "";
            txtDiemThi.Text = "";
            QLDiem_Load(sender, e);
            errorProvider1.Clear();
        }

        private void tbDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = tbDiem.CurrentRow.Cells[0].Value.ToString();
            txtMaLHP.Text = tbDiem.CurrentRow.Cells[1].Value.ToString();
            txtDiemChuyenCan.Text = tbDiem.CurrentRow.Cells[2].Value.ToString();
            txtDiemGiuaKy.Text = tbDiem.CurrentRow.Cells[3].Value.ToString();
            txtDiemThi.Text = tbDiem.CurrentRow.Cells[4].Value.ToString();
            errorProvider1.Clear();
        }

        private void txtMaSV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtMaSV, "");
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

        private void txtDiemChuyenCan_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiemChuyenCan.Text == "")
            {
                errorProvider1.SetError(txtDiemChuyenCan, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtDiemChuyenCan, "");
        }

        private void txtDiemGiuaKy_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiemGiuaKy.Text == "")
            {
                errorProvider1.SetError(txtDiemGiuaKy, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtDiemGiuaKy, "");
        }

        private void txtDiemThi_Validating(object sender, CancelEventArgs e)
        {
            if (txtDiemThi.Text == "")
            {
                errorProvider1.SetError(txtDiemThi, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtDiemThi, "");
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            hienTenSV();
        }

        private void txtMaLHP_TextChanged(object sender, EventArgs e)
        {
            hienTenMon();
            if (Quyen == "GiangVien")
            {
                if (!diemDAO.Check_QuyenGiangVien(constr, txtMaLHP.Text, TaiKhoan))
                {
                    btnSua.Enabled = false;
                    btnThem.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                {
                    btnSua.Enabled = true;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void QLDiem_Load(object sender, EventArgs e)
        {
            if (Quyen == "GiangVien")
                hienMaLHPtheoGiangVien();
            else
                hienMaLHP();
            hienDSDiem();
            hienMaSV();
            ViewDiem();
            txtMaSV.Text = "";
            txtMaLHP.Text = "";
            txtTenMon.Text = "Tên Môn Học";
            txtTenSV.Text = "Tên Sinh Viên";
            
        }

        private void txtDiemChuyenCan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtDiemChuyenCan.Text.Length == 0 || txtDiemChuyenCan.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtDiemGiuaKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtDiemGiuaKy.Text.Length == 0 || txtDiemGiuaKy.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtDiemThi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (txtDiemThi.Text.Length == 0 || txtDiemThi.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
    }
}
