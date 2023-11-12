
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models
{
     public class Diagnose
     {
        public int DiagnoseId { get; set; }
        public string Name { get; set;}
        public string Comments { get; set; }
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
     }
}
