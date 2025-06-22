using InvestmentsService.Dtos;

namespace InvestmentsService.SyncDataServices.Http
{
    public interface IInvestmentsDataClient
    {
        Task sendInvestmentsToCashFlow(ReadInvestmentDto investment);
    }
}
