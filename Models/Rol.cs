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

        public string Descripcion { get; set; }

        public List<AdministradorRol> AdministradorRol { get; set; }
    }
}