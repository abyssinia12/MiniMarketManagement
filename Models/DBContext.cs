using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiniMarket.Models;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<InventoryStock> InventoryStocks { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBatch> ProductBatches { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SaleItemAllocation> SaleItemAllocations { get; set; }

    public virtual DbSet<StockTransfer> StockTransfers { get; set; }

    public virtual DbSet<StockTransferItem> StockTransferItems { get; set; }

    public virtual DbSet<StorageLocation> StorageLocations { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MiniMarket;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3214EC07E008D1A1");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<InventoryStock>(entity =>
        {
            entity.HasKey(e => new { e.BatchId, e.LocationId }).HasName("PK__Inventor__95D9D8A223436CB3");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Updatedat).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Batch).WithMany(p => p.InventoryStocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Batch__7B5B524B");

            entity.HasOne(d => d.Location).WithMany(p => p.InventoryStocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Locat__7C4F7684");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07997FD1A7");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.TransactionDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Batch).WithMany(p => p.InventoryTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Batch__03F0984C");

            entity.HasOne(d => d.Location).WithMany(p => p.InventoryTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__Locat__04E4BC85");

            entity.HasOne(d => d.User).WithMany(p => p.InventoryTransactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Inventory__User___05D8E0BE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3214EC07FDE6FECE");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__products__catego__5DCAEF64");
        });

        modelBuilder.Entity<ProductBatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3214EC0749BA698E");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductBatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_b__Produ__73BA3083");

            entity.HasOne(d => d.Purchase).WithMany(p => p.ProductBatches)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_b__Purch__74AE54BC");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__purchase__3214EC07D192F1ED");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PurchaseDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchases__Produ__6B24EA82");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchases__Suppl__693CA210");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__purchases__User___6A30C649");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roles__3214EC07993D8394");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sales__3214EC0756859A51");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);
            entity.Property(e => e.PaymentStatus).HasDefaultValue("Unpaid");
            entity.Property(e => e.SaleDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__Product_i__1BC821DD");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sales__User_id__1AD3FDA4");
        });

        modelBuilder.Entity<SaleItemAllocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale_ite__3214EC0714280E50");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);

            entity.HasOne(d => d.Batch).WithMany(p => p.SaleItemAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale_item__Batch__2180FB33");

            entity.HasOne(d => d.Location).WithMany(p => p.SaleItemAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale_item__Locat__22751F6C");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleItemAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale_item__Sale___208CD6FA");
        });

        modelBuilder.Entity<StockTransfer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stock_tr__3214EC0742711FA3");

            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);

            entity.HasOne(d => d.FromLocation).WithMany(p => p.StockTransferFromLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_tra__From___0B91BA14");

            entity.HasOne(d => d.ToLocation).WithMany(p => p.StockTransferToLocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_tra__To_lo__0C85DE4D");

            entity.HasOne(d => d.User).WithMany(p => p.StockTransfers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_tra__User___0D7A0286");
        });

        modelBuilder.Entity<StockTransferItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stock_tr__3214EC07C12346B2");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDelete).HasDefaultValue(false);

            entity.HasOne(d => d.Batch).WithMany(p => p.StockTransferItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_tra__Batch__1332DBDC");

            entity.HasOne(d => d.Transfer).WithMany(p => p.StockTransferItems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock_tra__Trans__123EB7A3");
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storage___3214EC0777258D93");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__supplier__3214EC07D504254F");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC0713F86B99");

            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__user_role__role___5441852A"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__user_role__user___534D60F1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__user_rol__6EDEA1536092831A");
                        j.ToTable("user_roles");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("RoleId").HasColumnName("role_id");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
