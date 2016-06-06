using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalReport.WebFrom.Models;

using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReport.WebFrom.Report
{
    public partial class PushForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            // 報表文件類別
            ReportDocument reportdoc = new ReportDocument();

            // 讀取報表檔(建置動作改為:內容)
            reportdoc.Load(Server.MapPath("~/Report/Push.rpt"));

            // 取得資料
            ProductRepository db = new ProductRepository();
            ProductDataSet ds = db.ExcuteDataSet();

            // 設定資料來源
            reportdoc.SetDataSource(ds);

            // 設定報表來源
            CrystalReportViewer1.ReportSource = reportdoc;

            // 建置報表
            CrystalReportViewer1.DataBind();
        }
    }
}