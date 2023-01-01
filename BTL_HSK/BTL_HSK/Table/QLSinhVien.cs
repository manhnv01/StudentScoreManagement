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
    public partial class QLSinhVien : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.SinhVienDAO sinhVienDAO = new DAO.SinhVienDAO();
        DAO.LopHanhChinhDAO lopHCDAO = new DAO.LopHanhChinhDAO();
        DAO.TaiKhoanDAO taiKhoanDAO = new DAO.TaiKhoanDAO();
        public QLSinhVien()
        {
            InitializeComponent();
        }

        public void hienTenLop()
        {
            DataTable t = lopHCDAO.layDSLopHC(constr, "select * from LopHanhChinh", "LopHanhChinh");
            DataView view = new DataView(t);
            view.Sort = "MaLop";
            txtLopHC.DataSource = view;
            txtLopHC.DisplayMember = "TenLop";
            txtLopHC.ValueMember = "MaLop";

        }
        public void hienDSSinhVien()
        {
            DataTable t = sinhVienDAO.layDSSinhVien(constr, "select * from showViewAllSV", "showViewAllSV");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbSinhVien.DataSource = t;
            tbSinhVien.Columns["STT"].DisplayIndex = 0;

        }
        
        private void loadDataSV(DataTable dsTimkiem)
        {
            tbSinhVien.DataSource = dsTimkiem;
        }
        private void ViewHocSinh()
        {
            tbSinhVien.ReadOnly = true;
            tbSinhVien.Columns[0].HeaderText = "Mã Sinh Viên";
            tbSinhVien.Columns[1].HeaderText = "Tên Sinh Viên";
            tbSinhVien.Columns[2].HeaderText = "Giới Tính";
            tbSinhVien.Columns[3].HeaderText = "Ngày Sinh";
            tbSinhVien.Columns[4].HeaderText = "CCCD";
            tbSinhVien.Columns[5].HeaderText = "Email";
            tbSinhVien.Columns[6].HeaderText = "Lớp Hành Chính";
            tbSinhVien.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnNhap_Click(object sender, EventArgs e)
        {
            txtCCCD.Enabled = true;
            txtEmail.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtTenSV.Enabled = true;
            txtMaSV.Enabled = true;
            txtLopHC.Enabled = true;
            //ẩn button
            btnTaiLai.Enabled = true;
            btnSua.Enabled = true;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            rdbtNam.Enabled = true;
            rdbtNu.Enabled = true;
            txtLopHC.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaSV = txtMaSV.Text;
            string TenSV = txtTenSV.Text;
            string CCCD = txtCCCD.Text;
            string Email = txtEmail.Text;
            DateTime NgaySinh = txtNgaySinh.Value;

            if (MaSV != "" && TenSV != "" && CCCD != "" && Email != "" && txtLopHC.Text != "")
            {
                if (sinhVienDAO.Check_MSV(constr, MaSV))
                {
                    if (rdbtNam.Checked == false && rdbtNu.Checked == false)
                        MessageBox.Show("Vui lòng chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (txtCCCD.Text.Length == 12)
                        {
                            if (sinhVienDAO.Check_CCCD(constr, CCCD))
                            {
                                string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                                if (Regex.IsMatch(txtEmail.Text, pattern))
                                {
                                    string MaLop = txtLopHC.SelectedValue.ToString();
                                    if (rdbtNam.Checked == true)
                                        sinhVienDAO.Them_SV(constr, MaSV, TenSV, rdbtNam.Text, NgaySinh, Email, CCCD, MaLop);
                                    else if (rdbtNu.Checked == true)
                                        sinhVienDAO.Them_SV(constr, MaSV, TenSV, rdbtNu.Text, NgaySinh, Email, CCCD, MaLop);
                                    MessageBox.Show("Thêm Sinh Viên thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    taiKhoanDAO.Them_DangNhap(constr, MaSV, MaSV, "SinhVien", 1);
                                    btnTaiLai_Click(sender, e);
                                }
                                else
                                    MessageBox.Show("Không phải Email, Vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                                MessageBox.Show("CCCD là duy nhất không được trùng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("CCCD phải có 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Mã Sinh Viên không được trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Vui lòng nhập tất cả các trường dữ liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            txtLopHC.Text = "";
            btnThem.Enabled = true;
            QLSinhVien_Load(sender, e);
            errorProvider1.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text != "" && txtTenSV.Text != "" && txtEmail.Text != "" && txtCCCD.Text != "" && txtLopHC.Text != "")
            {
                if (!sinhVienDAO.Check_MSV(constr, txtMaSV.Text))
                {
                    if (rdbtNam.Checked == false && rdbtNu.Checked == false)
                        MessageBox.Show("Vui lòng chọn giới tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (txtCCCD.Text.Length == 12)
                        {
                            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                            if (Regex.IsMatch(txtEmail.Text, pattern))
                            {
                                if (sinhVienDAO.Check_MSV(constr, txtMaSV.Text))
                                    MessageBox.Show("Không được sửa mã Sinh Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                {
                                    if (rdbtNam.Checked == true)
                                        sinhVienDAO.Sua_SinhVien(constr, txtMaSV.Text, txtTenSV.Text, rdbtNam.Text, txtNgaySinh.Value, txtEmail.Text, txtCCCD.Text, txtLopHC.SelectedValue.ToString());
                                    else
                                        sinhVienDAO.Sua_SinhVien(constr, txtMaSV.Text, txtTenSV.Text, rdbtNu.Text, txtNgaySinh.Value, txtEmail.Text, txtCCCD.Text, txtLopHC.SelectedValue.ToString());
                                    MessageBox.Show("Cập nhật Sinh Viên Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnTaiLai_Click(sender, e);
                                }
                            }
                            else
                                MessageBox.Show("Không phải Email, Vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("CCCD phải có 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Không được sửa Mã Sinh Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Không thế bỏ trống dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (sinhVienDAO.deleteSV(constr,maSV))
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
            string TenSV = txtTenSV.Text;
            string MaSV = txtMaSV.Text;
            string CCCD = txtCCCD.Text;
            string Email = txtEmail.Text;
            string LopHC = txtLopHC.Text;
            //
            if (rdbtNam.Checked == true)
                loadDataSV(sinhVienDAO.Timkiem_SV(constr,TenSV, MaSV, CCCD, Email, LopHC, rdbtNam.Text));
            else if (rdbtNu.Checked == true)
                loadDataSV(sinhVienDAO.Timkiem_SV(constr,TenSV, MaSV, CCCD, Email, LopHC, rdbtNu.Text));
            else
                loadDataSV(sinhVienDAO.Timkiem_SV(constr,TenSV, MaSV, CCCD, Email, LopHC, ""));
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            txtCCCD.Enabled = false;
            txtEmail.Enabled = false;
            txtNgaySinh.Enabled = false;
            txtTenSV.Enabled = false;
            txtMaSV.Enabled = false;
            txtLopHC.Enabled = false;
            //ẩn button
            btnTaiLai.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnTimKiem.Enabled = false;
            btnXoa.Enabled = false;
            rdbtNam.Enabled = false;
            rdbtNu.Enabled = false;
            rdbtNam.Checked = false;
            rdbtNu.Checked = false;
            txtLopHC.Text = "";
            hienTenLop();
            hienDSSinhVien();
            ViewHocSinh();
        }

        private void tbSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = tbSinhVien.CurrentRow.Cells[0].Value.ToString();
            txtTenSV.Text = tbSinhVien.CurrentRow.Cells[1].Value.ToString();
            txtNgaySinh.Text = tbSinhVien.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tbSinhVien.CurrentRow.Cells[5].Value.ToString();
            txtCCCD.Text = tbSinhVien.CurrentRow.Cells[4].Value.ToString();
            //txtLopHC.SelectedValue = tbSinhVien.CurrentRow.Cells[6].Value.ToString();
            txtLopHC.Text = tbSinhVien.CurrentRow.Cells[6].Value.ToString();
            if (tbSinhVien.CurrentRow.Cells[2].Value.ToString() == "Nam")
                rdbtNam.Checked = true;
            else if (tbSinhVien.CurrentRow.Cells[2].Value.ToString() == "Nữ")
                rdbtNu.Checked = true;
        }

        private void txtMaSV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaSV.Text == "")
            {
                errorProvider1.SetError(txtMaSV, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtMaSV, "");
        }

        private void txtTenSV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenSV.Text == "")
            {
                errorProvider1.SetError(txtTenSV, "Không được để trống !");
            }
            else
                errorProvider1.SetError(txtTenSV, "");
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

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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

        private void txtLopHC_Validating(object sender, CancelEventArgs e)
        {
            if (txtLopHC.Text == "")
            {
                errorProvider1.SetError(txtLopHC, "Không được để trống");
            }
            else
                errorProvider1.SetError(txtLopHC, "");
        }

    }
}
/*public DataTable Timkiem_theokhoang(string constr, DateTime dtbd, DateTime dtkt)
{
    using (SqlConnection cnn = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblPhieumuonchitiet WHERE dNgayhentra between '" + dtbd + "' and '" + dtkt + "'", cnn))
        {
            cmd.CommandType = CommandType.Text;
            using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            {
                using (DataTable dt = new DataTable("tblPhieumuonchitiet"))
                {
                    ad.Fill(dt);
                    return dt;
                }
            }
        }
    }
}*/
/*int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
int dob = int.Parse(NgaySinh.ToString("yyyyMMdd"));
int age = (now - dob) / 10000;
if (age < 18) Console.WriteLine("chua du tuoi");*/