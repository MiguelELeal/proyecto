using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class EstadoCultivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEstado { get; set; }
        [Required]
        public required string NombreEstado { get; set; }

    }
}
