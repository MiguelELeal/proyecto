using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class Procedimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDProcedimiento { get; set; }
        [Required]
        public int IDCultivoFK { get; set; }
        [ForeignKey("IDCultivoFK")]
        public virtual Cultivo? Cultivo { get; set; }
        [Required]
        public int IDTipoProcedimientoFK { get; set;}
        [ForeignKey("IDTipoProcedimientoFK")]
        public virtual TipoProcedimiento? TipoProcedimiento { get; set; }
        [Required]
        public DateOnly FechaProcedimiento { get; set; }
        [Required]
        public required string Descripcion { get; set; }

    }
}
