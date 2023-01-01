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
    public partial class BCSinhVienLopHC : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.LopHanhChinhDAO lopHCDAO = new DAO.LopHanhChinhDAO();
        public BCSinhVienLopHC()
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

        private void BCSinhVienLopHC_Load(object sender, EventArgs e)
        {
            hienTenLop();
            btnLamTrong_Click(sender, e);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string DieuKien = "";
            if (txtLopHC.Text == "")
            {
                if (rbNam.Checked == true)
                    DieuKien += "{SinhVien.GioiTinh} ='" + rbNam.Text + "'";
                else if (rbNu.Checked == true)
                    DieuKien += "{SinhVien.GioiTinh} ='" + rbNu.Text + "'";
            }
            else
            {
                if (rbNam.Checked == true)
                    DieuKien += "{SinhVien.GioiTinh} ='" + rbNam.Text + "' and {LopHanhChinh.TenLop} ='" + txtLopHC.Text + "'";
                else if (rbNu.Checked == true)
                    DieuKien += "{SinhVien.GioiTinh} ='" + rbNu.Text + "' and {LopHanhChinh.TenLop} ='" + txtLopHC.Text + "'";
                else
                    DieuKien += "{LopHanhChinh.TenLop} ='" + txtLopHC.Text + "'";
            }
            showReport("SinhVienReport.rpt", DieuKien);
            //BaoCao formBaoCao = new BaoCao();
            //formBaoCao.showReport("SinhVienReport.rpt", DieuKien);
            //formBaoCao.Show();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            rbNam.Checked = false;
            rbNu.Checked = false;
            txtLopHC.Text = "";
        }
        public void showReport(string reportFileName, string recordFilter = "")
        {

            ReportDocument reportDocument = new ReportDocument();
            string reportfile = string.Format("{0}\\CrystalReport\\{1}", Application.StartupPath, reportFileName);
            reportDocument.Load(reportfile);
            if (!string.IsNullOrEmpty(recordFilter))
            {
                reportDocument.RecordSelectionFormula = recordFilter;
            }
            cr.ReportSource = reportDocument;
            cr.Refresh();
        }
    }
}
