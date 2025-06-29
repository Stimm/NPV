﻿using CashFlowService.UseCases.InvestmentUseCases.GetAllInvestments;
using InvestmentsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowService.Controllers
{
    [ApiController]
    [Route("api/c/[Controller]")]
    public class InvestmentController : ControllerBase
    {
        private IGetAllInvestmentsUseCase _getAllInvestments;

        public InvestmentController(IGetAllInvestmentsUseCase getAllInvestmentsUseCase)
        {
            _getAllInvestments = getAllInvestmentsUseCase;
        }

        [HttpPost]
        public ActionResult TestInboudConnection()
        {
            Console.WriteLine("Inbound Post @ command service");

            return Ok("Test ok from Investment controller");
        }


        [HttpGet]
        public ActionResult<IEnumerable<ReadInvestmentDto>> GetAllInvestments()
        {
            Console.WriteLine("---> Get all Investments EndPoint reached");
            var investments = _getAllInvestments.ExacuteAsync();

            return Ok(investments);
        }
    }
}
