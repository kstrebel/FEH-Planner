using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]
using System.Collections.Generic; //for ICollection
using Newtonsoft.Json; //to ignore when building session JSON

namespace FEH_Planner.Models
{
    public class Unit
    {
        //primary key
        public int UnitID { get; set; }
        public string Name { get; set; }
        public string Epithet { get; set; }

        public int Entry1ID { get; set; }
        [ForeignKey("Entry1ID")]
        [InverseProperty("UnitEntry1s")]
        public Entry Entry1 { get; set; }

        public int? Entry2ID { get; set; }
        [ForeignKey("Entry2ID")]
        [InverseProperty("UnitEntry2s")]
        public Entry Entry2 { get; set; }

        [Range(1, 4, ErrorMessage = "Plese select a movement type.")]
        public int MoveTypeID { get; set; }
        [ForeignKey("MoveTypeID")]
        [InverseProperty("UnitMoveTypes")]
        public MoveType MoveType { get; set; }

        [Range(1, 24, ErrorMessage = "Plese select a weapon type.")]
        public int WeaponTypeID { get; set; }
        [ForeignKey("WeaponTypeID")]
        [InverseProperty("UnitWeaponTypes")]
        public WeaponType WeaponType { get; set; }

        public int? SpecialTypeID { get; set; }
        [ForeignKey("SpecialTypeID")]
        [InverseProperty("UnitSpecialTypes")]
        public SpecialType SpecialType { get; set; }

        [Range(1, 4, ErrorMessage = "Please select an availability.")]
        public int AvailabilityID { get; set; }
        [ForeignKey("AvailabilityID")]
        [InverseProperty("UnitAvailabilities")]
        public Availability Availability { get; set; }

        public int LowestRarity { get; set; }

        //for foreign key in build
        [JsonIgnore]
        public virtual ICollection<Build> BuildUnits { get; set; }
    }
}
