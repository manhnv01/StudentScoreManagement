using CrystalDecisions.CrystalReports.Engine;
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
    public partial class BCDiemLopHocPhan : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.LopHocPhanDAO lopHPDAO = new DAO.LopHocPhanDAO();
        public BCDiemLopHocPhan()
        {
            InitializeComponent();
        }
        public void hienTenLopHP()
        {
            DataTable t = lopHPDAO.layDS(constr, "select * from LopHocPhan", "LopHocPhan");
            DataView view = new DataView(t);
            view.Sort = "MaLHP";
            txtMaLHP.DataSource = view;
            txtMaLHP.DisplayMember = "MaLHP";
            txtMaLHP.ValueMember = "MaLHP";
        }

        private void btnInDiemLHP_Click(object sender, EventArgs e)
        {
            string DieuKien = "";
            DieuKien += "{LopHocPhan.MaLHP} ='" + txtMaLHP.Text + "'";
            //BaoCao formBaoCao = new BaoCao();
            //formBaoCao.showReport("DiemReport.rpt", DieuKien);
            //formBaoCao.Show();
            showReport("DiemReport.rpt", DieuKien);
        }

        private void BCDiemLopHocPhan_Load(object sender, EventArgs e)
        {
            hienTenLopHP();
        }
        public void showReport(string reportFileName, string recordFilter = "")
        {

            ReportDocument reportDocument = new ReportDocument();
            string reportfile = string.Format("{0}\\CrystalReport\\{1}", Application.StartupPath, reportFileName);
            reportDocument.Load(reportfile);
            //reportDocument.SummaryInfo.ReportComments = TaiKhoan;
            if (!string.IsNullOrEmpty(recordFilter))
            {
                reportDocument.RecordSelectionFormula = recordFilter;
            }
            cr.ReportSource = reportDocument;
            cr.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nkc = textBox1.Text;

            string filter = "";
            showReport("CrystalReport1.rpt", filter);

        }
    }
}
/*string nkc = dateTimePicker1.Value.ToString("yyyy-MM-dd");
string nht = dateTimePicker2.Value.ToString("yyyy-MM-dd");

string filter = "{LopHocPhan.ThoiGianKetThuc} >= '" + nkc + "' AND {LopHocPhan.ThoiGianKetThuc} <= '" + nht + "' and {LopHocPhan.ThoiGianBatDau} >= '" + nkc + "' AND {LopHocPhan.ThoiGianBatDau} <= '" + nht + "'";
showReport("CrystalReport1.rpt", filter);*/

/*string a = "";
string filter = "";
string ngaybatdau = dateTimebdau.Value.ToString();//ép kiểu về định dạng như của report
string ngayketthuc = dateTimekthuc.Value.ToString();//ép kiểu về định dạng như của report
filter += "{quatrinhdangnhap.timelogin} >= #" + ngaybatdau + "# AND {quatrinhdangnhap.timelogin} <= #" + ngayketthuc + "#";
showReport2("CrystalReport1.rpt", filter);
showReport2("CrystalReport2.rpt", a);
showReport2("CrystalReport3.rpt", "{tblThuthu.sMaTT} = '" + comboBox1.Text + "'");*/
/*public void demlandn(string constr, string matt)
{
    using (SqlConnection cnn = new SqlConnection(constr))
    {
        using (SqlCommand cmd = cnn.CreateCommand())
        {
            cnn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "solandn";
            cmd.Parameters.AddWithValue("@matt", matt);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}*/
/*public string sophieuttdalap(string constr, string matt)
{
    using (SqlConnection cnn = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("select * from abc where sMaTT='" + matt + "'", cnn))
        {
            cnn.Open();
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    if (rd["sMaTT"].Equals(matt))
                    {
                        return rd["abc"].ToString();
                    }
                }
                return "";
            }
        }
    }
}*/