using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using proyecto.Model;

namespace proyecto.Model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUsuario { get; set; }
        public required string email { get; set; }

        public required string contrasena { get; set; }
        public int IdRolFK { get; set; }

        [ForeignKey("IdRolFK")]

        public virtual Rol? Rol { get; set; }

    }
}
