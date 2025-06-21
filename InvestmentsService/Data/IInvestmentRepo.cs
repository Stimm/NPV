using InvestmentsService.Controllers;
using InvestmentsService.Models;

namespace InvestmentsService.Data;

public interface IInvestmentRepo
{
    IEnumerable<Investment> GetAllInvestments();
    Investment GetInvestment(Guid id);
}
