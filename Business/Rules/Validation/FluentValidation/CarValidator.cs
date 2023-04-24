using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.Validation.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.Description).MaximumLength(50);
            RuleFor(c => c.ModelYear).GreaterThan(1999);
            RuleFor(c => c.ModelYear).LessThan(DateTime.Now.Year + 1);
        }
    }
}
