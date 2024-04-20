using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class Insumos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInsumo { get; set; }
        [Required]
        public required string NombreInsumo { get; set; }
        [Required]
        public required string Descripcion { get; set; }
        [Required]
        public required int stock { get; set; }

    }
}
