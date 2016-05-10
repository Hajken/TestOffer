using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestOffer.Startup))]
namespace TestOffer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
