using Calendar.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
   public class BillEdit
    {
        [Key]
        public int BillingID { get; set; }
        [Required]
        [Display(Name = "Date Issued")]
        [DataType(DataType.Date)]
        public DateTime DateIssued { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime DateDue { get; set; }
        [Required]
        [Display(Name = "Paid")]
        public bool BillStatus { get; set; }
        [Required]
        public double BillAmount { get; set; }

        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
