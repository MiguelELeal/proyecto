using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTipoDoc { get; set; }
        [Required]
        public string TipoDo { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
