using System.ComponentModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProyectoIntegrador.Models
{

    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        //====================================================================================
        [StringLength(20, ErrorMessage = "El máximo de caracteres el 20")]
        [Required(ErrorMessage = "Dede Ingresar la Descripción!")]   
        [Display (Name = "Descripción")]
        public string Descripcion{get;set;}

        public List<AdministradorRol> AdministradorRol { get; set; }
    }
}