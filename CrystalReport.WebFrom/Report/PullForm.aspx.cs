using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReport.WebFrom.Report
{
    public partial class PullForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 報表文件類別
            ReportDocument reportdoc = new ReportDocument();

            // 讀取報表檔(建置動作改為:內容)
            reportdoc.Load(Server.MapPath("~/Report/Pull.rpt"));

            // 登入資訊
            CrystalDecisions.Shared.TableLogOnInfo logininfo;
           
            // 拉模式中要跳過輸入帳號密碼，在時處理
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportdoc.Database.Tables)
            {
                logininfo = table.LogOnInfo;
                logininfo.ConnectionInfo.UserID = "sa";
                logininfo.ConnectionInfo.Password = "@datamap123";
                table.ApplyLogOnInfo(logininfo);
            }

            // 設定報表來源
            this.CrystalReportViewer1.ReportSource = reportdoc;
        }
    }
}