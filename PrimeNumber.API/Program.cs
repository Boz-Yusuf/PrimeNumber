using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PrimeNumber.Core.Repositories;
using PrimeNumber.Core.Service;
using PrimeNumber.Core.UnitOfWork;
using PrimeNumber.Repository;
using PrimeNumber.Repository.Repositories;
using PrimeNumber.Repository.UnitOfWork;
using PrimeNumber.Service.Mapping;
using PrimeNumber.Service.Services;
using PrimeNumber.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<FindRequestDtoValidator>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#region Repositories
builder.Services.AddScoped<IPrimeNumberRepository, PrimeNumberRepository>();
#endregion

#region Services
builder.Services.AddScoped<IPrimeNumberService, PrimeNumberService>();
#endregion


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
