using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnumDependentUI.Startup))]
namespace EnumDependentUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
