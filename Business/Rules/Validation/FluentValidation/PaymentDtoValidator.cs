using Entities;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation.FluentValidation
{
    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(p => p.CardNumber)
                .Length(16)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.CardCvv)
                .Length(3)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.CardExpirationYear)
                .GreaterThan(DateTime.Now.Year % 100)
                .NotNull();

            RuleFor(p => p.CardExpirationMonth)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(12)
                .NotNull();
        }
    }
}