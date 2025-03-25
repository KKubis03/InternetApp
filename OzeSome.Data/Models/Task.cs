using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OzeSome.Data.Models;

public partial class Task
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string TaskStatus { get; set; } = null!;

    [StringLength(500)]
    public string Content { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Deadline { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }
}
