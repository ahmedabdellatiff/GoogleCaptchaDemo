using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleCaptchaDemo.Startup))]
namespace GoogleCaptchaDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
