using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller1.Models
{
    public class Motor
    {
        
        public int Id { get; set; }
        public string TipoMotor { get; set; }
        public string caballos {  get; set; }

        public string anio {  get; set; }

        [ForeignKey("AutoId")]
        public int? AutoId { get; set; }
        public Auto? Auto { get; set; }


    }
}
