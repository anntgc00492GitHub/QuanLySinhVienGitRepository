using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLySinhVien.Web.Startup))]
namespace QuanLySinhVien.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
