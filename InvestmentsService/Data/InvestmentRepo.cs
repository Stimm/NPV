using InvestmentsService.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentsService.Data;

public class InvestmentRepo : IInvestmentRepo
{
    private readonly AppDbContext _context;

    public InvestmentRepo(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Investment> GetAllInvestments()
    {
        var investments = _context.Investment.ToList();

        return investments;
    }
}
