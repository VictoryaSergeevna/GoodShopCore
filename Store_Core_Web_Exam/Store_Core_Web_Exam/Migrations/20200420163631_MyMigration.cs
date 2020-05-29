using Microsoft.EntityFrameworkCore.Migrations;

namespace Store_Core_Web_Exam.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Goods",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Title = table.Column<string>(nullable: true),
            //        Company = table.Column<string>(nullable: true),
            //        Price = table.Column<double>(nullable: false),
            //        FileName = table.Column<string>(nullable: true),
            //        Path = table.Column<string>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Goods", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Goods_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        OrderId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        User = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        ContactPhone = table.Column<string>(nullable: true),
            //        GoodId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.OrderId);
            //        table.ForeignKey(
            //            name: "FK_Orders_Goods_GoodId",
            //            column: x => x.GoodId,
            //            principalTable: "Goods",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Goods_CategoryId",
            //    table: "Goods",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_GoodId",
            //    table: "Orders",
            //    column: "GoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Goods");

            //migrationBuilder.DropTable(
            //    name: "Categories");
        }
    }
}
