using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pharma.Model
{
     public class OrderDetails
    {
        [Key]
        // [JsonIgnore]
        public int OrderId { get; set; }

        public int UserId { get; set; }
                
        public string? DrugName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public decimal PricePerUnit { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public decimal TotalPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderedDate { get; set; }

        public bool PickUpStatus { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore] 
        public User? User { get; set; }

       
        

    }
}