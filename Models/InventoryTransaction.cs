using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Inventory_transactions")]
public partial class InventoryTransaction
{
    [Key]
    public int Id { get; set; }

    [Column("Batch_id")]
    public int BatchId { get; set; }

    [Column("Location_id")]
    public int LocationId { get; set; }

    [Column("User_id")]
    public int UserId { get; set; }

    [Column("Transaction_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string TransactionType { get; set; } = null!;

    [Column("Quantity_in", TypeName = "decimal(12, 2)")]
    public decimal QuantityIn { get; set; }

    [Column("Quantity_out", TypeName = "decimal(12, 2)")]
    public decimal QuantityOut { get; set; }

    [Column("Reference_type")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ReferenceType { get; set; }

    [Column("Reference_id")]
    public int? ReferenceId { get; set; }

    [Column("Transaction_date", TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("BatchId")]
    [InverseProperty("InventoryTransactions")]
    public virtual ProductBatch Batch { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("InventoryTransactions")]
    public virtual StorageLocation Location { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("InventoryTransactions")]
    public virtual User User { get; set; } = null!;
}
