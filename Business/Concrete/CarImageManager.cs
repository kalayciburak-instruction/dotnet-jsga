using Business.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public void Add(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public CarImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
