﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Data
{
    public enum AppointmentType
    {
        InitialConsultation = 1,
        CivilLitigation,
        RealEstate,
        Family,
        Criminal,
        MedicalMalpractice,
        PersonalInjury
    }
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        [Display(Name = "Date of Desired Appointment")]
        public DateTimeOffset AppointmentDate { get; set; }
        [Required]
        [Display(Name = "Start Time of Desired Appointment")]
        public DateTimeOffset StartTime { get; set; }
        [Required]
        [Display(Name = "End Time of Desired Appointment")]
        public DateTimeOffset EndTime { get; set; }
        [Required]
        public AppointmentType TypeOfAppointment { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string AppointmentReason { get; set; }
    }
}
