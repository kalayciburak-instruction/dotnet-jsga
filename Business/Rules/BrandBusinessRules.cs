using Business.Constants;
using Business.Rules.Validation.FluentValidation;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandDal _brandDal;
        private readonly BrandValidator _validator;

        public BrandBusinessRules(IBrandDal brandDal, BrandValidator validator)
        {
            _brandDal = brandDal;
            _validator = validator;
        }

        public void ValidateBrand(Brand brand)
        {
            var result = _validator.Validate(brand);
            if (!result.IsValid)
            {
                var errors = string.Join(", ", result.Errors.Select(e => $"[{e.PropertyName}: {e.ErrorMessage}]"));
                throw new ValidationException(errors);
            }
        }

        public void CheckIfBrandExistsByName(string brandName)
        {
            if (_brandDal.Get(b => b.Name.ToLower() == brandName.ToLower()) != null)
                throw new ValidationException(Messages.Brand.AlreadyExists);
        }

        public void CheckIfBrandExists(int id)
        {
            if (_brandDal.Get(b => b.Id == id) == null) 
                throw new ValidationException(Messages.Brand.NotExists);
        }
    }
}
