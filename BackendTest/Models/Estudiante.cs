using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTest.Models
{
    public class Estudiante
    {
        [Key]
        public int P_id { get; set; }

        [Required]
        [StringLength(20)]

        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]

        public string Apellidos { get; set; }

        [Required]
        [StringLength(40)]


        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]

        public string Ciudad { get; set; }

        [Required]
        [ForeignKey("carrera")]
        public int id_carrera { get; set; }

        


    }
}
