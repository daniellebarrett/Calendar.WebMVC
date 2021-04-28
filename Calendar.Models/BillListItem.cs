using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class BillListItem
    {
        [Key]
        public int BillingID { get; set; }
        [Required]
        [Display(Name = "Paid")]
        public bool BillStatus { get; set; }
        [Required]
        public double BillAmount { get; set; }
    }
}
