using Entities;

namespace Core.Abstract;

public interface IBrandService
{
    List<Brand> GetAll();
    Brand GetById(int id);
    Brand GetByName(string name);
    void Add(Brand brand);
    void Update(Brand brand);
    void Delete(int id);
}