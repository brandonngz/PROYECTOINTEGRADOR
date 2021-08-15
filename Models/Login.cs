using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [StringLength(20, ErrorMessage = "El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Ingresar usuario")]
        public string Usuario { get; set; }

        [StringLength(100, ErrorMessage = "El máximo de caracteres es 20")]
        [Required(ErrorMessage ="Ingresar contraseña")]
        [Display (Name = "Contraseña")]
        public string Password { get; set; } //asdf
    }
}