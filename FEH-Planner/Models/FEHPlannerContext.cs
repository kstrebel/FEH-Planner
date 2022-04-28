using System;
using Microsoft.EntityFrameworkCore;

namespace FEH_Planner.Models
{
    public class FEHPlannerContext:DbContext
    {
        //override base constuctor and pass in any options
        public FEHPlannerContext(DbContextOptions<FEHPlannerContext> options) : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Build> Builds { get; set; }

        //gets called when DB model is first created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                new Unit { UnitID = 5, Name = "Marth", Epithet = "Altean Prince", Entry1 = "Mystery", MovementType = 'i', WeaponType = "Red Sword", Availability = 'r', LowestRarity = 3 },
                new Unit { UnitID = 297, Name = "Tiki", Epithet = "Legendary Dragon", Entry1 = "Mystery", MovementType = 'a', WeaponType = "Blue Breath", Availability = 'l', LowestRarity = 5 },
                new Unit { UnitID = 246, Name = "Ares", Epithet = "Black Knight", Entry1 = "Geneology", MovementType = 'c', WeaponType = "Red Sword", Availability = 'r', LowestRarity = 3 },
                new Unit { UnitID = 701, Name = "Leif", Epithet = "Destined Scions", Entry1 = "Geneology", Entry2 = "Thracia", MovementType = 'c', WeaponType = "Colorless Bow", SpecialType = 'h', Availability = 's', LowestRarity = 5 },
                new Unit { UnitID = 520, Name = "Micaiah", Epithet = "Dawn Wind's Duo", Entry1 = "Dawn", MovementType = 'f', WeaponType = "Colorless Tome", SpecialType = 'd', Availability = 's', LowestRarity = 5 },
                new Unit { UnitID = 586, Name = "Hana", Epithet = "Focused Ninja", Entry1 = "Fates", MovementType = 'i', WeaponType = "Green Axe", Availability = 'g', LowestRarity = 4 }
                );

            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillID = 1, Name = "Distant Counter", Slot = 'a', SP = 300, Description = "Unit can counterattack regardless of foe's range.", Inheritable = true },
                new Skill { SkillID = 2, Name = "Atk/Def Solo 4", Slot = 'a', SP = 300, Description = "If unit is not adjacent to an ally, grants Atk/Def+7.", Inheritable = true },
                new Skill { SkillID = 3, Name = "R Duel Infantry 4", Slot = 'a', SP = 300, Description = "Grants HP+5, Atk/Spd/Def/Res+2. If unit is 5★, level 40, a Legendary Hero or a Mythic Hero, and unit's stats total less than 175, treats unit's stats as 175 in modes like Arena. If unit is 5★, level 40, not a Legendary Hero or Mythic Hero and unit's stats total less than 180, treats unit's stats as 180 in modes like Arena.", Inheritable = true },
                new Skill { SkillID = 4, Name = "Desperation 3", Slot = 'b', SP = 300, Description = "If unit's HP ≤ 75% and unit initiates combat, unit can make a follow-up attack before foe can counterattack.", Inheritable = true },
                new Skill { SkillID = 5, Name = "S Drink", Slot = 'b', SP = 300, Description = "At the start of turn 1, restores 99 HP and grants Special cooldown count-1.", Inheritable = false },
                new Skill { SkillID = 6, Name = "Distant Guard", Slot = 'c', SP = 240, Description = "Allies within 2 spaces gain: \"If foe uses bow, dagger, magic, or staff, grants Def / Res + 4 during combat.\"", Inheritable = true },
                new Skill { SkillID = 7, Name = "Silver Sword", Slot = 'w', SP = 300, Inheritable = true }
                );

            modelBuilder.Entity<Build>().HasData(
                new Build { BuildID = 1, Name = "First", UnitID = 5, WeaponID = 7, A_SkillID = 3, B_SkillID = 4, C_SkillID = 6, S_SkillID = 6 },
                new Build { BuildID = 2, Name = "Second", UnitID = 246, A_SkillID = 2, B_SkillID = 4, C_SkillID = 6 }
                );
        }
    }
}
