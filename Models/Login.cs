using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage ="Ingresar usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage ="Ingresar contraseña")]
        [Display (Name = "Contraseña")]
        public string Password { get; set; } //asdf
    }
}