﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchExample.Models
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
