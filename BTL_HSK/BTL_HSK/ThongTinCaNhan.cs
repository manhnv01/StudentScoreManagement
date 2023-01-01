using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK
{
    public partial class ThongTinCaNhan : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.DiemDAO diemDAO = new DAO.DiemDAO();
        public ThongTinCaNhan()
        {
            InitializeComponent();
        }
        public static string code;
        public void hienDSKetQuaHocTap()
        {
            DataTable t = diemDAO.layDS(constr,"select TenMon,SoTinChi,MaLHP,MaGV,TenGV,DiemCC,DiemGK,DiemThi from diemCaNhan where MaSV='" + code + "'", "diemCaNhan");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbCaNhan.DataSource = t;
            tbCaNhan.Columns["STT"].DisplayIndex = 0;
        }
        public void hienDSBangDiemCaNhan()
        {
            DataTable t = diemDAO.layDS(constr,"select TenMon,SoTinChi,MaLHP,MaGV,TenGV,DiemCC,DiemGK,DiemThi from a where MaSV='" + code + "'","a");
            t.Columns.Add("STT");
            t.Columns.Add("TB Môn");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["TB Môn"] = Math.Round(double.Parse(t.Rows[i][5].ToString())*0.1+ double.Parse(t.Rows[i][6].ToString())*0.2+ double.Parse(t.Rows[i][7].ToString())*0.7,1);
            tbCaNhan.DataSource = t;
            tbCaNhan.Columns["STT"].DisplayIndex = 0;
            tbCaNhan.Columns["TB Môn"].DisplayIndex = 9;
        }
        public void hienDSGiangDay()
        {
            DataTable t = diemDAO.layDS(constr, "select TenMon,MaLHP,ThoiGianBatDau,ThoiGianKetThuc from GIangDay where ThoiGianKetThuc > GETDATE() and MaGV='" + code + "'", "GiangDay");
            t.Columns.Add("STT");
            for (int i = 0; i < t.Rows.Count; i++)
                t.Rows[i]["STT"] = i + 1;
            tbCaNhan.DataSource = t;
            tbCaNhan.Columns["STT"].DisplayIndex = 0;

        }
        private void ViewGiangDay()
        {
            tbCaNhan.ReadOnly = true;
            tbCaNhan.Columns[0].HeaderText = "Môn Học";
            tbCaNhan.Columns[1].HeaderText = "Lớp Học Phần";
            tbCaNhan.Columns[2].HeaderText = "Thời Gian Bắt Đầu";
            tbCaNhan.Columns[3].HeaderText = "Thời Gian Kết Thúc";
            tbCaNhan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCaNhan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCaNhan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCaNhan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void ViewDiemCaNhan()
        {
            tbCaNhan.ReadOnly = true;
            tbCaNhan.Columns[0].HeaderText = "Môn Học";
            tbCaNhan.Columns[1].HeaderText = "Số Tín";
            tbCaNhan.Columns[2].HeaderText = "Lớp";
            tbCaNhan.Columns[3].HeaderText = "Mã GV";
            tbCaNhan.Columns[4].HeaderText = "Tên Giảng Viên";
            tbCaNhan.Columns[5].HeaderText = "Chuyên Cần";
            tbCaNhan.Columns[6].HeaderText = "Kiểm Tra";
            tbCaNhan.Columns[7].HeaderText = "Thi";
            tbCaNhan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tbCaNhan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void layTTSV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SinhVien,LopHanhChinh where SinhVien.MaLop=LopHanhChinh.MaLop and MaSV= '" + code + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaSV"].Equals(code))
                            {
                                txtTen.Text = rd["TenSV"].ToString();
                                txtMa.Text = rd["MaSV"].ToString();
                                txtNgaySinh.Text = String.Format("{0:d}", rd["NgaySinh"]);
                                txtLop.Text = rd["TenLop"].ToString();
                                txtGioiTinh.Text = rd["GioiTinh"].ToString();
                                txtCCCD.Text = rd["CCCD"].ToString();
                                txtEmail.Text = rd["Email"].ToString();
                            }  
                        }
                    }
                }
            }
        }
        public void layTTGV()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from GiangVien where MaGV= '" + code + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaGV"].Equals(code))
                            {
                                txtTen.Text = rd["TenGV"].ToString();
                                txtMa.Text = rd["MaGV"].ToString();
                                txtSDT.Text = rd["SDT"].ToString();
                                txtCCCD.Text = rd["CCCD"].ToString();
                                txtEmail.Text = rd["Email"].ToString();
                            }
                        }
                    }
                }
            }
        }
        public void layTTBangDiemCaNhan()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from b where MaSV= '" + code + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaSV"].Equals(code))
                            {
                                txtTongTinChi.Text = rd["Tổng Tín Chỉ Tích Lũy"].ToString();
                                double diemhe4= double.Parse(rd["Tổng Điểm"].ToString()) / double.Parse(rd["Tổng Tín Chỉ Tích Lũy"].ToString());
                                double diemlamtron = Math.Round(diemhe4, 2);
                                txtTBC4.Text = diemlamtron.ToString();
                                if (diemlamtron < 2)
                                    txtXepLoai.Text = "Yếu";
                                else if (diemlamtron > 2 && diemlamtron < 2.49)
                                    txtXepLoai.Text = "Trung Bình";
                                else if(diemlamtron > 2.5 && diemlamtron < 3.19)
                                    txtXepLoai.Text = "Khá";
                                else if(diemlamtron > 3.2 && diemlamtron < 3.59)
                                    txtXepLoai.Text = "Giỏi";
                                else if(diemlamtron > 3.6 && diemlamtron < 4)
                                    txtXepLoai.Text = "Xuất Sắc";
                            }
                        }
                    }
                }
            }
        }
        public static string Quyen;
        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            panBangDiem.Visible = false;
            if (Quyen == "SinhVien")
            {
                hienDSKetQuaHocTap();
                ViewDiemCaNhan();
                layTTSV();
                panGV.Visible = false;
                txtTitle.Text = "Kết Quả Học Tập";
                txtChucVu.Text = "Sinh Viên";
                this.Text = "Kết Quả Học Tập";
                this.Icon = new Icon("Resources/score.ico");
            }
            else if(Quyen == "GiangVien")
            {
                hienDSGiangDay();
                ViewGiangDay();
                layTTGV();
                panSV.Visible = false;
                btnIn.Visible = false;
                cbXemBangDiemCaNhan.Visible = false;
                panBangDiem.Visible = false;
                txtTitle.Text = "Thông Tin Giảng Viên";
                txtChucVu.Text = "Giảng Viên";
                this.Text = "Lịch Giảng Dạy";
                this.Icon = new Icon("Resources/Google_Calendar_icon-icons.com_75710.ico");
            }
        }

        private void cbXemBangDiemCaNhan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXemBangDiemCaNhan.Checked == true)
            {
                panBangDiem.Visible = true;
                txtTitle.Text = "Bảng Điểm Cá Nhân";
                btnIn.Text = "In Bảng Điểm";
                layTTBangDiemCaNhan();
                hienDSBangDiemCaNhan();
            }
            else
            {
                btnIn.Text = "In Kết Quả Học Tập";
                ThongTinCaNhan_Load(sender, e);
            }
        }

        private void btnIn_MouseHover(object sender, EventArgs e)
        {
            btnIn.ForeColor = System.Drawing.Color.White;
            if (cbXemBangDiemCaNhan.Checked == true)
                btnIn.BackColor = System.Drawing.Color.Green;
            else
                btnIn.BackColor = System.Drawing.Color.Blue;
        }

        private void btnIn_MouseLeave(object sender, EventArgs e)
        {
            btnIn.ForeColor = System.Drawing.Color.Black;
            btnIn.BackColor = System.Drawing.Color.White;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cbXemBangDiemCaNhan.Checked == true)
            {
                string DieuKien = "";
                DieuKien += "{a.MaSV} ='" + code + "'";
                BaoCao formBaoCao = new BaoCao();
                formBaoCao.showReport("BangDiemCaNhan.rpt", DieuKien);
                formBaoCao.Show();
            }
            else
            {
                string DieuKien = "";
                DieuKien += "{Diem.MaSV} ='" + code + "'";
                BaoCao formBaoCao = new BaoCao();
                formBaoCao.showReport("KetQuaHocTap.rpt", DieuKien);
                formBaoCao.Show();
            }
        }
    }
}
