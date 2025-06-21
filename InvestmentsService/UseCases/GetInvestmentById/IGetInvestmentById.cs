using InvestmentsService.Dtos;

namespace InvestmentsService.UseCases.GetInvestmentById
{
    public interface IGetInvestmentById
    {
        ReadInvestmentDto ExacuteAsync(Guid id);
    }
}
