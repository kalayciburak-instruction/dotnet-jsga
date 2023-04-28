using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IInvoiceService
    {
        List<Invoice> GetAll();
        Invoice GetById(int id);
        void Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(int id);
    }
}
