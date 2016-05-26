using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTLCongNgheWeb_Version2.Startup))]
namespace BTLCongNgheWeb_Version2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
