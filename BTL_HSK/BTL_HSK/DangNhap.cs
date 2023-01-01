using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_HSK
{
    public partial class DangNhap : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        int dem = 0;
        //private int interval=3000;// 5 mins
        string Quyen;
        DAO.TaiKhoanDAO taiKhoanDAO = new DAO.TaiKhoanDAO();
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        public bool CheckDangNhap()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from DangNhap where TaiKhoan= '" + txtTaiKhoan.Text + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (String.Compare(rd["MatKhau"].ToString(), txtMatKhau.Text, true) == 0)
                                //if (rd["MatKhau"].Equals(txtMatKhau.Text))
                            {
                                Home.Quyen = (string)rd["Quyen"];
                                QLTaiKhoan.TaiKhoan = (string)rd["TaiKhoan"];
                                ThongTinCaNhan.code = (string)rd["TaiKhoan"];
                                ThongTinCaNhan.Quyen= (string)rd["Quyen"];
                                DoiMK.TaiKhoan=(string)rd["TaiKhoan"];
                                DoiMK.MatKhauOld = (string)rd["MatKhau"];
                                QLDiem.TaiKhoan= (string)rd["TaiKhoan"];
                                QLDiem.Quyen= (string)rd["Quyen"];
                                Quyen = (string)rd["Quyen"];
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public bool CheckTrangThai()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from DangNhap where TaiKhoan= '" + txtTaiKhoan.Text + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (int.Parse(rd["TrangThai"].ToString()) == 1)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        private void KhoaTK()
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    if (!CheckDangNhap())
                        dem++;
                    if (dem>3)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Khoa_DangNhap";
                        cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                        cmd.Parameters.AddWithValue("@TrangThai", 0);
                        int i = cmd.ExecuteNonQuery();
                        cnn.Close();
                        dem = 0;
                    }
                }
            }
        }
        private void KhoaTKtheotime(DateTime time)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "updatelastlogin";
                    cmd.Parameters.AddWithValue("@TaiKhoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@lastlogin", time);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    dem = 0;
                }
            }
        }
        public string layTimelock(string constr, string TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from DangNhap where TaiKhoan= '" + TaiKhoan + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["TaiKhoan"].Equals(TaiKhoan))
                                return rd["LastLogin"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TimeSpan aInterval = new System.TimeSpan(0, 0, 1, 0);
            if (txtTaiKhoan.Text!="" && txtMatKhau.Text!="")
            {
                if (!taiKhoanDAO.Check_TaiKhoan(constr,txtTaiKhoan.Text))
                {
                    if (CheckTrangThai())
                    {
                        if (CheckDangNhap())
                        {
                            int result = 1;
/*                            int result = DateTime.Compare(DateTime.Now.Subtract(aInterval), DateTime.Parse(layTimelock(constr, txtTaiKhoan.Text)));*/
                            if (result >= 0)
                            {

                                if (Quyen == "QuanLy") MessageBox.Show("Quyền Quản Trị", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (Quyen == "SinhVien") MessageBox.Show("Quyền Sinh Viên", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (Quyen == "GiangVien") MessageBox.Show("Quyền Giảng Viên", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                Home formHome = new Home();
                                formHome.ShowDialog();
                                this.Close();
                            }
                            else
                                MessageBox.Show("Tài khoản này bị khóa đến " + DateTime.Parse(layTimelock(constr, txtTaiKhoan.Text)).Add(aInterval), "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            /*                            KhoaTK();*/
                            dem++;
                            /* if (dem > 3)
                             {
                                 DateTime dt = DateTime.Now;
                                 KhoaTKtheotime(dt);
                            MessageBox.Show("Tài khoản này bị khóa đến " + DateTime.Parse(layTimelock(constr, txtTaiKhoan.Text)).Add(aInterval), "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             }
                             else*/
                            MessageBox.Show("Mật khẩu không chính xác", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtMatKhau.Focus();
                        }
                    }
                    else
                        MessageBox.Show("Tài khoản này đang bị khóa, Vui lòng liên hệ Quản trị viên để mở", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không tồn tại", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTaiKhoan.Focus();
                }
            }    
            else
                MessageBox.Show("Vui lòng điền thông tin", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbhienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (cbhienmk.Checked == true)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            dem = 0;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            //    Timer mTimer = new Timer();
            //    mTimer.Interval = interval;
            //    mTimer.Tick += new EventHandler(mTimer_Tick);
            //    mTimer_Tick(sender, e);
            //    mTimer.Start();
        }
        private void mTimer_Tick(object sender, EventArgs e)
        {
/*            interval--;
            lblRemainingTime.Text = "The form will close after " + interval.ToString() + " seconds.";
            if (interval == 0)
                this.Close();
            Application.Exit();*/
        }
        //string a = "ABCDEFG";
        //string newstring = a.Substring(0, 3);
    }
}
