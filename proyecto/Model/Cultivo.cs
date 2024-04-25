using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class Cultivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDCultivo { get; set; }
        [Required]
        public int IdSiembraFK { get; set; }
        [Required]
        public DateOnly FechaCosechaE {  get; set; }
        [Required]
        public int IdEstadoFK { get; set; }
        [Required]
        public DateOnly FechaModificacion { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

        [ForeignKey("IdSiembraFK")]
        public virtual Siembra? Siembra { get; set; }
        [ForeignKey("IdEstadoFK")]
        public virtual EstadoCultivo? EstadoCultivo { get; set; }
    }
}
