using Core.Concrete;
using Core.Rules;
using Core.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities;
using FluentValidation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tests
{
    [TestFixture]
    public class BrandManagerTests
    {
        private Mock<IBrandDal> _brandDalMock;
        private BrandBusinessRules _rules;
        private BrandManager _manager;

        [SetUp]
        public void Setup()
        {
            _brandDalMock = new Mock<IBrandDal>();
            _rules = new BrandBusinessRules(_brandDalMock.Object,new BrandValidator());
            _manager = new BrandManager(_brandDalMock.Object, _rules);
        }

        [Test]
        public void ValidateBrand_ShouldThrowExceptionIfBrandIsInvalid()
        {
            // Arrange
            var invalidBrand = new Brand { Name = "" };

            // Act
            TestDelegate testDelegate = () => _rules.ValidateBrand(invalidBrand);

            //Assert
            Assert.Throws<ValidationException>(testDelegate);


            // Act & Assert (Birlikte kullanımı)
            //Assert.Throws<ValidationException>(() => _rules.ValidateBrand(invalidBrand));
        }
    }
}
