using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerreraR_ExamenPractticoVet.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio"), StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Especie es requerido"), StringLength(50)]
        public string Especie { get; set; }
        [Required(ErrorMessage = "El campo Raza es requerido"), StringLength(50)]
        public string Raza { get; set; }
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido")]
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                return DateTime.Now.Year - FechaNacimiento.Year;
            }
        }
        [DataType(DataType.DateTime)]   
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Propietario
        public int PropietarioId { get; set; }
        [ForeignKey("PropietarioId")]
        public Propietario? Propietario { get; set; }
    }
}
