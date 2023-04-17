using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using var context = new RentACarContext();
        var result = from car in context.Cars
                     join brand in context.Brands on car.BrandId equals brand.Id
                     join color in context.Colors on car.ColorId equals color.Id
                     select new CarDetailDto
                     {
                         Id = car.Id,
                         BrandName = brand.Name,
                         ColorName = color.Name,
                         DailyPrice = car.DailyPrice,
                         ModelYear = car.ModelYear,
                         Plate = car.Plate
                     };

        return result.ToList();
    }
}