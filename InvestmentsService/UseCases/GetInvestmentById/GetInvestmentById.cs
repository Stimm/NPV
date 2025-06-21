using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;

namespace InvestmentsService.UseCases.GetInvestmentById
{
    public class GetInvestmentById : IGetInvestmentById
    {
        private readonly IInvestmentRepo _repo;
        private readonly IMapper _mapper;

        public GetInvestmentById(IInvestmentRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }
        public ReadInvestmentDto ExacuteAsync(Guid id)
        {
            var investment = _repo.GetInvestment(id);

            if (investment == null)
            {
                return null;
            }

            var map = _mapper.Map<ReadInvestmentDto>(investment);

            return map;
        }
    }
}
