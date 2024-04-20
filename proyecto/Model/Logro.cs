using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class Logro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLogro { get; set; }
        [Required]
        public required string NombreLogro { get; set; }
    }
}
