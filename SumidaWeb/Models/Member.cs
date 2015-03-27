using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SumidaWeb.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Sex SexId { get; set; }
        public string Email { get; set; }
        public DateTime Birty { get; set; }
        public bool Married { get; set; }
        public string Memo { get; set; }
    }
}