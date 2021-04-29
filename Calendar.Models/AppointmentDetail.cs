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
    public class AppointmentDetail
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "Est. End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Required]
        public AppointmentType TypeOfAppointment { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name ="Summary")]
        public string AppointmentReason { get; set; }

        [ForeignKey(nameof(Client))]
        [Display(Name = "Client ID")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
