using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CQRS.Example.Startup))]
namespace CQRS.Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
