using System;
using System.ComponentModel.DataAnnotations;
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
        public char MovementType { get; set; }
        public string WeaponType { get; set; }
        public char? SpecialType { get; set; }
        public char Availability { get; set; }
        public int LowestRarity { get; set; }

        //for foreign key in build
        public virtual ICollection<Build> BuildUnits { get; set; }
    }
}
