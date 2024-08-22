using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pharma.Model
{
    public class Login
    {
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? UserPassword { get; set; }

        
    }
}