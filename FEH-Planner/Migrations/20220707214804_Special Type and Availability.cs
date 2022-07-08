using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class SpecialTypeandAvailability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Entry1",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Entry2",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SpecialType",
                table: "Units");

            migrationBuilder.AddColumn<int>(
                name: "AvailabilityID",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Entry1ID",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Entry2ID",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialTypeID",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    AvailabilityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.AvailabilityID);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    EntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.EntryID);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTypes",
                columns: table => new
                {
                    SpecialTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTypes", x => x.SpecialTypeID);
                });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "AvailabilityID", "Name" },
                values: new object[,]
                {
                    { 1, "Regular" },
                    { 2, "Grail" },
                    { 3, "Seasonal" },
                    { 4, "Legendary/Mythic" }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "EntryID", "Name" },
                values: new object[,]
                {
                    { 15, "Tokyo Mirage Sessions" },
                    { 14, "Three Houses" },
                    { 13, "Fates" },
                    { 12, "Awakening" },
                    { 10, "Radiant Dawn" },
                    { 9, "Path of Radiance" },
                    { 8, "Sacred Stones" },
                    { 6, "Binding Blade" },
                    { 5, "Thracia 776" },
                    { 4, "Geneology" },
                    { 3, "Valentia" },
                    { 2, "Mystery/Shadow Dragon" },
                    { 1, "Heroes" },
                    { 7, "Blazing Blade" }
                });

            migrationBuilder.InsertData(
                table: "SpecialTypes",
                columns: new[] { "SpecialTypeID", "Name" },
                values: new object[,]
                {
                    { 1, "Duo" },
                    { 2, "Harmonic" }
                });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 5,
                columns: new[] { "AvailabilityID", "Entry1ID" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 246,
                columns: new[] { "AvailabilityID", "Entry1ID" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 297,
                columns: new[] { "AvailabilityID", "Entry1ID" },
                values: new object[] { 4, 2 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 520,
                columns: new[] { "AvailabilityID", "Entry1ID", "SpecialTypeID" },
                values: new object[] { 3, 10, 1 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 586,
                columns: new[] { "AvailabilityID", "Entry1ID" },
                values: new object[] { 2, 13 });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 701,
                columns: new[] { "AvailabilityID", "Entry1ID", "Entry2ID", "SpecialTypeID" },
                values: new object[] { 3, 4, 5, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Units_AvailabilityID",
                table: "Units",
                column: "AvailabilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Entry1ID",
                table: "Units",
                column: "Entry1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Entry2ID",
                table: "Units",
                column: "Entry2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Units_SpecialTypeID",
                table: "Units",
                column: "SpecialTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Availabilities_AvailabilityID",
                table: "Units",
                column: "AvailabilityID",
                principalTable: "Availabilities",
                principalColumn: "AvailabilityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Entries_Entry1ID",
                table: "Units",
                column: "Entry1ID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Entries_Entry2ID",
                table: "Units",
                column: "Entry2ID",
                principalTable: "Entries",
                principalColumn: "EntryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_SpecialTypes_SpecialTypeID",
                table: "Units",
                column: "SpecialTypeID",
                principalTable: "SpecialTypes",
                principalColumn: "SpecialTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Availabilities_AvailabilityID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Entries_Entry1ID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Entries_Entry2ID",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_SpecialTypes_SpecialTypeID",
                table: "Units");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "SpecialTypes");

            migrationBuilder.DropIndex(
                name: "IX_Units_AvailabilityID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_Entry1ID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_Entry2ID",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_SpecialTypeID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "AvailabilityID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Entry1ID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Entry2ID",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "SpecialTypeID",
                table: "Units");

            migrationBuilder.AddColumn<string>(
                name: "Availability",
                table: "Units",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Entry1",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Entry2",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialType",
                table: "Units",
                type: "nvarchar(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 5,
                columns: new[] { "Availability", "Entry1" },
                values: new object[] { "r", "Mystery" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 246,
                columns: new[] { "Availability", "Entry1" },
                values: new object[] { "r", "Geneology" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 297,
                columns: new[] { "Availability", "Entry1" },
                values: new object[] { "l", "Mystery" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 520,
                columns: new[] { "Availability", "Entry1", "SpecialType" },
                values: new object[] { "s", "Dawn", "d" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 586,
                columns: new[] { "Availability", "Entry1" },
                values: new object[] { "g", "Fates" });

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "UnitID",
                keyValue: 701,
                columns: new[] { "Availability", "Entry1", "Entry2", "SpecialType" },
                values: new object[] { "s", "Geneology", "Thracia", "h" });
        }
    }
}
