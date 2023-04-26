using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rental : IEntity
    {
        [Key] public int Id { get; set; }
        public int CarId { get; set; }
        public double DailyPrice { get; set; }
        public int RentedForDays { get; set; }
        public double TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
