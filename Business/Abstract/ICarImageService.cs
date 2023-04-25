using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        List<CarImage> GetAll();
        CarImage GetById(int id);
        void Add(CarImage carImage);
        void Update(CarImage carImage);
        void Delete(int id);
    }
}
