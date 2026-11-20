using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[PrimaryKey("BatchId", "LocationId")]
[Table("Inventory_stock")]
public partial class InventoryStock
{
    [Key]
    [Column("Batch_id")]
    public int BatchId { get; set; }

    [Key]
    [Column("Location_id")]
    public int LocationId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Updatedat { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("BatchId")]
    [InverseProperty("InventoryStocks")]
    public virtual ProductBatch Batch { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("InventoryStocks")]
    public virtual StorageLocation Location { get; set; } = null!;
}
