using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class TipoProcedimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTipoPro { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;
    }
}
