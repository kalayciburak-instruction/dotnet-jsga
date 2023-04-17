using System.Globalization;
using Business.Abstract;
using Business.Rules;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly BrandBusinessRules _rules;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules rules)
    {
        _brandDal = brandDal;
        _rules = rules;
    }

    public void Add(Brand brand)
    {
        _rules.ValidateBrand(brand);
        _rules.CheckIfBrandExistsByName(brand.Name);
        CapitalizeBrandName(brand);
        _brandDal.Add(brand);
    }

    public void Delete(int id)
    {
        _rules.CheckIfBrandExists(id); // Defensive Coding
        _brandDal.Delete(id);
    }

    public List<Brand> GetAll()
    {
        return _brandDal.GetAll();
    }

    public Brand GetById(int id)
    {
        _rules.CheckIfBrandExists(id);
        return _brandDal.Get(b => b.Id == id);
    }

    public void Update(Brand brand)
    {
        _rules.CheckIfBrandExists(brand.Id);
        CapitalizeBrandName(brand);
        _brandDal.Update(brand);
    }

    public Brand GetByName(string name)
    {
        return _brandDal.Get(b => b.Name.ToLower() == name.ToLower());
    }

    private void CapitalizeBrandName(Brand brand)
    {
        var txtInfo = new CultureInfo("tr-TR", false).TextInfo;
        brand.Name = txtInfo.ToTitleCase(brand.Name);
    }
}