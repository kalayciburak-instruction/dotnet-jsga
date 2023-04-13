using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using Spring.Expressions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            CheckIfBrandExistsByName(brand.Name);
            CapitalizeBrandName(brand);
            _brandDal.Add(brand);
        }

        public void Delete(int id)
        {
            CheckIfBrandExists(id); // Defensive Coding
            _brandDal.Delete(id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            CheckIfBrandExists(id);
            return _brandDal.Get(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            CheckIfBrandExists(brand.Id);
            CapitalizeBrandName(brand);
            _brandDal.Update(brand);
        }

        public Brand GetByName(string name)
        {
            return _brandDal.Get(b => b.Name.ToLower() == name.ToLower());
        }

        // Business Rules
        private void CheckIfBrandExistsByName(string brandName)
        {
            if (_brandDal.Get(b => b.Name.ToLower() == brandName.ToLower()) != null)
            {
                throw new Exception("Marka zaten kayıtlı");
            }
        }

        private void CheckIfBrandExists(int id)
        {
            if (_brandDal.Get(b => b.Id == id) == null)
            {
                throw new Exception("Böyle bir kayıt bulunamadı.");
            }
        }

        private void CapitalizeBrandName(Brand brand)
        {
            TextInfo txtInfo = new CultureInfo("tr-TR", false).TextInfo;
            brand.Name =  txtInfo.ToTitleCase(brand.Name);
        }
    }
}
