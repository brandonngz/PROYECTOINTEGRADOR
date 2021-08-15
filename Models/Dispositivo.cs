using System.ComponentModel;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models
{
    public class Dispositivo
    {   
        //====================================================================================
        [Key]   //Llave Primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDispositivo {get; set;}
         //====================================================================================
        [StringLength(10, ErrorMessage = "El campos solo debe tener 10 Caracteres Máximo.")]//Limitar en la vista el numero de caracteres admitidos
        [Required (ErrorMessage = "Debe Ingresar el nombre!")]//El campo es requerido, no se puede dejar en blanco el campo    
        // 🡻En todas la partes donde tengamos DisplayNameFor, nos asignara lo que tengamos entre parentesis, sustituyendo el nombre del campo real
        //                          🡻Mientras el campo este vacio nos dira este enunciado.
        [Display (Name = "Nombre", Prompt = "Ingrese un Nombre")]
        public string Nombre {get; set;} //Nombre del dispositivo Cerradura
        //====================================================================================
        [StringLength(7, ErrorMessage = "El máximo de caracteres es 7")]
        [Required (ErrorMessage = "Debe Ingresar el Código!")]
        [Display (Name = "Código", Prompt = "Ingrese un Código")]
        public string Codigo {get; set;} //Serie numera que describe el dispositivo Cerradura
        //====================================================================================
        [StringLength(20, ErrorMessage = "El máximo de caracteres el 20")]
        [Required (ErrorMessage = "Dede Ingresar la Ubicación!")]
        [Display (Name = "Ubicación")]
        public string Ubicacion {get;set;} //Ubicacion sobre el cual se encuentra la puerta
         //====================================================================================
        [StringLength(20, ErrorMessage = "El máximo de caracteres el 20")]
        [Required(ErrorMessage = "Dede Ingresar la Descripción!")]   
        [Display (Name = "Descripción")]
        public string Descripcion{get;set;} //Dispositivo en uso [Tipo de puerta]
         //====================================================================================

        //Agregando una propiedad, tipo List
        //Hacemos referencia al modelo UsuarioDispositivo
        
        public List<UsuarioDispositivo> UsuarioDispositivo { get; set; }


    }
}