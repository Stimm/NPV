using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;

namespace InvestmentsService.UseCases
{
    public class GetAllInvestmentsUseCase : IGetAllInvestmentsUseCase
    {
        private readonly IInvestmentRepo _repo;
        private readonly IMapper _mapper;

        public GetAllInvestmentsUseCase(IInvestmentRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        public IEnumerable<ReadInvestmentDto> ExacuteAsync()
        {
            var inventories = _repo.GetAllInvestments();

            var map = _mapper.Map<IEnumerable<ReadInvestmentDto>>(inventories);

            return map;
        }
    }
}
