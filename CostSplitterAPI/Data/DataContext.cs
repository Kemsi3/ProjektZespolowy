using CostSplitterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CostSplitterAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(LocalDb)\\MSSQLLocalDB;database=CostSplitterDB;trusted_connection=true;TrustServerCertificate=True;MultipleActiveResultSets=True");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<SingleCost> SingleCosts { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
