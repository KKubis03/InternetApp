using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzeSome.Data.Models;


public partial class Product
{
    [Key]
    public Guid Id { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid CategoryId { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime? EditDateTime { get; set; }
    public DateTime? DeleteDateTime { get; set; }
    public bool IsActive { get; set; }
    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
