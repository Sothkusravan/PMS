using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.DTO
{
    public class DrugDetailsDto
    {
        public int SupplierId { get; set; }

        public string? DrugName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        public DateTime ManufacturedDate{get;set;}
        public DateTime ExpiryDate { get; set; }
    }
}