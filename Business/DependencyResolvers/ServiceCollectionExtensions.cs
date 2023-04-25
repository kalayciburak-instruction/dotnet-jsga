using Business.Abstract;
using Business.Concrete;
using Business.Rules.Validation.FluentValidation;
using Business.Rules;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IBrandDal, EfBrandDal>()
                    .AddSingleton<IBrandService, BrandManager>()
                    .AddSingleton<ICarDal, EfCarDal>()
                    .AddSingleton<ICarService, CarManager>()
                    .AddSingleton<IColorDal, EfColorDal>()
                    .AddSingleton<IColorService, ColorManager>()
                    .AddSingleton<BrandBusinessRules>()
                    .AddSingleton<BrandValidator>()
                    .AddSingleton<CarBusinessRules>()
                    .AddSingleton<CarValidator>();

            return services;
        }
    }
}
