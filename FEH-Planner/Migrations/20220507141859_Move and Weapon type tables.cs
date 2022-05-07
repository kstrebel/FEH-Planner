using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class MoveandWeapontypetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "WeaponType",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "MoveTypeID",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeaponTypeID",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MoveTypes",
                columns: table => new
                {
                    MoveTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveTypes", x => x.MoveTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    WeaponTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.WeaponTypeID);
                });

            migrationBuilder.InsertData(
                table: "MoveTypes",
                columns: new[] { "MoveTypeID", "Name" },
                values: new object[,]
                {
                    { 1, "Infantry" },
                    { 2, "Armored" },
                    { 3, "Cavalry" },
                    { 4, "Flying" }
                });

            migrationBuilder.InsertData(
                table: "WeaponTypes",
                columns: new[] { "WeaponTypeID", "Color", "Weapon" },
                values: new object[,]
                {
                    { 22, "Green", "Beast" },
                    { 21, "Blue", "Beast" },
                    { 20, "Red", "Beast" },
                    { 19, "Colorless", "Breath" },
                    { 18, "Green", "Breath" },
                    { 17, "Blue", "Breath" },
                    { 16, "Red", "Breath" },
                    { 15, "Colorless", "Dagger" },
                    { 14, "Green", "Dagger" },
                    { 13, "Blue", "Dagger" },
                    { 12, "Red", "Dagger" },
                    { 10, "Green", "Bow" },
                    { 23, "Colorless", "Beast" },
                    { 9, "Blue", "Bow" },
                    { 8, "Red", "Bow" },
                    { 7, "Colorless", "Tome" },
                    { 6, "Green", "Tome" },
                    { 5, "Blue", "Tome" },
                    { 4, "Red", "Tome" },
                    { 3, "Green", "Axe" },
                    { 2, "Blue", "Lance" },
                    { 1, "Red", "Sword" },
                    { 11, "Colorless", "Bow" },
                    { 24, "Colorless", "Staff" }
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 5,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 246,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 297,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 2, 17 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 520,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 4, 7 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 586,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 701,
                columns: new[] { "MoveTypeID", "WeaponTypeID" },
                values: new object[] { 3, 11 });

            migrationBuilder.CreateIndex(
                name: "IX_Units_MoveTypeID",
                table: "Units",
                column: "MoveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_WeaponTypeID",
                table: "Units",
                column: "WeaponTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_MoveTypes_MoveTypeID",
                table: "Units",
                column: "MoveTypeID",
                principalTable: "MoveTypes",
                principalColumn: "MoveTypeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_WeaponTypes_WeaponTypeID",
                table: "Units",
                column: "WeaponTypeID",
                principalTable: "WeaponTypes",
                principalColumn: "WeaponTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_MoveTypes_MoveTypeID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_WeaponTypes_WeaponTypeID",
                table: "Units");

            migrationBuilder.DropTable(
                name: "MoveTypes");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_MoveTypeID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_WeaponTypeID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "MoveTypeID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "WeaponTypeID",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "MovementType",
                table: "Units",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeaponType",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 5,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "i", "Red Sword" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 246,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "c", "Red Sword" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 297,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "a", "Blue Breath" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 520,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "f", "Colorless Tome" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 586,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "i", "Green Axe" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 701,
                columns: new[] { "MovementType", "WeaponType" },
                values: new object[] { "c", "Colorless Bow" });
        }
    }
}
