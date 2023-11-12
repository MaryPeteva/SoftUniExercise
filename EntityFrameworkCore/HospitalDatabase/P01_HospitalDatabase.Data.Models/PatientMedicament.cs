﻿
using System.ComponentModel.DataAnnotations.Schema;


namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }

        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
