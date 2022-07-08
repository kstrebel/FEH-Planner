using System;
using System.Collections.Generic;

namespace FEH_Planner.Models
{
    public class Entry
    {
        public int EntryID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Unit> UnitEntry1s { get; set; }
        public virtual ICollection<Unit> UnitEntry2s { get; set; }
    }
}
