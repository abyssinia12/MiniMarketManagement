using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("suppliers")]
public partial class Supplier
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [InverseProperty("Supplier")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
