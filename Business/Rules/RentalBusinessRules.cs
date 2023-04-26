using Business.Abstract;
using Business.Constants;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalDal _rentalDal;

        public RentalBusinessRules(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public void CheckIfCarAvailable(CarState state)
        {
            if (state != CarState.Available)
            {
                throw new BusinessException(Messages.Car.CarNotAvailable);
            }
        }
    }
}
