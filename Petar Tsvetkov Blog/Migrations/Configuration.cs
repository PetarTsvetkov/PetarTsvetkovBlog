namespace Petar_Tsvetkov_Blog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Petar_Tsvetkov_Blog;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;

    public sealed class Configuration : DbMigrationsConfiguration<Petar_Tsvetkov_Blog.Models.BlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Petar_Tsvetkov_Blog.Models.ApplocationDbContext";
        }

        protected override void Seed(Petar_Tsvetkov_Blog.Models.BlogDbContext context)
        {
            if (!context.Roles.Any())
            {
                this.CreateRole("Admin", context);
                this.CreateRole( "User", context);
            }

            if (!context.Users.Any())
            {
                this.CreateUser("admin@admin.com", "Admin", "123456",context);
                this.SetRoleToUser("admin@admin.com", "Admin", context);

                this.CreateUser("gosho@abv.com", "Gosho", "123456", context);
                this.SetRoleToUser("gosho@abv.com", "User", context);
            }
        }

        private void CreateRole(string roleName, BlogDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

           var result =  roleManager.Create(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void SetRoleToUser(string email, string role, BlogDbContext context)
        {
            var userManager = new UserManager<AplicationUser>(
                 new UserStore<AplicationUser>(context));

            var user = context.Users.Where(u => u.Email==email).First();
            var result = userManager.AddToRole(user.Id,role);
            if (!result.Succeeded)
            {
              throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(string email, string fullName, string pass,BlogDbContext context )
        {
            var userManager = new UserManager<AplicationUser>(
                new UserStore<AplicationUser>(context));

            userManager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = false,
                RequiredLength = 1,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };
            var admin = new AplicationUser()
            {
                Email = email,
                FullName = fullName,
                UserName = email
            };
            
            
           var result = userManager.Create(admin, pass);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";",result.Errors));
            }
        }
    }
}
