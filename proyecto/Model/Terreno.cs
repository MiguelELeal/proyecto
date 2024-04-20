using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class Terreno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTerreno { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required float Area { get; set;}

    }
}
