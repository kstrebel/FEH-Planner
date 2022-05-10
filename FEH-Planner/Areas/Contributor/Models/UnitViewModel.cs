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

        public List<MoveType> MoveTypes { get; set; }
        public List<WeaponType> WeaponTypes { get; set; }
    }
}
