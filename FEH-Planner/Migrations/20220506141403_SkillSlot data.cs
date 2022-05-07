using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class SkillSlotdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Slot_SlotID",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slot",
                table: "Slot");

            migrationBuilder.RenameTable(
                name: "Slot",
                newName: "Slots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slots",
                table: "Slots",
                column: "SlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Slots_SlotID",
                table: "Skills",
                column: "SlotID",
                principalTable: "Slots",
                principalColumn: "SlotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Slots_SlotID",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Slots",
                table: "Slots");

            migrationBuilder.RenameTable(
                name: "Slots",
                newName: "Slot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Slot",
                table: "Slot",
                column: "SlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Slot_SlotID",
                table: "Skills",
                column: "SlotID",
                principalTable: "Slot",
                principalColumn: "SlotID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
