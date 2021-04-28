using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Data
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone #")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
