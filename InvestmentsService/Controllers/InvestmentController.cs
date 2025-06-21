using InvestmentsService.Data;
using InvestmentsService.Dtos;
using InvestmentsService.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsService.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private readonly IInvestmentRepo _repo;
    private IGetAllInvestmentsUseCase _GetAllInvestments;

    public InvestmentController(IInvestmentRepo repo, IGetAllInvestmentsUseCase getAllInvestmentsUseCase)
    {
        _repo = repo;
        _GetAllInvestments = getAllInvestmentsUseCase;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadInvestmentDto>> GetAllInvestments()
    {
        Console.WriteLine("---> Get all Investments EndPoint reached");
        var investments = _GetAllInvestments.ExacuteAsync();

        return Ok(investments);
    }
}
