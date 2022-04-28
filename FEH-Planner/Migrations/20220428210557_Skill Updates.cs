using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class SkillUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "BuildID",
                keyValue: 1,
                columns: new[] { "S_SkillID", "WeaponID" },
                values: new object[] { 6, 7 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "BuildID",
                keyValue: 2,
                columns: new[] { "A_SkillID", "WeaponID" },
                values: new object[] { 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "BuildID",
                keyValue: 1,
                columns: new[] { "S_SkillID", "WeaponID" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "BuildID",
                keyValue: 2,
                columns: new[] { "A_SkillID", "WeaponID" },
                values: new object[] { 4, 7 });
        }
    }
}
