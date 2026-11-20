using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("roles")]
public partial class Role
{
    [Key]
    public int Id { get; set; }

    [Column("role_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string RoleName { get; set; } = null!;

    [Unicode(false)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
