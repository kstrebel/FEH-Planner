using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]
using System.Collections.Generic; //for ICollection

namespace FEH_Planner.Models
{
    public class Unit
    {
        //primary key
        public int UnitID { get; set; }
        public string Name { get; set; }
        public string Epithet { get; set; }
        public string Entry1 { get; set; }
        public string? Entry2 { get; set; }

        [Range(1, 4, ErrorMessage ="Plese select a movement type.")]
        public int MoveTypeID { get; set; }
        [ForeignKey("MoveTypeID")]
        [InverseProperty("UnitMoveTypes")]
        public MoveType MoveType { get; set; }

        [Range(1, 24, ErrorMessage ="Plese select a weapon type.")]
        public int WeaponTypeID { get; set; }
        [ForeignKey("WeaponTypeID")]
        [InverseProperty("UnitWeaponTypes")]
        public WeaponType WeaponType { get; set; }

        public char? SpecialType { get; set; }
        public char Availability { get; set; }
        public int LowestRarity { get; set; }

        //for foreign key in build
        public virtual ICollection<Build> BuildUnits { get; set; }
    }
}
