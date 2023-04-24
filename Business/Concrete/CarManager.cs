using Business.Abstract;
using Business.Rules;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly CarBusinessRules _rules;

        public CarManager(ICarDal carDal, CarBusinessRules rules)
        {
            _carDal = carDal;
            _rules = rules;
        }

        public void Add(Car car)
        {
            _rules.ValidateCar(car);
            _rules.CheckIfCarExistsByPlate(car.Plate);
            _rules.CheckIfPlateIsValid(car.Plate);
            _carDal.Add(car);
        }

        public void Delete(int id)
        {
            _rules.CheckIfCarExists(id);
            _carDal.Delete(id);
        }

        public List<Car> GetAll(int? brandId = null, int? colorId = null)
        {
            return GetCarsByBrandAndColor(brandId, colorId);
        }

        public Car GetById(int id)
        {
            _rules.CheckIfCarExists(id);
            return _carDal.Get(c => c.Id == id);
        }

        public void Update(Car car)
        {
            _rules.CheckIfCarExists(car.Id);
            _carDal.Update(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }


        private List<Car> GetCarsByBrandAndColor(int? brandId, int? colorId)
        {
            var cars = _carDal.GetAll();

            if (brandId.HasValue)
            {
                cars = cars.Where(c => c.BrandId == brandId.Value).ToList();
            }

            if (colorId.HasValue)
            {
                cars = cars.Where(c => c.ColorId == colorId.Value).ToList();
            }

            return cars;
        }
    }
}
