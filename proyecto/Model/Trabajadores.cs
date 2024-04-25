using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class Trabajadores
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTrabajador { get; set; }
        [Required]
        public string NumDoc { get; set; }
        [Required]
        public required string Nombres { get; set; }
        [Required]
        public required string Apellidos { get; set;}
        [Required]
        public int IDRolFK { get; set; }
        [ForeignKey("IDRolFK")]
        public virtual Rol? Rol { get; set; }
        [Required]
        public int IDTipoDocFK { get; set; }
        [ForeignKey("IDTipoDocFK")]
        public virtual TipoDocumento? TipoDocumento { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
