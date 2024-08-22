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
    public class DrugRequest
    {
        [Key]
        public int RequestId{get;set;}
        public int UserId{get;set;}
        public string? DrugName{get;set;}
        public string? Discription{get;set;}

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity{get;set;}

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public decimal ApproxPrice{get;set;}
        [DataType(DataType.Date)]
        public DateTime RequestedDate{get;set;}
        public bool Approved{get;set;}

        public User? UserDetails{get;set;}
    }
}