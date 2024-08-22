using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.DTO
{
    public class SalesDto
    {
        public string? DrugName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public DateTime ManufacturedDate{get;set;}
        public DateTime ExpiryDate { get; set; }
    }
}