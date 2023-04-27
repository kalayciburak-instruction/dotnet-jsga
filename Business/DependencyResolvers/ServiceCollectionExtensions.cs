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
using Core.Utilities.Helpers.FileHelper;

namespace Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<ICarDal, EfCarDal>()
                    .AddSingleton<ICarService, CarManager>()
                    .AddSingleton<CarBusinessRules>()
                    .AddSingleton<CarValidator>()

                    .AddSingleton<IBrandDal, EfBrandDal>()
                    .AddSingleton<IBrandService, BrandManager>()
                    .AddSingleton<BrandBusinessRules>()
                    .AddSingleton<BrandValidator>()

                    .AddSingleton<IColorDal, EfColorDal>()
                    .AddSingleton<IColorService, ColorManager>()

                    .AddSingleton<ICarImageDal, EfCarImageDal>()
                    .AddSingleton<ICarImageService, CarImageManager>()

                    .AddSingleton<IRentalDal, EfRentalDal>()
                    .AddSingleton<IRentalService,RentalManager>()
                    .AddSingleton<RentalBusinessRules>()

                    .AddSingleton<IPaymentDal, EfPaymentDal>()
                    .AddSingleton<IPaymentService, PaymentManager>()
                    .AddSingleton<PaymentBusinessRules>()
                    .AddSingleton<PaymentValidator>()
                    .AddSingleton<PaymentDtoValidator>()

                    .AddSingleton<IInvoiceDal, EfInvoiceDal>()
                    .AddSingleton<IInvoiceService, InvoiceManager>()

                    .AddSingleton<IFileHelper, FileHelper>();

            return services;
        }
    }
}
