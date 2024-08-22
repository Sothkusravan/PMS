using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.DTO
{
    public class SuppliersInventoryDto
    {
        public int SupplierId{get;set;}
        public string? DrugName{get;set;}

        public double Price{get;set;}

        public long Quantity{get;set;}

        public DateTime ManufacturedDate{get;set;}

        public DateTime ExpiryDate { get; set; }

    }
}