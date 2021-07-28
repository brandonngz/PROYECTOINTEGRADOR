using System.Collections.Generic;//instanciar un tipo de dato list.
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario {get; set;}

        public string Nombre {get; set;}

        public string Apellido {get; set;}

        public string Direccion {get; set;}

        public string Telefono {get; set;}

        public string Email {get; set;}

        //Agregando una propiedad, tipo List
        //Hacemos referencia al modelo UsuarioDispositivo
        public List<UsuarioDispositivo> UsuarioDispositivo { get; set; }

    }
}
