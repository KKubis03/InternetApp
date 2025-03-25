using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OzeSome.Data.Models;

public partial class Address
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(30)]
    public string Street { get; set; } = null!;

    [StringLength(30)]
    public string Number { get; set; } = null!;

    [StringLength(30)]
    public string Code { get; set; } = null!;

    [StringLength(30)]
    public string City { get; set; } = null!;

    [StringLength(30)]
    public string Country { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("Address")]
    [JsonIgnore]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
