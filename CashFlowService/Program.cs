using CashFlowService.Data;
using CashFlowService.UseCases.CashFlowUseCases.GetAllCashFlowsForInvestment;
using CashFlowService.UseCases.InvestmentUseCases.GetAllInvestments;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//UseCases
builder.Services.AddScoped<IGetAllInvestmentsUseCase, GetAllInvestmentsUseCase>();
builder.Services.AddScoped<IGetAllCashFlowsForInvestmentUseCase, GetAllCashFlowsForInvestmentUseCase>();
//Reposotories
builder.Services.AddScoped<ICashFlowRepo, CashFlowRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

if (!builder.Environment.IsDevelopment())
{
    Console.WriteLine("--------->Using SQLDatabase");
    Console.WriteLine("--------->TODO set up SQL Database");
    //builder.Services.AddDbContext<AppDbContext>(opt =>
    //    opt.UseSqlServer(builder.Configuration.GetConnectionString("CashFlowsConn")));
}
else
{
    Console.WriteLine("--------->Using In memory database");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
