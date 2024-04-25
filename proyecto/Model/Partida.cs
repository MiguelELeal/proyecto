using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDPartida { get; set; }
        [Required]
        public int IDUsuarioFK { get; set; }
        [ForeignKey("IDUsuarioFK")]
        public virtual Usuario? Usuario { get; set; }
        [Required]
        public DateOnly FechaInicio { get; set; }
        [Required]
        public required string Ubicacion { get; set; }
        [Required]
        public required string Nivel {  get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;


    }
}
