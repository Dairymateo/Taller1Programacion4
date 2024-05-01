using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller1.Models
{
    public class Auto
    {


        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public int Puertas { get; set; }
        public string color { get; set; }
        public int anio { get; set; }
        

        [ForeignKey("PropietarioId")]
        public int? PropietarioId { get; set; }
        public Propietario? Propietario { get; set; }
    }
}
