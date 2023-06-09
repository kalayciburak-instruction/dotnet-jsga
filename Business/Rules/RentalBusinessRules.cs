﻿using Core.Abstract;
using Core.Utilities.Constants;
using Core.Rules.Validation.FluentValidation;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Rules
{
    public class RentalBusinessRules
    {
        private readonly IRentalDal _rentalDal;
        private readonly PaymentDtoValidator _paymentDtoValidator;

        public RentalBusinessRules(IRentalDal rentalDal, PaymentDtoValidator paymentDtoValidator)
        {
            _rentalDal = rentalDal;
            _paymentDtoValidator = paymentDtoValidator;
        }

        public void ValidatePaymentDto(PaymentDto paymentDto)
        {
            var result = _paymentDtoValidator.Validate(paymentDto);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errors);
            }
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
