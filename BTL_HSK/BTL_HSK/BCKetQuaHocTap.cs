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
    public partial class BCKetQuaHocTap : Form
    {
        string constr = "Data Source=DESKTOP-O4R0S0J;Initial Catalog=DB_HSK;Integrated Security=True";
        DAO.SinhVienDAO sinhVienDAO = new DAO.SinhVienDAO();
        public BCKetQuaHocTap()
        {
            InitializeComponent();
        }
        
        public void hienMaSV()
        {
            DataTable t = sinhVienDAO.layDSSinhVien(constr, "select * from SinhVien", "SinhVien");
            DataView view = new DataView(t);
            view.Sort = "MaSV";
            txtMaSV.DataSource = view;
            txtMaSV.DisplayMember = "MaSV";
            txtMaSV.ValueMember = "MaSV";
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cbBangDiemCaNhan.Checked == true)
            {
                string DieuKien = "";
                DieuKien += "{a.MaSV} ='" + txtMaSV.Text + "'";
                showReport("BangDiemCaNhan.rpt", DieuKien);
            }
            else
            {
                string DieuKien = "";
                DieuKien += "{Diem.MaSV} ='" + txtMaSV.Text + "'";
                showReport("KetQuaHocTap.rpt", DieuKien);
            }
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

        private void BCKetQuaHocTap_Load(object sender, EventArgs e)
        {
            hienMaSV();
        }
    }
}
