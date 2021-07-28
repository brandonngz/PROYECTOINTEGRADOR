using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador.Models;
using System.Threading.Tasks;//En conjunto con el metodo asincrinico
using Microsoft.EntityFrameworkCore;

namespace ProyectoIntegrador.Controllers
{
    public class DispositivoController : Controller //Hereda los datos de Controller incluida en el Framework NetCore.
    {   
        //variable para el objeto ProyectoIntegradorContext
        private readonly ProyectoIntegradorContext _context;

        //Contructor de la clase | Debe ser mismo nombre que la clase
        public DispositivoController(ProyectoIntegradorContext context) //Inicializa valores cuando instanciemos este controlador
        {
            _context = context;

        }
        //===============================================================================================================================================================
        //Metodo para mostrar datos en la pantalla del usuario
        //                  🡻 Mostrar el retorno de datos sobre el modelo a la View
        public async Task<IActionResult> Index() //Debe ser mismo nombre que la vista [Views]
        {
            //                  🡻   Pasando a la vista como parametro el objeto 🡸
            //                          🡻 Accediendo a la tabla Dispositivo  
            //                                      🡻 Operacion similar a los que es un 
            //                                          SELECTO * FROM Dispositivo; devolver el total de registros de la entidad   
            return View(await _context.Dispositivo.ToListAsync());//retornar a la vista Index

        }
        //===============================================================================================================================================================
        //Metodo para Editar los datos
        //Encargado de mostrarnos el dispositivo Metodo Post
        //                               🡻Dato del dispositivo que queremos editar.
        //                                       🡻Signo de pregunta, por si el parametro se recibe null, hace que se puedan permitir datos null, sin recibir una excepcion
        //      🡻Convierte el metodo a manera asincronica
        //         cualquiera que use este metodo, podra ejecutarlo sin problema, un conjunto de personas al mismo tiempo
        //            🡻  dejara la transacccion abierta para que pueda ser ejecutada por otras peticiones
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            //  🡻Definir un objeto de tipo Variant y le asignamos el retorno de _context 
            //                🡻se usa en conjunto con async
            //                                          🡻Igual a SELECT * FROM [NAME] WHERE.. ASINCRONICAMENTE
            var dispositivo = await _context.Dispositivo.FindAsync(id);

            if(dispositivo == null)
            {
                return NotFound();
            }
            return View(dispositivo);
        }

        ////Encargado de hacer la grabacion en la tabla Dispositivo y enviarlo 
        [HttpPost]
        //                                              Propiedad para enlazar los datos que tengamos en el formulario con este metodo
         public async Task<IActionResult> Edit(int id,[Bind("IdDispositivo, Nombre, Codigo, Ubicacion, Descripcion")] Dispositivo dispositivo)
        {
            if(id != dispositivo.IdDispositivo)
            {
                return NotFound();
            }
            //Si la propiedad Bind nos trae los datos correctamente y todas las validaciones son OK, grabara datos
            if (ModelState.IsValid)
            {
               _context.Update(dispositivo);
               await _context.SaveChangesAsync();

                //Nos redireje a la vista Index una vez tenga actualizado los datos.
                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }
        //===============================================================================================================================================================  
        //METODO DELETE

        //                                           🡻 parametro ID
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            } //                acceder al modelo Dispositivo
            //                  🡻                  🡻realice una busqueda a la propiedad IdDispositivo  donde sea igual al parametro id
            //                                        si encuentra una coincidencia agregara el dato a la variable dispositivo
            var dispositivo = await _context.Dispositivo.FirstOrDefaultAsync(d => d.IdDispositivo == id); 

             if(dispositivo == null)
            {
                return NotFound();
            }
            //Obligatorio para poder mostrar los datos en la vista
            return View(dispositivo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //  🡻Definir un objeto de tipo Variant y le asignamos el retorno de _context 
            //                                            🡻Igual a SELECT * FROM [NAME] WHERE..
            //                                              cuando lo encuentre se le asignara al objeto dispositivo
            var dispositivo = await _context.Dispositivo.FindAsync(id);
            //                    🡻 Metodo ejecutado mediante Linq, es igual que hacer un DELETE * FROM TABLE Dispositivo where....
            _context.Dispositivo.Remove(dispositivo);
            //Guardar definitivamente la eliminacion 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //===============================================================================================================================================================
        //METODO CREATE

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdDispositivo, Nombre, Codigo, Ubicacion, Descripcion")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dispositivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dispositivo);
        }


    }
}