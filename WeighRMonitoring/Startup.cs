using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeighRMonitoring.Startup))]
namespace WeighRMonitoring
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
