using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Stock_transfer_items")]
public partial class StockTransferItem
{
    [Key]
    public int Id { get; set; }

    [Column("Transfer_id")]
    public int TransferId { get; set; }

    [Column("Batch_id")]
    public int BatchId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Quantity { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    [ForeignKey("BatchId")]
    [InverseProperty("StockTransferItems")]
    public virtual ProductBatch Batch { get; set; } = null!;

    [ForeignKey("TransferId")]
    [InverseProperty("StockTransferItems")]
    public virtual StockTransfer Transfer { get; set; } = null!;
}
