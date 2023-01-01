using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BTL_HSK
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }
        public void showReport(string reportFileName, string recordFilter = "")
        {

            ReportDocument reportDocument = new ReportDocument();
            string reportfile = string.Format("{0}\\CrystalReport\\{1}", Application.StartupPath, reportFileName);
            reportDocument.Load(reportfile);
            //TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            //tableLogOnInfo.ConnectionInfo.ServerName = "DESKTOP-O4R0S0J";
            //tableLogOnInfo.ConnectionInfo.DatabaseName = "DB_HSK";
            //tableLogOnInfo.ConnectionInfo.IntegratedSecurity = true;
            //foreach (Table table in reportDocument.Database.Tables)
            //{
            //    table.ApplyLogOnInfo(tableLogOnInfo);
            //}
            if (!string.IsNullOrEmpty(recordFilter))
            {
                reportDocument.RecordSelectionFormula = recordFilter;
            }
            cr.ReportSource = reportDocument;
            cr.Refresh();
        }
    }
}
