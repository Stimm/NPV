﻿using InvestmentsService.Dtos;
using InvestmentsService.Models;

namespace InvestmentsService.UseCases.CreateInvestmentUseCase
{
    public interface ICreateInvestmentUseCase
    {
        Task<ReadInvestmentDto> ExacuteAsync(WriteInvestmentDto investment);
    }
}
