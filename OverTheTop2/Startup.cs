using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OverTheTop2.Startup))]
namespace OverTheTop2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
