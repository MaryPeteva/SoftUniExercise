﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
     
        public int PatientId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set;}
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(80)]
        public string Email { get; set; }
        [Required]
        public bool HasInsurance { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }

    }
}
