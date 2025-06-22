using CashFlowService.Models;

namespace CashFlowService.Data
{
    public interface ICashFlowRepo
    {
        IEnumerable<Investment> GetAllInvestment();
        IEnumerable<CashFlow> GetAllCashFlowsForInvestment(Guid id);
        bool InvestmentExists(Guid investmentId);
        bool ExternalInvestmentExists(Guid externalInvestmentId);

    }
}
