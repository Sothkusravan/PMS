using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pharma.Model
{
    public class SuppliersInventory
    {
        [Key]
        public int SuplDrugId{get;set;}

        public int SupplierId{get;set;}
        public string? DrugName{get;set;}

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price{get;set;}

        [Range(0.01, long.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public long Quantity{get;set;}

        [DataType(DataType.Date)]
        public DateTime ManufacturedDate{get;set;}

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("SupplierId")]
        [JsonIgnore] 
        public Suppliers? suppliers { get; set; }

    }
}