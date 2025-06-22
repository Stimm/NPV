using InvestmentsService.Dtos;

namespace CashFlowService.UseCases.InvestmentUseCases.GetAllInvestments
{
    public interface IGetAllInvestmentsUseCase
    {
        IEnumerable<ReadInvestmentDto> ExacuteAsync();
    }
}
