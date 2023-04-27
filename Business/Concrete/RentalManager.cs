using AutoMapper;
using Business.Abstract;
using Business.Constants;
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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;
        private readonly ICarService _carService;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly RentalBusinessRules _rules;
        private readonly IMapper _mapper;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IPaymentService paymentService, IInvoiceService invoiceService, RentalBusinessRules rules, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _rules = rules;
            _mapper = mapper;
        }

        public void Add(RentalDto rentalDto)
        {
            var rental = _mapper.Map<Rental>(rentalDto);
            _rules.CheckIfCarAvailable(_carService.GetById(rental.CarId).State);
            rental.TotalPrice = rental.DailyPrice * rental.RentedForDays;
            rental.StartDate = DateTime.Now;
            rental.EndDate = null;

            // Payment
            _rules.ValidatePaymentDto(rentalDto.Payment);
            rentalDto.Payment.Price = rental.TotalPrice;
            _paymentService.ProcessPayment(rentalDto.Payment);

            _rentalDal.Add(rental);
            _carService.ChangeState(rental.CarId, CarState.Rented);

            // Invoice
            AddInvoice(rentalDto, rental);
        }

        public void Delete(int id)
        {
            var rental = GetById(id);
            _rentalDal.Delete(id);
            _carService.ChangeState(rental.CarId, CarState.Available);
        }

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public Rental GetById(int id)
        {
            return _rentalDal.Get(r => r.Id == id);
        }

        public void Update(Rental rental)
        {
            throw new NotImplementedException();
        }

        private void AddInvoice(RentalDto rentalDto, Rental rental)
        {
            var invoice = new Invoice();
            var carDetail = _carService.GetCarDetailById(rental.CarId);

            invoice.CardHolder = rentalDto.Payment.CardHolder;
            invoice.BrandName = carDetail.BrandName;
            invoice.Plate = carDetail.Plate;
            invoice.DailyPrice = rental.DailyPrice;
            invoice.RentedForDays = rental.RentedForDays;
            invoice.ModelYear = carDetail.ModelYear;
            invoice.RentedAt = rental.StartDate;
            invoice.TotalPrice = rental.TotalPrice;

            _invoiceService.Add(invoice);
        }
    }
}
