﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Brand : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Car> Cars { get; set; } DTO - Mapper zamanı aç ve kullan
    }
}
