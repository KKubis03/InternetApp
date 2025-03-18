﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OzeSomeAPI.Models;

public partial class Contract
{
    [Key]
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int OrderId { get; set; }

    [StringLength(40)]
    public string ContractStatus { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeleteDateTime { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Contracts")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Contracts")]
    public virtual Order Order { get; set; } = null!;
}
