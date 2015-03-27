using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SumidaWeb.Models
{
    public class Sex
    {
        public int Id { get; set; }

        [DisplayName("性別")]
        public string Kind { get; set; }
    }
}