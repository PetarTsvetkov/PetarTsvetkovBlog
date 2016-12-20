using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Petar_Tsvetkov_Blog.Models
{
   

    public class BlogDbContext : IdentityDbContext<AplicationUser>
    {
        public BlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public  virtual IDbSet<Article> Articles { get; set; }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}