using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
