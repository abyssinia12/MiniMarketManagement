using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("sales")]
[Index("SaleId", Name = "UQ__sales__FB9024C6C584B6A9", IsUnique = true)]
public partial class Sale
{
    [Key]
    public int Id { get; set; }

    [Column("Sale_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string SaleId { get; set; } = null!;

    [Column("User_id")]
    public int UserId { get; set; }

    [Column("Product_id")]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Quantity { get; set; }

    [Column("Unit_price", TypeName = "decimal(12, 2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Subtotal { get; set; }

    [Column("Total_amount", TypeName = "decimal(12, 2)")]
    public decimal TotalAmount { get; set; }

    [Column("Payment_method")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentMethod { get; set; }

    [Column("Payment_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PaymentStatus { get; set; }

    [Column("Sale_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SaleStatus { get; set; }

    [Column("Sale_date", TypeName = "datetime")]
    public DateTime? SaleDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDelete { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Sales")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Sale")]
    public virtual ICollection<SaleItemAllocation> SaleItemAllocations { get; set; } = new List<SaleItemAllocation>();

    [ForeignKey("UserId")]
    [InverseProperty("Sales")]
    public virtual User User { get; set; } = null!;
}
