using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pharma.Model
{
    public class User
    {
        [Key]
        // [JsonIgnore]
        public int UserId{get;set;}


        [Required]
        public string? UserName{get;set;}
        
        public string? Contact{get;set;}

        public string? UserAddress{get;set;}

        [Required]
        public string? Role{get;set;}

        [EmailAddress]
        public string? Email{get;set;}

        [PasswordPropertyText]
        
        public string? UserPassword{get;set;}

        public bool Approval{get;set;}

        
    }
}