using System;
using System.Collections.Generic;

namespace FEH_Planner.Models
{
    public class Availability
    {
        public int AvailabilityID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Unit> UnitAvailabilities { get; set; }
    }
}