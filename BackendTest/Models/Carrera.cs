using System.ComponentModel.DataAnnotations;

namespace BackendTest.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string NombreCarrera { get; set; }


    }
}
