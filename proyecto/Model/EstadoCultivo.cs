using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class EstadoCultivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDEstado { get; set; }
        [Required]
        public required string NombreEstado { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
