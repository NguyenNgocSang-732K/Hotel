using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Entities.ViewModels
{
    public class VMAccountCreate
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, RegularExpression("^[0-9A-Za-z]*$")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
