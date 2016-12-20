using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using Petar_Tsvetkov_Blog.Migrations;
using Petar_Tsvetkov_Blog.Models;
using System.Data;

[assembly: OwinStartupAttribute(typeof(Petar_Tsvetkov_Blog.Startup))]
namespace Petar_Tsvetkov_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());
            ConfigureAuth(app);
        }
    }
}
