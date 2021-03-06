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
    public class AppointmentCreate
    {
        [Required(ErrorMessage = "Appointment Date cannot be prior to today's date")]
        [Display(Name = "Date Appointment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Est. End Time ")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Apt. Type")]
        public AppointmentType TypeOfAppointment { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Summary")]
        public string AppointmentReason { get; set; }

        [ForeignKey(nameof(Client))]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        

        public string FullName { get; set; }
    }
}
