using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _14_MvcCoreEfProcedures.Models
{

    [Table("DOCTOR")]
    public class Doctor
    {
        [Key]
        [Column("HOSPITAL_COD")]
        public int HospitalCod { get; set; }

        [Column("DOCTOR_NO")]
        public int DoctorNum { get; set; }

        [Column("APELLIDO")]
        public string Apellido { get; set; }

        [Column("ESPECIALIDAD")]
        public string Especialidad { get; set; }

        [Column("SALARIO")]
        public int Salario { get; set; }
    }
}
