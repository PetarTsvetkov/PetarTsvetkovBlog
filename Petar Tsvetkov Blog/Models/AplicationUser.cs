using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Petar_Tsvetkov_Blog.Models
{
   public class AplicationUser : IdentityUser
        {
            
            public  string FullName { get; set; }

            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AplicationUser> manager)
            {
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                return userIdentity;
            }
        }
   }