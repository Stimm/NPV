using InvestmentsService.Dtos;
using InvestmentsService.UseCases;
using InvestmentsService.UseCases.CreateInvestmentUseCase;
using InvestmentsService.UseCases.GetInvestmentById;
using InvestmentsService.UseCases.UpdateInvestmentUseCase;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentsService.Controllers;

[ApiController]
[Route("[controller]")]
public class InvestmentController : ControllerBase
{
    private IGetAllInvestmentsUseCase _GetAllInvestments;
    private IGetInvestmentById _GetInvestmentById;
    private ICreateInvestmentUseCase _createInvestment;
    private IUpdateInvestmentUseCase _updateInvestment;

    public InvestmentController(IGetAllInvestmentsUseCase getAllInvestmentsUseCase, 
        IGetInvestmentById getInvestmentById,
        ICreateInvestmentUseCase createInvestmentUseCase,
        IUpdateInvestmentUseCase updateInvestmentUseCase)
    {
        _GetAllInvestments = getAllInvestmentsUseCase;
        _GetInvestmentById = getInvestmentById;
        _createInvestment = createInvestmentUseCase;
        _updateInvestment = updateInvestmentUseCase;
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

    [HttpPost]
    public async Task<ActionResult<ReadInvestmentDto>> CreateInvestment(WriteInvestmentDto request)
    {
        Console.WriteLine("---> Create InvestmentEndPoint reached");

        var responce = _createInvestment.ExacuteAsync(request);

        return CreatedAtRoute(nameof(GetInvestmentById), new { id = responce.Id }, responce);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadInvestmentDto>> UpdateInvestment(Guid id, WriteInvestmentDto request)
    {
        Console.WriteLine("---> Update Investment EndPoint reached");

        var responce = _updateInvestment.ExacuteAsync(id, request);
        responce.Id = id;
        return CreatedAtRoute(nameof(GetInvestmentById), new { id = id }, responce);
    }
}
