﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp304.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Address Address { get; set; }
    }
}
