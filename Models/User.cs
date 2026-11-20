using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("users")]
[Index("Email", Name = "UQ__users__A9D10534EE12133A", IsUnique = true)]
[Index("Username", Name = "UQ__users__F3DBC57212C7906C", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(100)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("full_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Email { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("User")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [InverseProperty("User")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("User")]
    public virtual ICollection<StockTransfer> StockTransfers { get; set; } = new List<StockTransfer>();

    [ForeignKey("UserId")]
    [InverseProperty("Users")]
    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
