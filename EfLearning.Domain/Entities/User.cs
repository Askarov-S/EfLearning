using EfLearning.Domain.Commons;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EfLearning.Domain.Entities;

public class User : Auditable
{
    public required string Name { get; set; } 
    public required string Email { get; set; }
    [MaxLength(4)]
    public required string Password { get; set; }
    public ICollection<Product> Products { get; set; }

}
