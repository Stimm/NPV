using AutoMapper;
using InvestmentsService.Dtos;
using InvestmentsService.Models;
namespace InvestmentsService.Profiles;

public class InvestmentProfile : Profile
{
    public InvestmentProfile()
    {
        CreateMap<Investment, ReadInvestmentDto>();
        CreateMap<WriteInvestmentDto, Investment>();
        CreateMap<WriteInvestmentDto, ReadInvestmentDto>();
    }
}
