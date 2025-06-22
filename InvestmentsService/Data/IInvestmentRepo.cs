using InvestmentsService.Controllers;
using InvestmentsService.Dtos;
using InvestmentsService.Models;

namespace InvestmentsService.Data;

public interface IInvestmentRepo
{
    IEnumerable<Investment> GetAllInvestments();
    Investment GetInvestment(Guid id);
    void CreateInvestment(Investment investment);
    void UpdateInvestment(Guid id, Investment request);
}
