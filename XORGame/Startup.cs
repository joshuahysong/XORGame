using Microsoft.Owin;
using Owin;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Web.Hosting;
using XORGame.Engines;

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
