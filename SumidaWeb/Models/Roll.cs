﻿using System.Collections.Generic;
using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class Roll
    {
        public int Id { get; set; }

        [DisplayName("役割")]
        public string RollName { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}