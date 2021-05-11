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

        [Display(Name = "Apt. Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        
        [Display(Name = "Est. End Time ")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        
        [Display(Name ="Apt. Type")]
        public AppointmentType TypeOfAppointment { get; set; }

        [Display(Name = "Summary")]
        public string AppointmentReason { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
