﻿// <auto-generated />
using System;
using FEH_Planner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FEH_Planner.Migrations
{
    [DbContext(typeof(FEHPlannerContext))]
    [Migration("20220507141859_Move and Weapon type tables")]
    partial class MoveandWeapontypetables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FEH_Planner.Models.Build", b =>
                {
                    b.Property<int>("BuildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("A_SkillID")
                        .HasColumnType("int");

                    b.Property<int?>("B_SkillID")
                        .HasColumnType("int");

                    b.Property<int?>("C_SkillID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("S_SkillID")
                        .HasColumnType("int");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponID")
                        .HasColumnType("int");

                    b.HasKey("BuildID");

                    b.HasIndex("A_SkillID");

                    b.HasIndex("B_SkillID");

                    b.HasIndex("C_SkillID");

                    b.HasIndex("S_SkillID");

                    b.HasIndex("UnitID");

                    b.HasIndex("WeaponID");

                    b.ToTable("Builds");

                    b.HasData(
                        new
                        {
                            BuildID = 1,
                            A_SkillID = 3,
                            B_SkillID = 4,
                            C_SkillID = 6,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "First",
                            S_SkillID = 6,
                            UnitID = 5,
                            WeaponID = 7
                        },
                        new
                        {
                            BuildID = 2,
                            A_SkillID = 2,
                            B_SkillID = 4,
                            C_SkillID = 6,
                            LastModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Second",
                            UnitID = 246
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.MoveType", b =>
                {
                    b.Property<int>("MoveTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoveTypeID");

                    b.ToTable("MoveTypes");

                    b.HasData(
                        new
                        {
                            MoveTypeID = 1,
                            Name = "Infantry"
                        },
                        new
                        {
                            MoveTypeID = 2,
                            Name = "Armored"
                        },
                        new
                        {
                            MoveTypeID = 3,
                            Name = "Cavalry"
                        },
                        new
                        {
                            MoveTypeID = 4,
                            Name = "Flying"
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inheritable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SP")
                        .HasColumnType("int");

                    b.Property<int>("SlotID")
                        .HasColumnType("int");

                    b.HasKey("SkillID");

                    b.HasIndex("SlotID");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            SkillID = 1,
                            Description = "Unit can counterattack regardless of foe's range.",
                            Inheritable = true,
                            Name = "Distant Counter",
                            SP = 300,
                            SlotID = 4
                        },
                        new
                        {
                            SkillID = 2,
                            Description = "If unit is not adjacent to an ally, grants Atk/Def+7.",
                            Inheritable = true,
                            Name = "Atk/Def Solo 4",
                            SP = 300,
                            SlotID = 4
                        },
                        new
                        {
                            SkillID = 3,
                            Description = "Grants HP+5, Atk/Spd/Def/Res+2. If unit is 5★, level 40, a Legendary Hero or a Mythic Hero, and unit's stats total less than 175, treats unit's stats as 175 in modes like Arena. If unit is 5★, level 40, not a Legendary Hero or Mythic Hero and unit's stats total less than 180, treats unit's stats as 180 in modes like Arena.",
                            Inheritable = true,
                            Name = "R Duel Infantry 4",
                            SP = 300,
                            SlotID = 4
                        },
                        new
                        {
                            SkillID = 4,
                            Description = "If unit's HP ≤ 75% and unit initiates combat, unit can make a follow-up attack before foe can counterattack.",
                            Inheritable = true,
                            Name = "Desperation 3",
                            SP = 300,
                            SlotID = 5
                        },
                        new
                        {
                            SkillID = 5,
                            Description = "At the start of turn 1, restores 99 HP and grants Special cooldown count-1.",
                            Inheritable = false,
                            Name = "S Drink",
                            SP = 300,
                            SlotID = 5
                        },
                        new
                        {
                            SkillID = 6,
                            Description = "Allies within 2 spaces gain: \"If foe uses bow, dagger, magic, or staff, grants Def / Res + 4 during combat.\"",
                            Inheritable = true,
                            Name = "Distant Guard",
                            SP = 240,
                            SlotID = 6
                        },
                        new
                        {
                            SkillID = 7,
                            Inheritable = true,
                            Name = "Silver Sword",
                            SP = 300,
                            SlotID = 1
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.Slot", b =>
                {
                    b.Property<int>("SlotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SlotID");

                    b.ToTable("Slots");

                    b.HasData(
                        new
                        {
                            SlotID = 1,
                            Name = "Weapon"
                        },
                        new
                        {
                            SlotID = 2,
                            Name = "Assist"
                        },
                        new
                        {
                            SlotID = 3,
                            Name = "Special"
                        },
                        new
                        {
                            SlotID = 4,
                            Name = "A Skill"
                        },
                        new
                        {
                            SlotID = 5,
                            Name = "B Skill"
                        },
                        new
                        {
                            SlotID = 6,
                            Name = "C Skill"
                        },
                        new
                        {
                            SlotID = 7,
                            Name = "S Skill"
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.Unit", b =>
                {
                    b.Property<int>("UnitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Entry1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entry2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epithet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LowestRarity")
                        .HasColumnType("int");

                    b.Property<int>("MoveTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecialType")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("WeaponTypeID")
                        .HasColumnType("int");

                    b.HasKey("UnitID");

                    b.HasIndex("MoveTypeID");

                    b.HasIndex("WeaponTypeID");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            UnitID = 5,
                            Availability = "r",
                            Entry1 = "Mystery",
                            Epithet = "Altean Prince",
                            LowestRarity = 3,
                            MoveTypeID = 1,
                            Name = "Marth",
                            WeaponTypeID = 1
                        },
                        new
                        {
                            UnitID = 297,
                            Availability = "l",
                            Entry1 = "Mystery",
                            Epithet = "Legendary Dragon",
                            LowestRarity = 5,
                            MoveTypeID = 2,
                            Name = "Tiki",
                            WeaponTypeID = 17
                        },
                        new
                        {
                            UnitID = 246,
                            Availability = "r",
                            Entry1 = "Geneology",
                            Epithet = "Black Knight",
                            LowestRarity = 3,
                            MoveTypeID = 3,
                            Name = "Ares",
                            WeaponTypeID = 1
                        },
                        new
                        {
                            UnitID = 701,
                            Availability = "s",
                            Entry1 = "Geneology",
                            Entry2 = "Thracia",
                            Epithet = "Destined Scions",
                            LowestRarity = 5,
                            MoveTypeID = 3,
                            Name = "Leif",
                            SpecialType = "h",
                            WeaponTypeID = 11
                        },
                        new
                        {
                            UnitID = 520,
                            Availability = "s",
                            Entry1 = "Dawn",
                            Epithet = "Dawn Wind's Duo",
                            LowestRarity = 5,
                            MoveTypeID = 4,
                            Name = "Micaiah",
                            SpecialType = "d",
                            WeaponTypeID = 7
                        },
                        new
                        {
                            UnitID = 586,
                            Availability = "g",
                            Entry1 = "Fates",
                            Epithet = "Focused Ninja",
                            LowestRarity = 4,
                            MoveTypeID = 1,
                            Name = "Hana",
                            WeaponTypeID = 3
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.WeaponType", b =>
                {
                    b.Property<int>("WeaponTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weapon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponTypeID");

                    b.ToTable("WeaponTypes");

                    b.HasData(
                        new
                        {
                            WeaponTypeID = 1,
                            Color = "Red",
                            Weapon = "Sword"
                        },
                        new
                        {
                            WeaponTypeID = 2,
                            Color = "Blue",
                            Weapon = "Lance"
                        },
                        new
                        {
                            WeaponTypeID = 3,
                            Color = "Green",
                            Weapon = "Axe"
                        },
                        new
                        {
                            WeaponTypeID = 4,
                            Color = "Red",
                            Weapon = "Tome"
                        },
                        new
                        {
                            WeaponTypeID = 5,
                            Color = "Blue",
                            Weapon = "Tome"
                        },
                        new
                        {
                            WeaponTypeID = 6,
                            Color = "Green",
                            Weapon = "Tome"
                        },
                        new
                        {
                            WeaponTypeID = 7,
                            Color = "Colorless",
                            Weapon = "Tome"
                        },
                        new
                        {
                            WeaponTypeID = 8,
                            Color = "Red",
                            Weapon = "Bow"
                        },
                        new
                        {
                            WeaponTypeID = 9,
                            Color = "Blue",
                            Weapon = "Bow"
                        },
                        new
                        {
                            WeaponTypeID = 10,
                            Color = "Green",
                            Weapon = "Bow"
                        },
                        new
                        {
                            WeaponTypeID = 11,
                            Color = "Colorless",
                            Weapon = "Bow"
                        },
                        new
                        {
                            WeaponTypeID = 12,
                            Color = "Red",
                            Weapon = "Dagger"
                        },
                        new
                        {
                            WeaponTypeID = 13,
                            Color = "Blue",
                            Weapon = "Dagger"
                        },
                        new
                        {
                            WeaponTypeID = 14,
                            Color = "Green",
                            Weapon = "Dagger"
                        },
                        new
                        {
                            WeaponTypeID = 15,
                            Color = "Colorless",
                            Weapon = "Dagger"
                        },
                        new
                        {
                            WeaponTypeID = 16,
                            Color = "Red",
                            Weapon = "Breath"
                        },
                        new
                        {
                            WeaponTypeID = 17,
                            Color = "Blue",
                            Weapon = "Breath"
                        },
                        new
                        {
                            WeaponTypeID = 18,
                            Color = "Green",
                            Weapon = "Breath"
                        },
                        new
                        {
                            WeaponTypeID = 19,
                            Color = "Colorless",
                            Weapon = "Breath"
                        },
                        new
                        {
                            WeaponTypeID = 20,
                            Color = "Red",
                            Weapon = "Beast"
                        },
                        new
                        {
                            WeaponTypeID = 21,
                            Color = "Blue",
                            Weapon = "Beast"
                        },
                        new
                        {
                            WeaponTypeID = 22,
                            Color = "Green",
                            Weapon = "Beast"
                        },
                        new
                        {
                            WeaponTypeID = 23,
                            Color = "Colorless",
                            Weapon = "Beast"
                        },
                        new
                        {
                            WeaponTypeID = 24,
                            Color = "Colorless",
                            Weapon = "Staff"
                        });
                });

            modelBuilder.Entity("FEH_Planner.Models.Build", b =>
                {
                    b.HasOne("FEH_Planner.Models.Skill", "A_Skill")
                        .WithMany("BuildA_Skills")
                        .HasForeignKey("A_SkillID");

                    b.HasOne("FEH_Planner.Models.Skill", "B_Skill")
                        .WithMany("BuildB_Skills")
                        .HasForeignKey("B_SkillID");

                    b.HasOne("FEH_Planner.Models.Skill", "C_Skill")
                        .WithMany("BuildC_Skills")
                        .HasForeignKey("C_SkillID");

                    b.HasOne("FEH_Planner.Models.Skill", "S_Skill")
                        .WithMany("BuildS_Skills")
                        .HasForeignKey("S_SkillID");

                    b.HasOne("FEH_Planner.Models.Unit", "Unit")
                        .WithMany("BuildUnits")
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FEH_Planner.Models.Skill", "Weapon")
                        .WithMany("BuildWeapons")
                        .HasForeignKey("WeaponID");

                    b.Navigation("A_Skill");

                    b.Navigation("B_Skill");

                    b.Navigation("C_Skill");

                    b.Navigation("S_Skill");

                    b.Navigation("Unit");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("FEH_Planner.Models.Skill", b =>
                {
                    b.HasOne("FEH_Planner.Models.Slot", "Slot")
                        .WithMany("SkillSlots")
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("FEH_Planner.Models.Unit", b =>
                {
                    b.HasOne("FEH_Planner.Models.MoveType", "MoveType")
                        .WithMany("UnitMoveTypes")
                        .HasForeignKey("MoveTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FEH_Planner.Models.WeaponType", "WeaponType")
                        .WithMany("UnitWeaponTypes")
                        .HasForeignKey("WeaponTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MoveType");

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("FEH_Planner.Models.MoveType", b =>
                {
                    b.Navigation("UnitMoveTypes");
                });

            modelBuilder.Entity("FEH_Planner.Models.Skill", b =>
                {
                    b.Navigation("BuildA_Skills");

                    b.Navigation("BuildB_Skills");

                    b.Navigation("BuildC_Skills");

                    b.Navigation("BuildS_Skills");

                    b.Navigation("BuildWeapons");
                });

            modelBuilder.Entity("FEH_Planner.Models.Slot", b =>
                {
                    b.Navigation("SkillSlots");
                });

            modelBuilder.Entity("FEH_Planner.Models.Unit", b =>
                {
                    b.Navigation("BuildUnits");
                });

            modelBuilder.Entity("FEH_Planner.Models.WeaponType", b =>
                {
                    b.Navigation("UnitWeaponTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
