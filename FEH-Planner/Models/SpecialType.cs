using System;
using System.Collections.Generic;

namespace FEH_Planner.Models
{
    public class SpecialType
    {
        public int SpecialTypeID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Unit> UnitSpecialTypes { get; set; }
    }
}
