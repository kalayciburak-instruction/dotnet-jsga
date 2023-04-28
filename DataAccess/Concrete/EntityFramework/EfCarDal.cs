using Core.Utilities.Constants;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
{
    private ICarImageDal _carImageDal;

    public EfCarDal(ICarImageDal carImageDal)
    {
        _carImageDal = carImageDal;
    }

    public List<CarDetailDto> GetCarDetails()
    {
        using var context = new RentACarContext();
        var result = from car in context.Cars
                     join brand in context.Brands on car.BrandId equals brand.Id
                     join color in context.Colors on car.ColorId equals color.Id
                     join image in context.CarImages on car.Id equals image.CarId into images
                     from image in images.DefaultIfEmpty()
                     select new CarDetailDto
                     {
                         Id = car.Id,
                         BrandName = brand.Name,
                         ColorName = color.Name,
                         DailyPrice = car.DailyPrice,
                         ModelYear = car.ModelYear,
                         Plate = car.Plate,
                         ImagePath = image != null ? image.Path : Paths.Car.DefaultImage
                     };

        return result.ToList();
    }

    public CarDetailDto GetCarDetailById(int id)
    {
        using var context = new RentACarContext();
        var result = from car in context.Cars
                     join brand in context.Brands on car.BrandId equals brand.Id
                     join color in context.Colors on car.ColorId equals color.Id
                     join image in context.CarImages on car.Id equals image.CarId into images
                     from image in images.DefaultIfEmpty()
                     where car.Id == id
                     select new CarDetailDto
                     {
                         Id = car.Id,
                         BrandName = brand.Name,
                         ColorName = color.Name,
                         DailyPrice = car.DailyPrice,
                         ModelYear = car.ModelYear,
                         Plate = car.Plate,
                         ImagePath = image != null ? image.Path : Paths.Car.DefaultImage
                     };

        return result.FirstOrDefault();
    }
}