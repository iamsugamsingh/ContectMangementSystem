using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContectMangementSystem.Models 
{
    public class ContactModel
    {
        [Key]
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public bool IsFav { get; set; }
    }
}
