using BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserTelegram> Users { get; set; }
        public DbSet<Code> Codes { get; set; }

        private static bool FirstUse { get; set; } = true;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
#if DEBUG
            if(FirstUse)
            {
                FirstUse = false;
                Database.EnsureDeleted();
            }
#endif
            Database.EnsureCreated();
        }
    }
}
