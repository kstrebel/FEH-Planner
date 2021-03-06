using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]

namespace FEH_Planner.Models
{
    public class Build //for user to put skills on their units
    {
        //primary key (generated by DB)
        public int BuildID { get; set; }

        public DateTime LastModified { get; set; }

        [Required(ErrorMessage ="Please enter a build name.")]
        public string Name { get; set; }

        //foreign key
        [Range(1, 1000, ErrorMessage = "Please select a unit.")]
        public int UnitID { get; set; }
        [ForeignKey("UnitID")]
        [InverseProperty("BuildUnits")]
        public Unit Unit { get; set; }

        //[Required(ErrorMessage ="Please select a rarity.")]
        //public int Rarity { get; set; }
        //
        //[Required(ErrorMessage ="Please select a boon.")]
        //public char Boon { get; set; }
        //
        //[Required(ErrorMessage = "Please select a bane.")]
        //public char Bane { get; set; }
        //
        //[Required(ErrorMessage = "Please select a number of merges.")]
        //public int Merges { get; set; }
        //
        //[Required(ErrorMessage = "Please select a number of dragonflowers.")]
        //public int Dragonflowers { get; set; }
        //public bool SummonerSupport { get; set; }
        //public int AllySupportID { get; set; }

        //foreign keys
        public int? WeaponID { get; set; }
        [ForeignKey("WeaponID")]
        [InverseProperty("BuildWeapons")]
        public Skill Weapon { get; set; }

        public int? A_SkillID { get; set; }
        [ForeignKey("A_SkillID")]
        [InverseProperty("BuildA_Skills")]
        public Skill A_Skill { get; set; }

        public int? B_SkillID { get; set; }
        [ForeignKey("B_SkillID")]
        [InverseProperty("BuildB_Skills")]
        public Skill B_Skill { get; set; }

        public int? C_SkillID { get; set; }
        [ForeignKey("C_SkillID")]
        [InverseProperty("BuildC_Skills")]
        public Skill C_Skill { get; set; }

        public int? S_SkillID { get; set; }
        [InverseProperty("BuildS_Skills")]
        [ForeignKey("S_SkillID")]
        public Skill S_Skill { get; set; }
    }
}
