using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Sale_item_allocations")]
public partial class SaleItemAllocation
{
    [Key]
    public int Id { get; set; }

    [Column("Sale_id")]
    public int SaleId { get; set; }

    [Column("Batch_id")]
    public int BatchId { get; set; }

    [Column("Location_id")]
    public int LocationId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Quantity { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    [ForeignKey("BatchId")]
    [InverseProperty("SaleItemAllocations")]
    public virtual ProductBatch Batch { get; set; } = null!;

    [ForeignKey("LocationId")]
    [InverseProperty("SaleItemAllocations")]
    public virtual StorageLocation Location { get; set; } = null!;

    [ForeignKey("SaleId")]
    [InverseProperty("SaleItemAllocations")]
    public virtual Sale Sale { get; set; } = null!;
}
