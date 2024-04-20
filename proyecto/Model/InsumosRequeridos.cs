using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class InsumosRequeridos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDInRe { get; set; }
        [Required]
        public int IDInsumoFK { get; set; }
        [ForeignKey("IDInsumoFK")]
        public virtual Insumos? Insumos { get; set; }
        [Required]
        public int IDProcedimientoFK { get; set; }
        [ForeignKey("IDProcedimientoFK")]
        public virtual Procedimento? Procedimento { get; set; }
        [Required]
        public int Cantidad { get; set; }

    }
}
