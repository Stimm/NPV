using InvestmentsService.Dtos;
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

    public void CreateInvestment(Investment investment)
    {
        _context.Investment.Add(investment);
        _context.SaveChanges();
    }

    public IEnumerable<Investment> GetAllInvestments()
    {
        var investments = _context.Investment.ToList();

        return investments;
    }

    public Investment GetInvestment(Guid id)
    {
        var investments = _context.Investment.Where(x => x.Id == id).First();

        return investments;
    }

    public void UpdateInvestment(Guid id, Investment request)
    {
        var investment = _context.Investment.Where(x => x.Id == id).SingleOrDefault();

        investment.Discription = request.Discription;
        investment.Name = request.Name;
        investment.DiscountRate = request.DiscountRate;

        _context.SaveChanges();
    }
}
