using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll(int? brandId = null, int? colorId = null);
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
        List<CarDetailDto> GetCarDetails();
        CarDetailDto GetCarDetailById(int id);
        void ChangeState(int carId, CarState state);
    }
}
