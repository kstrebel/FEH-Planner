using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FEH_Planner.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slot = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SP = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inheritable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Epithet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entry1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entry2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovementType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    WeaponType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialType = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Availability = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    LowestRarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    BuildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    WeaponID = table.Column<int>(type: "int", nullable: true),
                    A_SkillID = table.Column<int>(type: "int", nullable: true),
                    B_SkillID = table.Column<int>(type: "int", nullable: true),
                    C_SkillID = table.Column<int>(type: "int", nullable: true),
                    S_SkillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.BuildID);
                    table.ForeignKey(
                        name: "FK_Builds_Skills_A_SkillID",
                        column: x => x.A_SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Skills_B_SkillID",
                        column: x => x.B_SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Skills_C_SkillID",
                        column: x => x.C_SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Skills_S_SkillID",
                        column: x => x.S_SkillID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Skills_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillID", "Description", "Inheritable", "Name", "SP", "Slot" },
                values: new object[,]
                {
                    { 1, "Unit can counterattack regardless of foe's range.", true, "Distant Counter", 300, "a" },
                    { 2, "If unit is not adjacent to an ally, grants Atk/Def+7.", true, "Atk/Def Solo 4", 300, "a" },
                    { 3, "Grants HP+5, Atk/Spd/Def/Res+2. If unit is 5★, level 40, a Legendary Hero or a Mythic Hero, and unit's stats total less than 175, treats unit's stats as 175 in modes like Arena. If unit is 5★, level 40, not a Legendary Hero or Mythic Hero and unit's stats total less than 180, treats unit's stats as 180 in modes like Arena.", true, "R Duel Infantry 4", 300, "a" },
                    { 4, "If unit's HP ≤ 75% and unit initiates combat, unit can make a follow-up attack before foe can counterattack.", true, "Desperation 3", 300, "b" },
                    { 5, "At the start of turn 1, restores 99 HP and grants Special cooldown count-1.", false, "S Drink", 300, "b" },
                    { 6, "Allies within 2 spaces gain: \"If foe uses bow, dagger, magic, or staff, grants Def / Res + 4 during combat.\"", true, "Distant Guard", 240, "c" },
                    { 7, null, true, "Silver Sword", 300, "w" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitID", "Availability", "Entry1", "Entry2", "Epithet", "LowestRarity", "MovementType", "Name", "SpecialType", "WeaponType" },
                values: new object[,]
                {
                    { 5, "r", "Mystery", null, "Altean Prince", 3, "i", "Marth", null, "Red Sword" },
                    { 297, "l", "Mystery", null, "Legendary Dragon", 5, "a", "Tiki", null, "Blue Breath" },
                    { 246, "r", "Geneology", null, "Black Knight", 3, "c", "Ares", null, "Red Sword" },
                    { 701, "s", "Geneology", "Thracia", "Destined Scions", 5, "c", "Leif", "h", "Colorless Bow" },
                    { 520, "s", "Dawn", null, "Dawn Wind's Duo", 5, "f", "Micaiah", "d", "Colorless Tome" },
                    { 586, "g", "Fates", null, "Focused Ninja", 4, "i", "Hana", null, "Green Axe" }
                });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "BuildID", "A_SkillID", "B_SkillID", "C_SkillID", "LastModified", "Name", "S_SkillID", "UnitID", "WeaponID" },
                values: new object[] { 1, 3, 4, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "First", null, 5, 1 });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "BuildID", "A_SkillID", "B_SkillID", "C_SkillID", "LastModified", "Name", "S_SkillID", "UnitID", "WeaponID" },
                values: new object[] { 2, 4, 4, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second", null, 246, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Builds_A_SkillID",
                table: "Builds",
                column: "A_SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_B_SkillID",
                table: "Builds",
                column: "B_SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_C_SkillID",
                table: "Builds",
                column: "C_SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_S_SkillID",
                table: "Builds",
                column: "S_SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_UnitID",
                table: "Builds",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_WeaponID",
                table: "Builds",
                column: "WeaponID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
