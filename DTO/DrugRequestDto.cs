using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.DTO
{
    public class DrugRequestDto
    {
        public int UserId{get;set;}
        public string? DrugName{get;set;}
        public string? Discription{get;set;}
        public int Quantity{get;set;}
        public decimal ApproxPrice{get;set;}
        public DateTime RequestedDate{get;set;}
        public bool Approved{get;set;}
    }
}