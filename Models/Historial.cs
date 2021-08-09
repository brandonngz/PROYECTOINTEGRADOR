using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProyectoIntegrador.Models
{
    public class Historial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistorial { get; set; }
        [Display(Name ="Fecha")]
        public DateTime fecha { get; set; }
        [Display(Name ="Descripcion")]
        public string descripcion { get; set; }
        [Display(Name ="Usuario")]
        public string usuario { get; set; }
    }
}