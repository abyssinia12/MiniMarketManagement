//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

//namespace MiniMarket.Models;

//[Table("Product_batches")]
//public partial class ProductBatch
//{
//    [Key]
//    public int Id { get; set; }

//    [Column("Product_id")]
//    public int ProductId { get; set; }

//    [Column("Purchase_Id")]
//    public int PurchaseId { get; set; }

//    [Column("Batch_number")]
//    [StringLength(100)]
//    [Unicode(false)]
//    public string BatchNumber { get; set; } = null!;

//    [Column("Manufactured_date")]
//    public DateOnly? ManufacturedDate { get; set; }

//    [Column("Expire_date")]
//    public DateOnly? ExpireDate { get; set; }

//    public bool IsActive { get; set; }

//    public bool IsDelete { get; set; }

//    [InverseProperty("Batch")]
//    public virtual ICollection<InventoryStock> InventoryStocks { get; set; } = new List<InventoryStock>();

//    [InverseProperty("Batch")]
//    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

//    [ForeignKey("ProductId")]
//    [InverseProperty("ProductBatches")]
//    public virtual Product Product { get; set; } = null!;

//    [ForeignKey("PurchaseId")]
//    [InverseProperty("ProductBatches")]
//    public virtual Purchase Purchase { get; set; } = null!;

//    [InverseProperty("Batch")]
//    public virtual ICollection<SaleItemAllocation> SaleItemAllocations { get; set; } = new List<SaleItemAllocation>();

//    [InverseProperty("Batch")]
//    public virtual ICollection<StockTransferItem> StockTransferItems { get; set; } = new List<StockTransferItem>();
//}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Product_batches")]
public partial class ProductBatch
{
    [Key]
    public int Id { get; set; }

    [Column("Product_id")]
    public int ProductId { get; set; }

    [Column("Purchase_Id")]
    public int PurchaseId { get; set; }

    [Column("Batch_number")]
    [StringLength(100)]
    [Unicode(false)]
    public string BatchNumber { get; set; } = null!;

    [Column("Quantity_received", TypeName = "decimal(12, 2)")]
    public decimal QuantityReceived { get; set; }

    [Column("Manufactured_date")]
    public DateOnly? ManufacturedDate { get; set; }

    [Column("Expire_date")]
    public DateOnly? ExpireDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [InverseProperty("Batch")]
    public virtual ICollection<InventoryStock> InventoryStocks { get; set; } = new List<InventoryStock>();

    [InverseProperty("Batch")]
    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    [ForeignKey("ProductId")]
    [InverseProperty("ProductBatches")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("PurchaseId")]
    [InverseProperty("ProductBatches")]
    public virtual Purchase Purchase { get; set; } = null!;

    [InverseProperty("Batch")]
    public virtual ICollection<SaleItemAllocation> SaleItemAllocations { get; set; } = new List<SaleItemAllocation>();

    [InverseProperty("Batch")]
    public virtual ICollection<StockTransferItem> StockTransferItems { get; set; } = new List<StockTransferItem>();
}



