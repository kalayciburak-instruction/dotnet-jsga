using Core.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public void Add(Invoice invoice)
        {
            _invoiceDal.Add(invoice);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            return _invoiceDal.GetAll();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
