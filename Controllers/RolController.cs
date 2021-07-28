using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Models;

namespace ProyectoIntegrador.Controllers
{

    public class RolController : Controller
    {
        private readonly ProyectoIntegradorContext _context;

        public RolController(ProyectoIntegradorContext context) //Inicializa valores cuando instanciemos este controlador
        {
            _context = context;

        }

//===============================================================================================================================================================
        public async Task<IActionResult> Index()
        { //                            🡻 PARA PODER QUE FUNCIONE DEBE ESTAR AGREGADO EL NOMBRE SOBRE LA ENTIDAD EN ProyectoIntegradorContext [Modelo]                              
            return View(await _context.Rol.ToListAsync());
        }

//===============================================================================================================================================================
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            //  🡻Definir un objeto de tipo Variant y le asignamos el retorno de _context 
            //                🡻se usa en conjunto con async
            //                                          🡻Igual a SELECT * FROM [NAME] WHERE.. ASINCRONICAMENTE
            var rol = await _context.Rol.FindAsync(id);

            if(rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        [HttpPost]
        //                                              Propiedad para enlazar los datos que tengamos en el formulario con este metodo
         public async Task<IActionResult> Edit(int id,[Bind("IdRol, Descripcion")] Rol rol)
        {
            if(id != rol.IdRol)
            {
                return NotFound();
            }
            //Si la propiedad Bind nos trae los datos correctamente y todas las validaciones son OK, grabara datos
            if (ModelState.IsValid)
            {
               _context.Update(rol);
               await _context.SaveChangesAsync();

                //Nos redireje a la vista Index una vez tenga actualizado los datos.
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }
//===============================================================================================================================================================
         //METODO DELETE   
            public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            } //                acceder al modelo Dispositivo
            //                  🡻                  🡻realice una busqueda a la propiedad IdDispositivo  donde sea igual al parametro id
            //                                        si encuentra una coincidencia agregara el dato a la variable dispositivo
            var rol = await _context.Rol.FirstOrDefaultAsync(d => d.IdRol == id); 

             if(rol == null)
            {
                return NotFound();
            }
            //Obligatorio para poder mostrar los datos en la vista
            return View(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            //  🡻Definir un objeto de tipo Variant y le asignamos el retorno de _context 
            //                                            🡻Igual a SELECT * FROM [NAME] WHERE..
            //                                              cuando lo encuentre se le asignara al objeto dispositivo
            var rol = await _context.Rol.FindAsync(id);
            //                    🡻 Metodo ejecutado mediante Linq, es igual que hacer un DELETE * FROM TABLE Dispositivo where....
            _context.Rol.Remove(rol);
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
        public async Task<IActionResult> Create([Bind("IdRol, Descripcion")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }


    

    }
}
