using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HerreraR_ExamenPractticoVet.Models
{
    public class Visita
    {
        [Key]   
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaVisita { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El campo Motivo es obligatorio, ingrese Vacunacion, Revision general o Cirugia")]
        public string Motivo
        {
            get
            {
                if (string.Compare(Motivo, "Vacunacion", true) == 0)
                {
                    return "Vacunacion";
                }
                else if (string.Compare(Motivo, "Revision general", true) == 0)
                {
                    return "Revision general";
                }
                else if (string.Compare(Motivo, "Cirugia", true) == 0)
                {
                    return "Cirugia";
                }
                else
                {
                    return "Otro";
                }
            }
        }

        public float TarifaTotal
        {
            get
            {
                if (string.Compare(Motivo, "Vacunacion", true) == 0)
                {
                    return 30;
                }
                else if (string.Compare(Motivo, "Revision general", true) == 0)
                {
                    return 20;
                }
                else if (string.Compare(Motivo, "Cirugia", true) == 0)
                {
                    return 100;
                }
                else
                {
                    return 0;
                }
            }
        }
        [StringLength(200, ErrorMessage = "El campo Observaciones no puede exceder los 200 caracteres.")]
        public string Observaciones { get; set; }
        public bool RequiereMedicacion { get; set; }
        // Mascota
        public int MascotaId { get; set; }
        [ForeignKey("MascotaId")]
        public Mascota? Mascota { get; set; }
    }
}
