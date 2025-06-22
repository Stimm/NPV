using AutoMapper;
using CashFlowService.Data;
using CashFlowService.Dtos.CashFlowDtos;

namespace CashFlowService.UseCases.CashFlowUseCases.GetAllCashFlowsForInvestment
{
    public class GetAllCashFlowsForInvestmentUseCase : IGetAllCashFlowsForInvestmentUseCase
    {
        private readonly ICashFlowRepo _repo;
        private readonly IMapper _mapper;
        public GetAllCashFlowsForInvestmentUseCase(CashFlowRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        public IEnumerable<ReadCashFlowDto> ExacuteAsync(Guid id)
        {
            if (!_repo.ExternalInvestmentExists(id))
            {
                return null;
            }

            var investmentID = _repo.GetAllInvestment().Where(x => x.ExternalId == id).First().Id;

            var cashFlows = _repo.GetAllCashFlowsForInvestment(investmentID);

            var map = _mapper.Map<IEnumerable<ReadCashFlowDto>>(cashFlows);

            return map;
        }
    }
}
