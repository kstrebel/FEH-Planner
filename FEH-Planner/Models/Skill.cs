﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //for [ForeignKey]
using System.Collections.Generic; //for ICollection
using Newtonsoft.Json; //to ignore when building session JSON

namespace FEH_Planner.Models
{
    public class Skill
    {
        //primary key (generated by DB)
        public int SkillID { get; set; }

        public string Name { get; set; }

        //foreign key
        [Range(1, 7, ErrorMessage = "Please select a slot.")]
        public int SlotID { get; set; }
        [ForeignKey("SlotID")]
        [InverseProperty("SkillSlots")]
        public Slot Slot { get; set; }

        public int SP { get; set; }
        public string Description { get; set; }
        public bool Inheritable{ get; set; }

        //for foreign keys in Build
        [JsonIgnore]
        public virtual ICollection<Build> BuildWeapons { get; set; }
        [JsonIgnore]
        public virtual ICollection<Build> BuildA_Skills { get; set; }
        [JsonIgnore]
        public virtual ICollection<Build> BuildB_Skills { get; set; }
        [JsonIgnore]
        public virtual ICollection<Build> BuildC_Skills { get; set; }
        [JsonIgnore]
        public virtual ICollection<Build> BuildS_Skills { get; set; }
    }
}
