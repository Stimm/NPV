using AutoMapper;
using CashFlowService.Dtos.CashFlowDtos;
using CashFlowService.Models;
using InvestmentsService.Dtos;

namespace CashFlowService.Profiles
{
    public class CashFlowProfile : Profile
    {
        public CashFlowProfile()
        {
            CreateMap<Investment, ReadInvestmentDto>();
            CreateMap<CashFlow, ReadCashFlowDto>();

        }
    }
}
