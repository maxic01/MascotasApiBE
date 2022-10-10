using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MascotasApiBE.Data.DTO
{
    public class MascotasDTO
    {
        [Column("ID"), Key]
        public int IdMascota { get; set; }
        [MaxLength(20)]
        public string Nombre { get; set; }
        [MaxLength(20)]
        public string Raza { get; set; }
        [MaxLength(10)]
        public string Tipo { get; set; }
        public float Peso { get; set; }
        
    }
}
