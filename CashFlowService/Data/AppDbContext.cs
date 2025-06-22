using CashFlowService.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlowService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Investment> Investment { get; set; }
        public DbSet<CashFlow> Cashflow { get; set; }
    }
}