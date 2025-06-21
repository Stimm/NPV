using InvestmentsService.Dtos;
using InvestmentsService.UseCases;
using InvestmentsService.UseCases.GetInvestmentById;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsService.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private IGetAllInvestmentsUseCase _GetAllInvestments;
    private IGetInvestmentById _GetInvestmentById;

    public InvestmentController(IGetAllInvestmentsUseCase getAllInvestmentsUseCase, IGetInvestmentById getInvestmentById)
    {
        _GetAllInvestments = getAllInvestmentsUseCase;
        _GetInvestmentById = getInvestmentById;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadInvestmentDto>> GetAllInvestments()
    {
        Console.WriteLine("---> Get all Investments EndPoint reached");
        var investments = _GetAllInvestments.ExacuteAsync();

        return Ok(investments);
    }

    [HttpGet("{id}", Name = "GetInvestmentById")]
    public ActionResult<ReadInvestmentDto> GetInvestmentById(Guid id)
    {
        Console.WriteLine("---> Get Investment by Id EndPoint reached");
        var investment = _GetInvestmentById.ExacuteAsync(id);

        if (investment == null)
        {
            return NotFound();
        }

        return Ok(investment);
    }
}
