using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Models
{
    public class AppointmentListItem
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Date of Desired Appointment")]
        public DateTimeOffset AppointmentDate { get; set; }
    }
}
