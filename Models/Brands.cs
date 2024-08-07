using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cockpit_Local.Models
{
    public class Brands
    {
        public int ID { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string BrandLogo { get; set; }
        public string Stores { get; set; }
        [Required]
        public int BrandCode { get; set; }
        [Required]
        public string BrandURL { get; set; }
        public string SMSSenderID { get; set; }
        [EmailAddress]
        public string EmailSenderID { get; set; }
        [EmailAddress]
        public string SenderEmailAddress { get; set; }
        public string CompanyCIN { get; set; }
    }
}