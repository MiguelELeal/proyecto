using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class Logro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLogro { get; set; }
        [Required]
        public required string NombreLogro { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;
    }
}
