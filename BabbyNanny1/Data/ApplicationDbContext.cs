using BabbyNanny.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BabbyNanny.Data
{
    public class ApplicationDbContext : IdentityDbContext<WebUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ToDo> Todos { get; set; }
        public virtual DbSet<TodoCategories> TodoCategories { get; set; }
        public virtual DbSet<UserRating> UserRatings { get; set; }
    }

}