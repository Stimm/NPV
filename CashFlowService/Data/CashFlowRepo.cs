using CashFlowService.Models;
using System;

namespace CashFlowService.Data
{
    public class CashFlowRepo : ICashFlowRepo
    {
        private readonly AppDbContext _context;

        public CashFlowRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool ExternalInvestmentExists(Guid externalInvestmentId)
        {
            return _context.Investment.Any(p => p.ExternalId == externalInvestmentId);
        }

        public IEnumerable<CashFlow> GetAllCashFlowsForInvestment(Guid id)
        {
            var cashFlows = _context.Cashflow.Where(x => x. == id);

            return cashFlows;
        }

        public IEnumerable<Investment> GetAllInvestment()
        {
            var investments = _context.Investment.ToList();

            return investments;
        }

        public bool InvestmentExists(Guid investmentId)
        {
            return _context.Investment.Any(p => p.Id == investmentId);
        }
    }
}
