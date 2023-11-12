﻿
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Specialty { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }

    }
}
