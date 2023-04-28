using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Invoice : IEntity
    {
        [Key] public int Id { get; set; }
        public string CardHolder { get; set; }
        public string BrandName { get; set; }
        public string ImagePath { get; set; }
        public string Plate { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public int RentedForDays { get; set; }
        public double TotalPrice { get; set; }
        public DateTime RentedAt { get; set; }
    }
}
