using Business.Rules.Validation.FluentValidation;
using Core.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class PaymentBusinessRules
    {
        private readonly IPaymentDal _paymentDal;
        private readonly PaymentValidator _validator;

        public PaymentBusinessRules(IPaymentDal paymentDal, PaymentValidator validator)
        {
            _paymentDal = paymentDal;
            _validator = validator;
        }

        public void ValidatePayment(Payment payment)
        {
            var result = _validator.Validate(payment);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errors);
            }
        }

        public void CheckIfPaymentValid(PaymentDto paymentDto)
        {
            if (_paymentDal.Get(p =>
            p.CardNumber == paymentDto.CardNumber &&
            p.CardHolder == paymentDto.CardHolder &&
            p.CardExpirationYear == paymentDto.CardExpirationYear &&
            p.CardExpirationMonth == paymentDto.CardExpirationMonth &&
            p.CardCvv == paymentDto.CardCvv) == null)
            {
                throw new BusinessException("NOT_A_VALID_PAYMENT");
            }
        }

        public void CheckIfBalanceEnough(double balance, double price)
        {
            if (balance - price < 0)
            {
                throw new BusinessException("NOT_ENOUGH_MONEY");
            }
        }

        public void CheckIfCardAlreadyExists(string cardNumber)
        {
            if (_paymentDal.Get(p => p.CardNumber == cardNumber) != null)
            {
                throw new BusinessException("NOT_A_VALID_CARD");
            }
        }
    }
}
