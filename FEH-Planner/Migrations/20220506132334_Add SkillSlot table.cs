using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class AddSkillSlottable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SlotID",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    SlotID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.SlotID);
                });

            migrationBuilder.InsertData(
                table: "Slot",
                columns: new[] { "SlotID", "Name" },
                values: new object[,]
                {
                    { 1, "Weapon" },
                    { 2, "Assist" },
                    { 3, "Special" },
                    { 4, "A Skill" },
                    { 5, "B Skill" },
                    { 6, "C Skill" },
                    { 7, "S Skill" }
                });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 1,
                column: "SlotID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 2,
                column: "SlotID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 3,
                column: "SlotID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 4,
                column: "SlotID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 5,
                column: "SlotID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 6,
                column: "SlotID",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 7,
                column: "SlotID",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SlotID",
                table: "Skills",
                column: "SlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Slot_SlotID",
                table: "Skills",
                column: "SlotID",
                principalTable: "Slot",
                principalColumn: "SlotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Slot_SlotID",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SlotID",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SlotID",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "Slot",
                table: "Skills",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 1,
                column: "Slot",
                value: "a");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 2,
                column: "Slot",
                value: "a");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 3,
                column: "Slot",
                value: "a");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 4,
                column: "Slot",
                value: "b");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 5,
                column: "Slot",
                value: "b");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 6,
                column: "Slot",
                value: "c");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "SkillID",
                keyValue: 7,
                column: "Slot",
                value: "w");
        }
    }
}
