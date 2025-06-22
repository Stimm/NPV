using InvestmentsService.Dtos;
using InvestmentsService.Models;

namespace InvestmentsService.UseCases.CreateInvestmentUseCase
{
    public interface ICreateInvestmentUseCase
    {
        ReadInvestmentDto ExacuteAsync(WriteInvestmentDto investment);
    }
}
