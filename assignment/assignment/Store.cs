﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class Store
    {
        public string StoreCode { get; set; }
        public string StoreLocation { get; set; }
    }
    public class Date
    {
        public int week { get; set; }
        public int year { get; set; }
    }
    public class Order
    {
        public Store Store { get; set; }

        public Date Date { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public double Cost { get; set; }
    }
}
