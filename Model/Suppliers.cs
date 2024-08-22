using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pharma.Model
{
    public class Suppliers
    {
        [Key]
        // [JsonIgnore]
        public int SupplierId{get;set;}

        public string? SupplierName{get;set;}

        public string? Organisation{get;set;}


        public string? Contact{get;set;}

        [EmailAddress]
        public string? EmailAddress{get;set;}

        public string? Address{get;set;}

        [JsonIgnore]
        public ICollection<DrugDetails>? DrugDetails { get; set; }
        

    }
}