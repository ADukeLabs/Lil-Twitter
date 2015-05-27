using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Joker.Startup))]
namespace Joker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
