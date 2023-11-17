using EfLearning.Domain.Commons;

namespace EfLearning.Domain.Entities;

public class Product : Auditable
{
    public string ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductQuantity { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    
}
