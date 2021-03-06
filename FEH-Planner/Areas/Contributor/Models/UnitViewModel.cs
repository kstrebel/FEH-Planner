using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FEH_Planner.Models;

namespace FEH_Planner.Areas.Contributor.Models
{
    public class UnitViewModel
    {
        public Unit Unit { get; set; }

        public List<Entry> Entries { get; set; }
        public List<MoveType> MoveTypes { get; set; }
        public List<WeaponType> WeaponTypes { get; set; }
        public List<SpecialType> SpecialTypes { get; set; }
        public List<Availability> Availabilities { get; set; }
    }
}
