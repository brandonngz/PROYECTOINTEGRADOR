using System.ComponentModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProyectoIntegrador.Models
{
    public class Dispositivo
    {   
        [Key]   //Llave Primaria
        public int IdDispositivo {get; set;}

        public string Nombre {get; set;} //Nombre del dispositivo Cerradura

        public string Codigo {get; set;} //Serie numera que describe el dispositivo Cerradura

        public string Ubicacion {get;set;} //Ubicacion sobre el cual se encuentra la puerta

        public string Descripcion{get;set;} //Dispositivo en uso [Tipo de puerta]

        //Agregando una propiedad, tipo List
        //Hacemos referencia al modelo UsuarioDispositivo
        public List<UsuarioDispositivo> UsuarioDispositivo { get; set; }
    }
}