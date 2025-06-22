using InvestmentsService.Dtos;

namespace InvestmentsService.UseCases.UpdateInvestmentUseCase
{
    public interface IUpdateInvestmentUseCase
    {
        ReadInvestmentDto ExacuteAsync(Guid id, WriteInvestmentDto investment);
    }
}
