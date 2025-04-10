﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OzeSome.Data.Models;

public partial class Meeting
{
    [Key]
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime MeetingDate { get; set; }

    [StringLength(100)]
    public string MeetingStatus { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Meetings")]
    public virtual Customer Customer { get; set; } = null!;
}
