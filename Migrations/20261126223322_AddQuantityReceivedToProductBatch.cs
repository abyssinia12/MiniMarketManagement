//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace MiniMarket.Migrations
//{
//    /// <inheritdoc />
//    public partial class AddQuantityReceivedToProductBatch : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "categories",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
//                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__categori__3214EC07E008D1A1", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "roles",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    role_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
//                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__roles__3214EC07993D8394", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "RoleUser",
//                columns: table => new
//                {
//                    RoleId = table.Column<int>(type: "int", nullable: false),
//                    UserId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UserId });
//                });

//            migrationBuilder.CreateTable(
//                name: "Storage_locations",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
//                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Storage___3214EC0777258D93", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "suppliers",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
//                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__supplier__3214EC07D504254F", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "users",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
//                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
//                    full_name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
//                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
//                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__users__3214EC0713F86B99", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "products",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    category_id = table.Column<int>(type: "int", nullable: false),
//                    barcode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
//                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
//                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__products__3214EC07FDE6FECE", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__products__catego__5DCAEF64",
//                        column: x => x.category_id,
//                        principalTable: "categories",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Stock_transfers",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    From_location_id = table.Column<int>(type: "int", nullable: false),
//                    To_location_id = table.Column<int>(type: "int", nullable: false),
//                    User_id = table.Column<int>(type: "int", nullable: false),
//                    Date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
//                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Stock_tr__3214EC0742711FA3", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__Stock_tra__From___0B91BA14",
//                        column: x => x.From_location_id,
//                        principalTable: "Storage_locations",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Stock_tra__To_lo__0C85DE4D",
//                        column: x => x.To_location_id,
//                        principalTable: "Storage_locations",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Stock_tra__User___0D7A0286",
//                        column: x => x.User_id,
//                        principalTable: "users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "user_roles",
//                columns: table => new
//                {
//                    user_id = table.Column<int>(type: "int", nullable: false),
//                    role_id = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__user_rol__6EDEA1536092831A", x => new { x.user_id, x.role_id });
//                    table.ForeignKey(
//                        name: "FK__user_role__role___5441852A",
//                        column: x => x.role_id,
//                        principalTable: "roles",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__user_role__user___534D60F1",
//                        column: x => x.user_id,
//                        principalTable: "users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "purchases",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Supplier_id = table.Column<int>(type: "int", nullable: false),
//                    User_id = table.Column<int>(type: "int", nullable: false),
//                    Product_id = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Unit_cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Subtotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Total_cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Amount_paid = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Payment_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
//                    Purchase_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
//                    Created_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__purchase__3214EC07D192F1ED", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__purchases__Produ__6B24EA82",
//                        column: x => x.Product_id,
//                        principalTable: "products",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__purchases__Suppl__693CA210",
//                        column: x => x.Supplier_id,
//                        principalTable: "suppliers",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__purchases__User___6A30C649",
//                        column: x => x.User_id,
//                        principalTable: "users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "sales",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Sale_id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
//                    User_id = table.Column<int>(type: "int", nullable: false),
//                    Product_id = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Unit_price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Subtotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Payment_method = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
//                    Payment_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValue: "Unpaid"),
//                    Sale_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
//                    Sale_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
//                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__sales__3214EC0756859A51", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__sales__Product_i__1BC821DD",
//                        column: x => x.Product_id,
//                        principalTable: "products",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__sales__User_id__1AD3FDA4",
//                        column: x => x.User_id,
//                        principalTable: "users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Product_batches",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Product_id = table.Column<int>(type: "int", nullable: false),
//                    Purchase_Id = table.Column<int>(type: "int", nullable: false),
//                    Batch_number = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
//                    Quantity_received = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Manufactured_date = table.Column<DateOnly>(type: "date", nullable: true),
//                    Expire_date = table.Column<DateOnly>(type: "date", nullable: true),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Product___3214EC0749BA698E", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__Product_b__Produ__73BA3083",
//                        column: x => x.Product_id,
//                        principalTable: "products",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Product_b__Purch__74AE54BC",
//                        column: x => x.Purchase_Id,
//                        principalTable: "purchases",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Inventory_stock",
//                columns: table => new
//                {
//                    Batch_id = table.Column<int>(type: "int", nullable: false),
//                    Location_id = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Updatedat = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Inventor__95D9D8A223436CB3", x => new { x.Batch_id, x.Location_id });
//                    table.ForeignKey(
//                        name: "FK__Inventory__Batch__7B5B524B",
//                        column: x => x.Batch_id,
//                        principalTable: "Product_batches",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Inventory__Locat__7C4F7684",
//                        column: x => x.Location_id,
//                        principalTable: "Storage_locations",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Inventory_transactions",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Batch_id = table.Column<int>(type: "int", nullable: false),
//                    Location_id = table.Column<int>(type: "int", nullable: false),
//                    User_id = table.Column<int>(type: "int", nullable: false),
//                    Transaction_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
//                    Quantity_in = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Quantity_out = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    Reference_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
//                    Reference_id = table.Column<int>(type: "int", nullable: true),
//                    Transaction_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
//                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Inventor__3214EC07997FD1A7", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__Inventory__Batch__03F0984C",
//                        column: x => x.Batch_id,
//                        principalTable: "Product_batches",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Inventory__Locat__04E4BC85",
//                        column: x => x.Location_id,
//                        principalTable: "Storage_locations",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Inventory__User___05D8E0BE",
//                        column: x => x.User_id,
//                        principalTable: "users",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Sale_item_allocations",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Sale_id = table.Column<int>(type: "int", nullable: false),
//                    Batch_id = table.Column<int>(type: "int", nullable: false),
//                    Location_id = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Sale_ite__3214EC0714280E50", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__Sale_item__Batch__2180FB33",
//                        column: x => x.Batch_id,
//                        principalTable: "Product_batches",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Sale_item__Locat__22751F6C",
//                        column: x => x.Location_id,
//                        principalTable: "Storage_locations",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Sale_item__Sale___208CD6FA",
//                        column: x => x.Sale_id,
//                        principalTable: "sales",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateTable(
//                name: "Stock_transfer_items",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Transfer_id = table.Column<int>(type: "int", nullable: false),
//                    Batch_id = table.Column<int>(type: "int", nullable: false),
//                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
//                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
//                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK__Stock_tr__3214EC07C12346B2", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK__Stock_tra__Batch__1332DBDC",
//                        column: x => x.Batch_id,
//                        principalTable: "Product_batches",
//                        principalColumn: "Id");
//                    table.ForeignKey(
//                        name: "FK__Stock_tra__Trans__123EB7A3",
//                        column: x => x.Transfer_id,
//                        principalTable: "Stock_transfers",
//                        principalColumn: "Id");
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Inventory_stock_Location_id",
//                table: "Inventory_stock",
//                column: "Location_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Inventory_transactions_Batch_id",
//                table: "Inventory_transactions",
//                column: "Batch_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Inventory_transactions_Location_id",
//                table: "Inventory_transactions",
//                column: "Location_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Inventory_transactions_User_id",
//                table: "Inventory_transactions",
//                column: "User_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Product_batches_Product_id",
//                table: "Product_batches",
//                column: "Product_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Product_batches_Purchase_Id",
//                table: "Product_batches",
//                column: "Purchase_Id");

//            migrationBuilder.CreateIndex(
//                name: "IX_products_category_id",
//                table: "products",
//                column: "category_id");

//            migrationBuilder.CreateIndex(
//                name: "UQ__products__C16E36F8009156FB",
//                table: "products",
//                column: "barcode",
//                unique: true,
//                filter: "[barcode] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "IX_purchases_Product_id",
//                table: "purchases",
//                column: "Product_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_purchases_Supplier_id",
//                table: "purchases",
//                column: "Supplier_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_purchases_User_id",
//                table: "purchases",
//                column: "User_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Sale_item_allocations_Batch_id",
//                table: "Sale_item_allocations",
//                column: "Batch_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Sale_item_allocations_Location_id",
//                table: "Sale_item_allocations",
//                column: "Location_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Sale_item_allocations_Sale_id",
//                table: "Sale_item_allocations",
//                column: "Sale_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_sales_Product_id",
//                table: "sales",
//                column: "Product_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_sales_User_id",
//                table: "sales",
//                column: "User_id");

//            migrationBuilder.CreateIndex(
//                name: "UQ__sales__FB9024C6C584B6A9",
//                table: "sales",
//                column: "Sale_id",
//                unique: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_Stock_transfer_items_Batch_id",
//                table: "Stock_transfer_items",
//                column: "Batch_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Stock_transfer_items_Transfer_id",
//                table: "Stock_transfer_items",
//                column: "Transfer_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Stock_transfers_From_location_id",
//                table: "Stock_transfers",
//                column: "From_location_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Stock_transfers_To_location_id",
//                table: "Stock_transfers",
//                column: "To_location_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_Stock_transfers_User_id",
//                table: "Stock_transfers",
//                column: "User_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_user_roles_role_id",
//                table: "user_roles",
//                column: "role_id");

//            migrationBuilder.CreateIndex(
//                name: "UQ__users__A9D10534EE12133A",
//                table: "users",
//                column: "Email",
//                unique: true,
//                filter: "[Email] IS NOT NULL");

//            migrationBuilder.CreateIndex(
//                name: "UQ__users__F3DBC57212C7906C",
//                table: "users",
//                column: "username",
//                unique: true);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Inventory_stock");

//            migrationBuilder.DropTable(
//                name: "Inventory_transactions");

//            migrationBuilder.DropTable(
//                name: "RoleUser");

//            migrationBuilder.DropTable(
//                name: "Sale_item_allocations");

//            migrationBuilder.DropTable(
//                name: "Stock_transfer_items");

//            migrationBuilder.DropTable(
//                name: "user_roles");

//            migrationBuilder.DropTable(
//                name: "sales");

//            migrationBuilder.DropTable(
//                name: "Product_batches");

//            migrationBuilder.DropTable(
//                name: "Stock_transfers");

//            migrationBuilder.DropTable(
//                name: "roles");

//            migrationBuilder.DropTable(
//                name: "purchases");

//            migrationBuilder.DropTable(
//                name: "Storage_locations");

//            migrationBuilder.DropTable(
//                name: "products");

//            migrationBuilder.DropTable(
//                name: "suppliers");

//            migrationBuilder.DropTable(
//                name: "users");

//            migrationBuilder.DropTable(
//                name: "categories");
//        }
//    }
//}


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniMarket.Migrations
{
    public partial class AddQuantityReceivedToProductBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity_received",
                table: "Product_batches",
                type: "decimal(12, 2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity_received",
                table: "Product_batches");
        }
    }
}
