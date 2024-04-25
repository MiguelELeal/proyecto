using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class DatosPartida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDatosJugador { get; set; }
        [Required]
        public int IdPartidaFk { get; set; }
        [Required]
        public int IdProcedimientoFk { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

        [ForeignKey("IdPartidaFk")]
        public virtual Partida? Partida { get; set; }
        [ForeignKey("IdProcedimientoFk")]
        public virtual Procedimento? Procedimento { get; set; }


    }
}
