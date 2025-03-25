using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzeSome.Data.Models;


public partial class OrderDetail
{
    [Key]
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid ProductId { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("OrderDetails")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetail")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; } = null!;
}
