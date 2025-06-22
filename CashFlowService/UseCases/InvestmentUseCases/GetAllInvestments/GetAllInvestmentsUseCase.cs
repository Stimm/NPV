using AutoMapper;
using CashFlowService.Data;
using InvestmentsService.Dtos;

namespace CashFlowService.UseCases.InvestmentUseCases.GetAllInvestments
{
    public class GetAllInvestmentsUseCase : IGetAllInvestmentsUseCase
    {
        private readonly ICashFlowRepo _repo;
        private readonly IMapper _mapper;

        public GetAllInvestmentsUseCase(ICashFlowRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        public IEnumerable<ReadInvestmentDto> ExacuteAsync()
        {
            var inventories = _repo.GetAllInvestment();

            var map = _mapper.Map<IEnumerable<ReadInvestmentDto>>(inventories);

            return map;
        }
    }
}
