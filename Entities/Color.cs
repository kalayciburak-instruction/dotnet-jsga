using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities;

public class Color : IEntity
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
}