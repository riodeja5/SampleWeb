using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SumidaWeb.Startup))]
namespace SumidaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
