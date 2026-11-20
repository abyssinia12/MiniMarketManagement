using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Storage_locations")]
public partial class StorageLocation
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<InventoryStock> InventoryStocks { get; set; } = new List<InventoryStock>();

    [InverseProperty("Location")]
    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    [InverseProperty("Location")]
    public virtual ICollection<SaleItemAllocation> SaleItemAllocations { get; set; } = new List<SaleItemAllocation>();

    [InverseProperty("FromLocation")]
    public virtual ICollection<StockTransfer> StockTransferFromLocations { get; set; } = new List<StockTransfer>();

    [InverseProperty("ToLocation")]
    public virtual ICollection<StockTransfer> StockTransferToLocations { get; set; } = new List<StockTransfer>();
}
