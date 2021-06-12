using Microsoft.EntityFrameworkCore;

namespace xam
{
    public class ApplicationContext : DbContext
    {
        private string _databasePath;

        public DbSet<Books> Book { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}