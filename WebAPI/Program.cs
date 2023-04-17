using Business.Abstract;
using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using Core.Middlewares;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IBrandDal, EfBrandDal>()
                .AddSingleton<IBrandService, BrandManager>()
                .AddSingleton<ICarDal, EfCarDal>()
                .AddSingleton<ICarService, CarManager>()
                .AddSingleton<BrandBusinessRules>()
                .AddSingleton<BrandValidator>()
                .AddSingleton<CarBusinessRules>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
//app.UseExceptionHandler(errorApp =>
//{
//    errorApp.Run(async error =>
//    {
//        var exceptionFeature = error.Features.Get<IExceptionHandlerPathFeature>();
//        if(exceptionFeature != null)
//        {
//            var exception = exceptionFeature.Error;

//            var result = new ExceptionResult
//            {
//                ErrorType = exception.GetType().Name,
//                Message = exception.Message
//            };

//            await error.Response.WriteAsJsonAsync(result);
//        }
//    });
//});

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