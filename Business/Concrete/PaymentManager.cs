using Business.Abstract;
using Business.Rules;
using Core.Exceptions;
using DataAccess.Abstract;
using Entities;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly PaymentBusinessRules _rules;

        public PaymentManager(IPaymentDal paymentDal, PaymentBusinessRules rules)
        {
            _paymentDal = paymentDal;
            _rules = rules;
        }

        public void Add(Payment payment)
        {
            _rules.CheckIfCardAlreadyExists(payment.CardNumber);
            _rules.ValidatePayment(payment);
            _paymentDal.Add(payment);
        }

        public void Delete(int id)
        {
            _paymentDal.Delete(id);
        }

        public List<Payment> GetAll()
        {
            return _paymentDal.GetAll();
        }

        public Payment GetById(int id)
        {
            return _paymentDal.Get(p => p.Id == id);
        }


        public void Update(Payment payment)
        {
            _paymentDal.Update(payment);
        }

        public void ProcessPayment(PaymentDto paymentDto)
        {
            _rules.CheckIfPaymentValid(paymentDto);
            var payment = _paymentDal.Get(p => p.CardNumber == paymentDto.CardNumber);
            _rules.CheckIfBalanceEnough(payment.Balance, paymentDto.Price);
            payment.Balance = payment.Balance - paymentDto.Price;
            Update(payment);
        }
    }
}
