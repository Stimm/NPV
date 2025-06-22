using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
using InvestmentsService.SyncDataServices.Http;

namespace InvestmentsService.UseCases.CreateInvestmentUseCase
{
    public class CreateInvestmentUseCase : ICreateInvestmentUseCase
    {
        private readonly IInvestmentRepo _repo;
        private readonly IMapper _mapper;
        private readonly IInvestmentsDataClient _investmentsDataClient;

        public CreateInvestmentUseCase(IInvestmentRepo repo, IMapper map, IInvestmentsDataClient investmentsDataClient)
        {
            _repo = repo;
            _mapper = map;
            _investmentsDataClient = investmentsDataClient;
        }

        public async Task<ReadInvestmentDto> ExacuteAsync(WriteInvestmentDto investment)
        {
            if (investment == null)
            {
                throw new ArgumentNullException(nameof(investment));
            }

            var investmentModel = _mapper.Map<Investment>(investment);
            _repo.CreateInvestment(investmentModel);

            var readInvestmentDto = _mapper.Map<ReadInvestmentDto>(investmentModel);
            try
            {
                await _investmentsDataClient.sendInvestmentsToCashFlow(readInvestmentDto);
            }
            catch (Exception ex) { Console.WriteLine($"Could not send syncronously {ex.Message}"); }

            return readInvestmentDto;
        }
    }
}
