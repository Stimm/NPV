using InvestmentsService.Data;
using InvestmentsService.UseCases;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//UseCases
builder.Services.AddScoped<IGetAllInvestmentsUseCase, GetAllInvestmentsUseCase>();
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
