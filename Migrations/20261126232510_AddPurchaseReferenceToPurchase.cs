//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace MiniMarket.Migrations
//{
//    /// <inheritdoc />
//    public partial class AddPurchaseReferenceToPurchase : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.AddColumn<string>(
//                name: "Purchase_reference",
//                table: "purchases",
//                type: "nvarchar(50)",
//                maxLength: 50,
//                nullable: true);
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropColumn(
//                name: "Purchase_reference",
//                table: "purchases");
//        }
//    }
//}


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniMarket.Migrations
{
    public partial class AddPurchaseReferenceToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Purchase_reference",
                table: "purchases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purchase_reference",
                table: "purchases");
        }
    }
}
