namespace ProyectoIntegrador.Models
{   
    //esta clase puede acceder a la carpeta model y asi usar otros modelos
    public class UsuarioDispositivo
    {
        public int IdUsuario { get; set; }
        public int IdDispositivo { get; set; }

        //       🡻 Nombre de los modelos, los reconoce por que hemos puesto nuestro namespace ProyectoIntegrador.Models, esto hace que podamos hacer uso de ellos en otra clase.
        public Usuario Usuario { get; set; }
        
         //       🡻 Nombre de los modelos
        public Dispositivo Dispositivo { get; set; }
    }
}