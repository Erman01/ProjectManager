using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectManager.MVCUI.Startup))]
namespace ProjectManager.MVCUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
