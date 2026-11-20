using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("purchases")]
public partial class Purchase
{
    [Key]
    public int Id { get; set; }

    [Column("Supplier_id")]
    public int SupplierId { get; set; }

    [Column("User_id")]
    public int UserId { get; set; }

    [Column("Product_id")]
    public int ProductId { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Quantity { get; set; }

    [Column("Unit_cost", TypeName = "decimal(12, 2)")]
    public decimal UnitCost { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal Subtotal { get; set; }

    [Column("Total_cost", TypeName = "decimal(12, 2)")]
    public decimal TotalCost { get; set; }

    [Column("Amount_paid", TypeName = "decimal(12, 2)")]
    public decimal AmountPaid { get; set; }

    [Column("Payment_status")]
    [StringLength(50)]
    [Unicode(false)]
    public string PaymentStatus { get; set; } = null!;

    [Column("Purchase_date", TypeName = "datetime")]
    public DateTime PurchaseDate { get; set; }

    [Column("Created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("Purchases")]
    public virtual Product Product { get; set; } = null!;

    [InverseProperty("Purchase")]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } = new List<ProductBatch>();

    [ForeignKey("SupplierId")]
    [InverseProperty("Purchases")]
    public virtual Supplier Supplier { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Purchases")]
    public virtual User User { get; set; } = null!;
}
