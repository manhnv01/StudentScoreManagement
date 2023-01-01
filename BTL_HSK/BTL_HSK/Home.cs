using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private int interval = 30;

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSinhVien formSinhVien = new QLSinhVien();
            formSinhVien.MdiParent = this;
            formSinhVien.Dock = DockStyle.Fill;
            formSinhVien.Show();
        }
        public static string Quyen;
        private void Home_Load(object sender, EventArgs e)
        {
            if (Quyen == "SinhVien")
            {
                quảnLýToolStripMenuItem.Visible = false;
                baoToolStripMenuItem.Visible = false;
                thôngTinToolStripMenuItem.Text = "Kết Quả Học Tập";
                thôngTinToolStripMenuItem.Image = new Bitmap("Resources/score.png");
            }
            else if(Quyen == "GiangVien")
            {
                giảngViênToolStripMenuItem.Visible = false;
                lớpHànhChínhToolStripMenuItem.Visible = false;
                lớpHọcPhầnToolStripMenuItem.Visible = false;
                mônHọcToolStripMenuItem.Visible = false;
                tàiKhoảnToolStripMenuItem.Visible = false;
                thôngTinToolStripMenuItem.Text = "Lịch Giảng Dạy";
                thôngTinToolStripMenuItem.Image = BTL_HSK.Properties.Resources.Google_Calendar_icon_icons_com_75710;
            }
            else if(Quyen == "QuanLy")
            {
                thôngTinToolStripMenuItem.Visible=false;
            }
        }
        private void lớpHànhChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLopHC formLopHC = new QLLopHC();
            formLopHC.MdiParent = this;
            formLopHC.Dock = DockStyle.Fill;
            formLopHC.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLMonHoc formMonHoc = new QLMonHoc();
            formMonHoc.MdiParent = this;
            formMonHoc.Dock = DockStyle.Fill;
            formMonHoc.Show();
        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLGiangVien formGiangVien = new QLGiangVien();
            formGiangVien.MdiParent = this;
            formGiangVien.Dock = DockStyle.Fill;
            formGiangVien.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLDiem formDiem = new QLDiem();
            formDiem.MdiParent = this;
            formDiem.Dock = DockStyle.Fill;
            formDiem.Show();
        }

        private void lớpHọcPhầnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLopHocPhan formLopHocPhan = new QLLopHocPhan();
            formLopHocPhan.MdiParent = this;
            formLopHocPhan.Dock = DockStyle.Fill;
            formLopHocPhan.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn Đăng Xuất ", "Thông báo !", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Hide();
                DangNhap formDangNhap = new DangNhap();
                formDangNhap.ShowDialog();
                this.Close();
            }
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTaiKhoan formTaiKhoan = new QLTaiKhoan();
            formTaiKhoan.MdiParent = this;
            formTaiKhoan.Dock = DockStyle.Fill;
            formTaiKhoan.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK formDoiMK = new DoiMK();
            formDoiMK.MdiParent = this;
            formDoiMK.Dock = DockStyle.Fill;
            formDoiMK.Show();
            //this.LayoutMdi(MdiLayout.TileHorizontal);
            //Str1 = Str.Substring(0, 6) Cắt chuỗi từ vị trí đầu tiên(vị trí 0) đến vị trí số 6
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCDiemLopHocPhan bcdiemlophocphan = new BCDiemLopHocPhan();
            bcdiemlophocphan.MdiParent = this;
            bcdiemlophocphan.Dock = DockStyle.Fill;
            bcdiemlophocphan.Show();
        }

        private void báoCáoSinhViênLớpHànhChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCSinhVienLopHC bcsinhvienlophc = new BCSinhVienLopHC();
            bcsinhvienlophc.MdiParent = this;
            bcsinhvienlophc.Dock = DockStyle.Fill;
            bcsinhvienlophc.Show();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan formTTCN = new ThongTinCaNhan();
            formTTCN.MdiParent = this;
            formTTCN.Dock = DockStyle.Fill;
            formTTCN.Show();
        }

        private void báoCáoĐiểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BCKetQuaHocTap bcketquahoctap = new BCKetQuaHocTap();
            bcketquahoctap.MdiParent = this;
            bcketquahoctap.Dock = DockStyle.Fill;
            bcketquahoctap.Show();
        }
        private void mTimer_Tick(object sender, EventArgs e)
        {
            /*interval--;
            showToolStripMenuItem.Text = "The form will close after " + interval.ToString() + " seconds.";
            if (interval == 0)
                this.Close();*/
            //Application.Exit();
        }
    }
}
