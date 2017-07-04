using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElmahTest.Startup))]
namespace ElmahTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
