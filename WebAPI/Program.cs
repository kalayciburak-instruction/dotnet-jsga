using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IBrandDal, EfBrandDal>()
                .AddSingleton<IBrandService, BrandManager>()
                .AddSingleton<ICarDal, EfCarDal>()
                .AddSingleton<ICarService, CarManager>()
                .AddSingleton<BrandBusinessRules>()
                .AddSingleton<BrandValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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