using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OzeSome.Data.Models;

public partial class Customer
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(30)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    public string LastName { get; set; } = null!;

    [StringLength(20)]
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(60)]
    public string Email { get; set; } = null!;

    public Guid AddressId { get; set; }

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
    [JsonIgnore]
    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    [InverseProperty("Customer")]
    [JsonIgnore]
    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    [InverseProperty("Customer")]
    [JsonIgnore]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
