using Core.DataAccess;
using Entities;
using Entities.Dto;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetCarDetails();
}