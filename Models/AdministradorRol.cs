using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador.Models
{   
    //esta clase puede acceder a la carpeta model y asi usar otros modelos
    public class AdministradorRol
    {      
        [Key]
        public int IdAdministrador { get; set; }
        public int IdRol { get; set; }

        //      🡻 Nombre de los modelos, los reconoce por que hemos puesto nuestro namespace ProyectoIntegrador.Models, esto hace que podamos hacer uso de ellos en otra clase.
        public Administrador Administrador { get; set; }
        
         //     🡻 Nombre de los modelos
        public Rol Rol { get; set; }
       
    }
}