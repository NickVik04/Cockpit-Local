using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cockpit_Local.Models
{
    public class Users
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string EmailID { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        public int PinCode { get; set; }
        public string Brand { get; set; }
        public string Stores { get; set; }
        public string CockpitRoles { get; set; }
    }
}