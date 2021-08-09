using System.Collections.Generic;//instanciar un tipo de dato list.
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models
{
    public class Usuario
    {
        //====================================================================================
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario {get; set;}
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
        [Required(ErrorMessage ="Debe Ingresar el Apellido!")]
        [Display(Name ="Teléfono")]
        public string Telefono {get; set;}
        //====================================================================================
        [StringLength(50, ErrorMessage ="El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Debe Ingresar el Apellido!")]
        [EmailAddress(ErrorMessage ="No es el formato correcto.")]
        [Display(Name ="Email")]

        public string Email {get; set;}
        //====================================================================================

        //Agregando una propiedad, tipo List
        //Hacemos referencia al modelo UsuarioDispositivo
        public List<UsuarioDispositivo> UsuarioDispositivo { get; set; }

    }
}
