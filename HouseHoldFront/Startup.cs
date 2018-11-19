using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HouseHoldFront.Startup))]
namespace HouseHoldFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
