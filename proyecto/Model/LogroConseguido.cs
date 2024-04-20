using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class LogroConseguido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLogCon { get; set; }
        [Required]
        public int IDPartidaFK { get; set; }
        [ForeignKey("IDPartidaFK")]
        public virtual Partida? Partida { get; set; }
        [Required]
        public int IDLogroFK{ get; set;}
        [ForeignKey("IDLogroFK")]
        public virtual Logro? Logro { get; set; }
        [Required]
        public DateOnly FechaLogro { get; set; }
    }
}
