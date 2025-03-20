﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzeSome.Data.Models.Dtos
{
    public class ContractDto
    {
        public int Id { get; set; }
        // Customer Data
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        // Order Data
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string ContractStatus { get; set; } = null!;
        // Product Data
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
    }
}
