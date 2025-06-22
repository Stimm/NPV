using CashFlowService.Dtos.CashFlowDtos;

namespace CashFlowService.UseCases.CashFlowUseCases.GetAllCashFlowsForInvestment
{
    public interface IGetAllCashFlowsForInvestmentUseCase
    {
        IEnumerable<ReadCashFlowDto> ExacuteAsync(Guid id);
    }
}
