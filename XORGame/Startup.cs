using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XORGame.Startup))]
namespace XORGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
