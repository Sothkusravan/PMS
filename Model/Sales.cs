using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pharma.Model
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }

        public string? DrugName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ManufacturedDate{get;set;}
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public DateTime SalesDate{get;set;}
    }
}