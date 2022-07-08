using System;
using Microsoft.EntityFrameworkCore;

namespace FEH_Planner.Models
{
    public class FEHPlannerContext : DbContext
    {
        //override base constuctor and pass in any options
        public FEHPlannerContext(DbContextOptions<FEHPlannerContext> options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<MoveType> MoveTypes { get; set; }
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<SpecialType> SpecialTypes { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Slot> Slots { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Build> Builds { get; set; }

        //gets called when DB model is first created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().HasData(
                new Entry { EntryID = 1, Name = "Heroes" },
                new Entry { EntryID = 2, Name = "Mystery/Shadow Dragon" },
                new Entry { EntryID = 3, Name = "Valentia" },
                new Entry { EntryID = 4, Name = "Geneology" },
                new Entry { EntryID = 5, Name = "Thracia 776" },
                new Entry { EntryID = 6, Name = "Binding Blade" },
                new Entry { EntryID = 7, Name = "Blazing Blade" },
                new Entry { EntryID = 8, Name = "Sacred Stones" },
                new Entry { EntryID = 9, Name = "Path of Radiance" },
                new Entry { EntryID = 10, Name = "Radiant Dawn" },
                new Entry { EntryID = 12, Name = "Awakening" },
                new Entry { EntryID = 13, Name = "Fates" },
                new Entry { EntryID = 14, Name = "Three Houses" },
                new Entry { EntryID = 15, Name = "Tokyo Mirage Sessions" }
                );

            modelBuilder.Entity<MoveType>().HasData(
                new MoveType { MoveTypeID = 1, Name = "Infantry" },
                new MoveType { MoveTypeID = 2, Name = "Armored" },
                new MoveType { MoveTypeID = 3, Name = "Cavalry" },
                new MoveType { MoveTypeID = 4, Name = "Flying" }
                );

            modelBuilder.Entity<WeaponType>().HasData(
                new WeaponType { WeaponTypeID = 1, Color = "Red", Weapon = "Sword" },
                new WeaponType { WeaponTypeID = 2, Color = "Blue", Weapon = "Lance" },
                new WeaponType { WeaponTypeID = 3, Color = "Green", Weapon = "Axe" },
                new WeaponType { WeaponTypeID = 4, Color = "Red", Weapon = "Tome" },
                new WeaponType { WeaponTypeID = 5, Color = "Blue", Weapon = "Tome" },
                new WeaponType { WeaponTypeID = 6, Color = "Green", Weapon = "Tome" },
                new WeaponType { WeaponTypeID = 7, Color = "Colorless", Weapon = "Tome" },
                new WeaponType { WeaponTypeID = 8, Color = "Red", Weapon = "Bow" },
                new WeaponType { WeaponTypeID = 9, Color = "Blue", Weapon = "Bow" },
                new WeaponType { WeaponTypeID = 10, Color = "Green", Weapon = "Bow" },
                new WeaponType { WeaponTypeID = 11, Color = "Colorless", Weapon = "Bow" },
                new WeaponType { WeaponTypeID = 12, Color = "Red", Weapon = "Dagger" },
                new WeaponType { WeaponTypeID = 13, Color = "Blue", Weapon = "Dagger" },
                new WeaponType { WeaponTypeID = 14, Color = "Green", Weapon = "Dagger" },
                new WeaponType { WeaponTypeID = 15, Color = "Colorless", Weapon = "Dagger" },
                new WeaponType { WeaponTypeID = 16, Color = "Red", Weapon = "Breath" },
                new WeaponType { WeaponTypeID = 17, Color = "Blue", Weapon = "Breath" },
                new WeaponType { WeaponTypeID = 18, Color = "Green", Weapon = "Breath" },
                new WeaponType { WeaponTypeID = 19, Color = "Colorless", Weapon = "Breath" },
                new WeaponType { WeaponTypeID = 20, Color = "Red", Weapon = "Beast" },
                new WeaponType { WeaponTypeID = 21, Color = "Blue", Weapon = "Beast" },
                new WeaponType { WeaponTypeID = 22, Color = "Green", Weapon = "Beast" },
                new WeaponType { WeaponTypeID = 23, Color = "Colorless", Weapon = "Beast" },
                new WeaponType { WeaponTypeID = 24, Color = "Colorless", Weapon = "Staff" }
                );

            modelBuilder.Entity<SpecialType>().HasData(
                new SpecialType { SpecialTypeID = 1, Name = "Duo" },
                new SpecialType { SpecialTypeID = 2, Name = "Harmonic" }
                );

            modelBuilder.Entity<Availability>().HasData(
                new Availability { AvailabilityID = 1, Name = "Regular" },
                new Availability { AvailabilityID = 2, Name = "Grail" },
                new Availability { AvailabilityID = 3, Name = "Seasonal" },
                new Availability { AvailabilityID = 4, Name = "Legendary/Mythic" }
                );

            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitID = 5, Name = "Marth", Epithet = "Altean Prince", Entry1ID = 2, MoveTypeID = 1, WeaponTypeID = 1, AvailabilityID = 1, LowestRarity = 3 },
                new Unit { UnitID = 297, Name = "Tiki", Epithet = "Legendary Dragon", Entry1ID = 2, MoveTypeID = 2, WeaponTypeID = 17, AvailabilityID = 4, LowestRarity = 5 },
                new Unit { UnitID = 246, Name = "Ares", Epithet = "Black Knight", Entry1ID = 4, MoveTypeID = 3, WeaponTypeID = 1, AvailabilityID = 1, LowestRarity = 3 },
                new Unit { UnitID = 701, Name = "Leif", Epithet = "Destined Scions", Entry1ID = 4, Entry2ID = 5, MoveTypeID = 3, WeaponTypeID = 11, SpecialTypeID = 2, AvailabilityID = 3, LowestRarity = 5 },
                new Unit { UnitID = 520, Name = "Micaiah", Epithet = "Dawn Wind's Duo", Entry1ID = 10, MoveTypeID = 4, WeaponTypeID = 7, SpecialTypeID = 1, AvailabilityID = 3, LowestRarity = 5 },
                new Unit { UnitID = 586, Name = "Hana", Epithet = "Focused Ninja", Entry1ID = 13, MoveTypeID = 1, WeaponTypeID = 3, AvailabilityID = 2, LowestRarity = 4 }
                );

            modelBuilder.Entity<Slot>().HasData(
                new Slot { SlotID = 1, Name = "Weapon" },
                new Slot { SlotID = 2, Name = "Assist" },
                new Slot { SlotID = 3, Name = "Special" },
                new Slot { SlotID = 4, Name = "A Skill" },
                new Slot { SlotID = 5, Name = "B Skill" },
                new Slot { SlotID = 6, Name = "C Skill" },
                new Slot { SlotID = 7, Name = "S Skill" }
                );

            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillID = 1, Name = "Distant Counter", SlotID = 4, SP = 300, Description = "Unit can counterattack regardless of foe's range.", Inheritable = true },
                new Skill { SkillID = 2, Name = "Atk/Def Solo 4", SlotID = 4, SP = 300, Description = "If unit is not adjacent to an ally, grants Atk/Def+7.", Inheritable = true },
                new Skill { SkillID = 3, Name = "R Duel Infantry 4", SlotID = 4, SP = 300, Description = "Grants HP+5, Atk/Spd/Def/Res+2. If unit is 5★, level 40, a Legendary Hero or a Mythic Hero, and unit's stats total less than 175, treats unit's stats as 175 in modes like Arena. If unit is 5★, level 40, not a Legendary Hero or Mythic Hero and unit's stats total less than 180, treats unit's stats as 180 in modes like Arena.", Inheritable = true },
                new Skill { SkillID = 4, Name = "Desperation 3", SlotID = 5, SP = 300, Description = "If unit's HP ≤ 75% and unit initiates combat, unit can make a follow-up attack before foe can counterattack.", Inheritable = true },
                new Skill { SkillID = 5, Name = "S Drink", SlotID = 5, SP = 300, Description = "At the start of turn 1, restores 99 HP and grants Special cooldown count-1.", Inheritable = false },
                new Skill { SkillID = 6, Name = "Distant Guard", SlotID = 6, SP = 240, Description = "Allies within 2 spaces gain: \"If foe uses bow, dagger, magic, or staff, grants Def / Res + 4 during combat.\"", Inheritable = true },
                new Skill { SkillID = 7, Name = "Silver Sword", SlotID = 1, SP = 300, Inheritable = true }
                );

            modelBuilder.Entity<Build>().HasData(
                new Build { BuildID = 1, Name = "First", UnitID = 5, WeaponID = 7, A_SkillID = 3, B_SkillID = 4, C_SkillID = 6, S_SkillID = 6 },
                new Build { BuildID = 2, Name = "Second", UnitID = 246, A_SkillID = 2, B_SkillID = 4, C_SkillID = 6 }
                );
        }
    }
}
