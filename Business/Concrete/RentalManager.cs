using Business.Abstract;
using Business.Constants;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly RentalBusinessRules _rules;

        public RentalManager(IRentalDal rentalDal, ICarService carService, RentalBusinessRules rules)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _rules = rules;
        }

        public void Add(Rental rental)
        {
            _rules.CheckIfCarAvailable(_carService.GetById(rental.CarId).State);
            rental.TotalPrice = rental.DailyPrice * rental.RentedForDays;
            rental.StartDate = DateTime.Now;
            rental.EndDate = null;
            _rentalDal.Add(rental);
            _carService.ChangeState(rental.CarId, CarState.Rented);
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            _rentalDal.Delete(id);
            _carService.ChangeState(rental.CarId, CarState.Available);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(r => r.Id == id);
        }

        public void Update(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
