using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OzeSome.Data.Models;

[PrimaryKey("OrderId", "CustomerId", "ProductId")]
public partial class OrderDetail
{
    [Key]
    public Guid OrderId { get; set; }

    [Key]
    public Guid CustomerId { get; set; }

    [Key]
    public Guid ProductId { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("OrderDetails")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("OrderDetails")]
    public virtual Product Product { get; set; } = null!;
}
