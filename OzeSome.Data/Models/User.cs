using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzeSome.Data.Models;


public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string FirstName { get; set; } = null!;

    [StringLength(30)]
    public string LastName { get; set; } = null!;

    [StringLength(60)]
    public string Position { get; set; } = null!;

    [StringLength(30)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string PhoneNumber { get; set; } = null!;

    [Column("QRCode")]
    [StringLength(255)]
    public string Qrcode { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }
}
