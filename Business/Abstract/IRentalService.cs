using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        Rental GetById(int id);
        void Add(RentalDto rentalDto);
        void Update(Rental rental);
        void Delete(int id);
    }
}
