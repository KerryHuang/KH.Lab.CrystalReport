using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CrystalReport.WebFrom.Models;

namespace CrystalReport.WebFrom.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // 驗證使用者的電子郵件地址
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "使用者不存在或未確認。";
                    ErrorMessage.Visible = true;
                    return;
                }
                // 如需如何啟用帳戶確認和密碼重設的詳細資訊，請造訪 http://go.microsoft.com/fwlink/?LinkID=320771
                // 傳送包含驗證碼的電子郵件並重新導向至重設密碼頁面
                //string code = manager.GeneratePasswordResetToken(user.Id);
                //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "重設密碼", "請按 <a href=\"" + callbackUrl + "\">這裏</a> 重設密碼.");
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}