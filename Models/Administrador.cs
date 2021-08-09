using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models
{
    public class Administrador
    {   
        //====================================================================================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdministrador { get; set; }
        //====================================================================================
        [StringLength(20, ErrorMessage = "El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Nombre!")]
        public string Nombre {get; set;}
        //====================================================================================
        [StringLength(20, ErrorMessage ="El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Apellido!")]
        public string Apellido {get; set;}
        //====================================================================================
        [StringLength(50, ErrorMessage ="El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Dirección!")]
        [Display(Name ="Dirección")]
        public string Direccion {get; set;}
        //====================================================================================
        [StringLength(20, ErrorMessage ="El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Teléfono!")]
        [Display(Name ="Teléfono")]
        public string Telefono {get; set;}
        //====================================================================================
        [StringLength(50, ErrorMessage ="El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Email!")]
        [EmailAddress(ErrorMessage ="No es el formato correcto.")]
        [Display(Name ="Email")]
        public string Email {get; set;}
        //====================================================================================

        public List<AdministradorRol> AdministradorRol { get; set; }

    }
}