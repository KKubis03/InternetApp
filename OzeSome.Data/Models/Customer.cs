using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OzeSome.Data.Models;

public partial class Customer
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public Guid? AddressId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Customers")]
    public virtual Address? Address { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [InverseProperty("Customer")]
    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    [InverseProperty("Customer")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
