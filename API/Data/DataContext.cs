using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<AppUser> Users { get; set; }
        public DbSet<MasterBarang> MasterBarang { get; set; }

    }
}