using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calendar.WebMVC.Startup))]
namespace Calendar.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
