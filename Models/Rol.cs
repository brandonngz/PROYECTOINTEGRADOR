using System.ComponentModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models
{

    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }
        //====================================================================================
        [StringLength(50, ErrorMessage = "El máximo de caracteres el 50")]
        [Required(ErrorMessage = "Dede Ingresar la Descripción!")]   
        [Display (Name = "Descripción")]
        public string Descripcion{get;set;}

        public List<AdministradorRol> AdministradorRol { get; set; }
    }
}