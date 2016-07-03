using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CoffeeCupsAppService.Startup))]

namespace CoffeeCupsAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}