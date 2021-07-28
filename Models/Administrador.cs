using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador.Models
{
    public class Administrador
    {   
        [Key]
        public int IdAdministrador { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public List<AdministradorRol> AdministradorRol { get; set; }

    }
}