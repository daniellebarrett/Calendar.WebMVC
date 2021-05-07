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
    public class AppointmentListItem
    {
        [Key]
        [Display(Name = "Appointment ID")]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Type")]
        public AppointmentType TypeOfAppointment { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
