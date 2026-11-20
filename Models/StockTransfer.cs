using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("Stock_transfers")]
public partial class StockTransfer
{
    [Key]
    public int Id { get; set; }

    [Column("From_location_id")]
    public int FromLocationId { get; set; }

    [Column("To_location_id")]
    public int ToLocationId { get; set; }

    [Column("User_id")]
    public int UserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    [ForeignKey("FromLocationId")]
    [InverseProperty("StockTransferFromLocations")]
    public virtual StorageLocation FromLocation { get; set; } = null!;

    [InverseProperty("Transfer")]
    public virtual ICollection<StockTransferItem> StockTransferItems { get; set; } = new List<StockTransferItem>();

    [ForeignKey("ToLocationId")]
    [InverseProperty("StockTransferToLocations")]
    public virtual StorageLocation ToLocation { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("StockTransfers")]
    public virtual User User { get; set; } = null!;
}
