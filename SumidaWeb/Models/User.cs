﻿using System.ComponentModel;

namespace SumidaWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("User名")]
        public string UserName { get; set; }
    }
}