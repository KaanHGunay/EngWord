using System.Data.Entity;

namespace DataBase
{
    public class Context : DbContext
    {
        public DbSet<TurWord> TurWords { get; set; }
        public DbSet<EngWord> EngWords { get; set; }
    }
}
