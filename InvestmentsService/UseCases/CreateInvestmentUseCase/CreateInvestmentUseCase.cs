using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;

namespace InvestmentsService.UseCases.CreateInvestmentUseCase
{
    public class CreateInvestmentUseCase : ICreateInvestmentUseCase
    {
        private readonly IInvestmentRepo _repo;
        private readonly IMapper _mapper;

        public CreateInvestmentUseCase(IInvestmentRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        public ReadInvestmentDto ExacuteAsync(WriteInvestmentDto investment)
        {
            if (investment == null)
            {
                throw new ArgumentNullException(nameof(investment));
            }

            var investmentModel = _mapper.Map<Investment>(investment);
            _repo.CreateInvestment(investmentModel);
                        
            var readInvestmentDto = _mapper.Map<ReadInvestmentDto>(investmentModel);

            return readInvestmentDto;
        }
    }
}
