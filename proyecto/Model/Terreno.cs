using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
