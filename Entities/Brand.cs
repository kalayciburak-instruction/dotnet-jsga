using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities;

public class Brand : IEntity
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }
    //public List<Car> Cars { get; set; } DTO - Mapper zamanı aç ve kullan
}