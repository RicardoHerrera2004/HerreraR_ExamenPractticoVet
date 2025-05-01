using System.ComponentModel.DataAnnotations;

namespace HerreraR_ExamenPractticoVet.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido."), StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido."), StringLength(50)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido."), DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            { return DateTime.Now.Year - FechaNacimiento.Year; }
        }
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool EsClienteFrecuente { get; set; }
       
    }
}
