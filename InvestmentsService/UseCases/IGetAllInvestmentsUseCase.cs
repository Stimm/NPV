using InvestmentsService.Dtos;

namespace InvestmentsService.UseCases
{
    public interface IGetAllInvestmentsUseCase
    {
        IEnumerable<ReadInvestmentDto> ExacuteAsync();
    }
}
