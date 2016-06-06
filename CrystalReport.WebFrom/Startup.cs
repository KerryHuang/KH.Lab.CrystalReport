using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrystalReport.WebFrom.Startup))]
namespace CrystalReport.WebFrom
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
