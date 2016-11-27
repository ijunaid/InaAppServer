using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(InaAppService.Startup))]

namespace InaAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}