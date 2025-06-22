using AutoMapper;
using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsService.UseCases.UpdateInvestmentUseCase
{
    public class UpdateInvestmentUseCase : IUpdateInvestmentUseCase
    {
        private readonly IInvestmentRepo _repo;
        private readonly IMapper _mapper;

        public UpdateInvestmentUseCase(IInvestmentRepo repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        public ReadInvestmentDto ExacuteAsync(Guid id, WriteInvestmentDto investment)
        {
            var investmentExists = _repo.GetInvestment(id);

            if(investmentExists == null)
            {
                throw new KeyNotFoundException(nameof(investment));
            }

            var investmentModel = _mapper.Map<Investment>(investment);
            _repo.UpdateInvestment(id, investmentModel);

            var readInvestmentDto = _mapper.Map<ReadInvestmentDto>(investmentModel);
            return readInvestmentDto;
        }
    }
}
