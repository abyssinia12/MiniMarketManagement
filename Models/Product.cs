using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

[Table("products")]
[Index("Barcode", Name = "UQ__products__C16E36F8009156FB", IsUnique = true)]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("barcode")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Barcode { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<ProductBatch> ProductBatches { get; set; } = new List<ProductBatch>();

    [InverseProperty("Product")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [InverseProperty("Product")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
