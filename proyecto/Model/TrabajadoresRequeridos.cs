﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyecto.Model
{
    public class TrabajadoresRequeridos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTraRe { get; set; }
        [Required]
        public int IDTrabjadorFK { get; set; }
        [ForeignKey("IDTrabjadorFK")]
        public virtual Trabajadores? Trabajadores { get; set; }
        [Required]
        public int IDProcedimientoFK { get; set; }
        [ForeignKey("IDProcedimientoFK")]
        public virtual Procedimento? Procedimento { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;

    }
}
