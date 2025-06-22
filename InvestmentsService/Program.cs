using InvestmentsService.Data;
using InvestmentsService.SyncDataServices.Http;
using InvestmentsService.UseCases;
using InvestmentsService.UseCases.CreateInvestmentUseCase;
using InvestmentsService.UseCases.GetInvestmentById;
using InvestmentsService.UseCases.UpdateInvestmentUseCase;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//UseCases
builder.Services.AddScoped<IGetAllInvestmentsUseCase, GetAllInvestmentsUseCase>();
builder.Services.AddScoped<IGetInvestmentById, GetInvestmentById>();
builder.Services.AddScoped<ICreateInvestmentUseCase, CreateInvestmentUseCase>();
builder.Services.AddScoped<IUpdateInvestmentUseCase, UpdateInvestmentUseCase>();
//Reposotories
builder.Services.AddScoped<IInvestmentRepo, InvestmentRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


if (!builder.Environment.IsDevelopment())
{
    Console.WriteLine("--------->Using SQLDatabase");
    Console.WriteLine("--------->TODO set up SQL Database");
    //builder.Services.AddDbContext<AppDbContext>(opt =>
    //    opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
}
else
{
    Console.WriteLine("--------->Using In memory database");
    builder.Services.AddDbContext<AppDbContext>(opt =>
        opt.UseInMemoryDatabase("InMem"));
}

builder.Services.AddHttpClient<IInvestmentsDataClient, HttpCashFlowDataClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepDB(app, builder.Environment.IsDevelopment());

app.Run();
