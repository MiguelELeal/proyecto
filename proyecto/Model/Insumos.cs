using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
