using Microsoft.EntityFrameworkCore;
using SplitExpenseTracker.Data.Models;

namespace SplitExpenseTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<DebtSettlement> DebtSettlements { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DebtSettlement>()
                .HasOne(ds => ds.Ower)
                .WithMany()
                .HasForeignKey(ds => ds.OwerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DebtSettlement>()
                .HasOne(ds => ds.OwedTo)
                .WithMany()
                .HasForeignKey(ds => ds.OwedToId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
