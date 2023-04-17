using Business.Constants;
using Core.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarDal _carDal;

        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CheckIfCarExists(int id)
        {
            if(_carDal.Get(c => c.Id == id) == null)
            {
                throw new BusinessException(Messages.Car.NotExists);
            }
        }

        public void CheckIfCarExistsByPlate(string plate)
        {
            if (_carDal.Get(c => c.Plate == plate) != null)
            {
                throw new BusinessException(Messages.Car.AlreadyExists);
            }
        }

        public void CheckIfPlateIsValid(string plate)
        {
            string pattern = @"^(\d{2} [A-Z]{1,3} \d{2,4})$";

            var regex = Regex.IsMatch(plate, pattern);
            if (!regex)
            {
                throw new BusinessException(Messages.Car.InvalidPlate);
            }
        }
    }
}
