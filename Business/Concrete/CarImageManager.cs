using Core.Abstract;
using Core.Utilities.Constants;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _imageDal;
        private readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal imageDal, IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }

        public void Add(CarImage carImage, IFormFile formFile)
        {
            carImage.Path = _fileHelper.AddFile(formFile, Paths.Car.Root);
            carImage.CreatedAt = DateTime.Now;

            _imageDal.Add(carImage);
        }

        public void Delete(int id)
        {
            var carImage = GetById(id);
            _fileHelper.DeleteFile(Paths.Car.Root + carImage.Path);
            _imageDal.Delete(id);
        }

        public List<CarImage> GetAll()
        {
            return _imageDal.GetAll();
        }

        public CarImage GetById(int id)
        {
            return _imageDal.Get(i => i.Id == id);
        }

        public void Update(CarImage carImage, IFormFile formFile)
        {
            carImage.Path = _fileHelper.UpdateFile(formFile, carImage.Path, Paths.Car.Root);
            carImage.CreatedAt = DateTime.Now;

            _imageDal.Update(carImage);
        }
    }
}
