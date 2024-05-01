using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller1.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Apellido { get; set; }
        public DateTime fecha { get; set; }
        public Boolean Ecuatoriano { get; set; }
        
        

    }
}
