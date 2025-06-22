using CashFlowService.Dtos.CashFlowDtos;
using CashFlowService.UseCases.CashFlowUseCases.GetAllCashFlowsForInvestment;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowService.Controllers
{
    [ApiController]
    [Route("api/c/Investment/{investmentId}/[controller]")]
    public class CashFlowController : ControllerBase
    {
        private IGetAllCashFlowsForInvestmentUseCase _getAllCashFlowsForInvestmentUseCase;

        public CashFlowController(IGetAllCashFlowsForInvestmentUseCase getAllCashFlowsForInvestmentUseCase)
        {
            _getAllCashFlowsForInvestmentUseCase = getAllCashFlowsForInvestmentUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReadCashFlowDto>> GetAllCashFlowsForInvestment(Guid investmentId)
        {
            Console.WriteLine($"Hit Get AllCash Flows For Investment for {investmentId}");

            var result = _getAllCashFlowsForInvestmentUseCase.ExacuteAsync(investmentId);

            return Ok(result);
        }
    }
}
