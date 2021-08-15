using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Models;

namespace ProyectoIntegrador.Controllers
{
    public class HistorialController : Controller
    {
         private readonly ProyectoIntegradorContext _context;


         public HistorialController(ProyectoIntegradorContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            
            return View(await _context.Historial.ToListAsync());
        }

//===============================================================================================================================================================  
        //METODO DELETE

        //                                           🡻 parametro ID
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            } //                acceder al modelo Historial
            //                  🡻                  🡻realice una busqueda a la propiedad IdHistorial  donde sea igual al parametro id
            //                                        si encuentra una coincidencia agregara el dato a la variable Historial
            var histo = await _context.Historial.FirstOrDefaultAsync(d => d.IdHistorial == id); 

             if(histo == null)
            {
                return NotFound();
            }
            //Obligatorio para poder mostrar los datos en la vista
            return View(histo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //  🡻Definir un objeto de tipo Variant y le asignamos el retorno de _context 
            //                                            🡻Igual a SELECT * FROM [NAME] WHERE..
            //                                              cuando lo encuentre se le asignara al objeto historial
            var histo = await _context.Historial.FindAsync(id);
            //                    🡻 Metodo ejecutado mediante Linq, es igual que hacer un DELETE * FROM TABLE Historial where....
            _context.Historial.Remove(histo);
            //Guardar definitivamente la eliminacion 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
 //===============================================================================================================================================================       
        
        
    }
}