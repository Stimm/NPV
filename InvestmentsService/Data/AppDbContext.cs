namespace InvestmentsService.Data;
using InvestmentsService.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<Investment> Investment { get; set; }
}