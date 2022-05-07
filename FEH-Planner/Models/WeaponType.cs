using System;
using System.Collections.Generic; //for ICollection

namespace FEH_Planner.Models
{
    public class WeaponType
    {
        public int WeaponTypeID { get; set; }
        public string Color { get; set; }
        public string Weapon { get; set; }

        //foreign key in Unit
        public virtual ICollection<Unit> UnitWeaponTypes { get; set; }
    }
}
