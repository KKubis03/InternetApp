using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzeSome.Data.Models;

public partial class MeetingStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(200)]
    public string StatusName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [InverseProperty("MeetingStatus")]
    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

    
}
