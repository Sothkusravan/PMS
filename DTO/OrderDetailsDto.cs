using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.DTO
{
    public class OrderDetailsDto
    {
        public int UserId { get; set; }
                
        public string? DrugName { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public DateTime OrderedDate { get; set; }

        public bool PickUpStatus { get; set; }
    }
}