using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities;

[Index(nameof(BrandId))]
public class Car : IEntity
{
    [Key] public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int ModelYear { get; set; }
    public double DailyPrice { get; set; }
    public string Plate { get; set; }
    public string Description { get; set; }
}