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
    public class AppointmentEdit
    {
        public int AppointmentID { get; set; }
        [Display(Name = "Date Appointment")]
        public DateTime AppointmentDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Est. End Time ")]
        public DateTime EndTime { get; set; }
        [DataType(DataType.Time)]
        public AppointmentType TypeOfAppointment { get; set; }
        [Display(Name = "Summary")]
        public string AppointmentReason { get; set; }

        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
