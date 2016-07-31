using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdeaManagement.Presentation;

[assembly: OwinStartup(typeof(Startup))]
namespace IdeaManagement.Presentation
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
