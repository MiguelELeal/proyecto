﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto.Model
{
    public class Siembra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSiembra { get; set; }
        [Required]
        public DateOnly FechaSiembra { get; set; }
        [Required]
        public float AreaTotalS { get; set; }
        [Required]
        public int IDTerrenoFK { get; set;}
        [ForeignKey("IDTerrenoFK")]
        public virtual Terreno? Terreno { get; set; }
    }
}
