using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Models;

namespace ProyectoIntegrador.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ProyectoIntegradorContext _context;


        public UsuarioController(ProyectoIntegradorContext context)
        {
            _context = context;
        }
//===============================================================================================================================================================
        //Index
        public async Task<IActionResult> Index()
        {
                    //Tabla dispositivos ToList Retorna todos los datos de ella 
            return View(await _context.Usuario.ToListAsync());

        }
 //===============================================================================================================================================================       
        //Detalles
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
            .Where(p => p.IdUsuario == id).Include(us => us.UsuarioDispositivo )
            .ThenInclude(d => d.Dispositivo).FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);

        }
//===============================================================================================================================================================
        //Crear
        public IActionResult Create()
        {   //Se creo un objeto de tipo ViewData, objeto de tipo matriz como diccionario de datos que contiene todos los registros de la tabla Dispositivo
            ViewData["ListaDispositivos"] = new SelectList(_context.Dispositivo,"IdDispositivo","Descripcion");
            return View();

        }

        [HttpPost]   
        [ValidateAntiForgeryToken] 
        //                                                                                                                          🡻 Enviar como parametro en elemento int IdDispositivo, esta es una propiedad de UsuarioDispositivo
        public async Task<IActionResult> Create([Bind("IdUsuario, Nombre, Apellido, Direccion, Telefono, Email")] Usuario usuario, int IdDispositivo)
        {
            if(ModelState.IsValid)
            {   //Primera instancia guardada es usario
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                //Datos correspondientes para grabar los datos en la tabla UsuarioDispositivo
                var usuarioDispositivo = new UsuarioDispositivo();
                //                  accediento a la propiedad IdUsuario
                usuarioDispositivo.IdUsuario = usuario.IdUsuario;
                usuarioDispositivo.IdDispositivo = IdDispositivo;
                //Segunda instancia guardada UsuarioDispositivo
                _context.Add(usuarioDispositivo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
//===============================================================================================================================================================
        //Editar
        public async Task<IActionResult> Edit(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }
            //Consulta Tipo Select [] from [] inner join  []  where...
            //Editar los datos de Usuario con los de Usuario Dispositivo
            var usuarios = await _context.Usuario.Where(u => u.IdUsuario == id)
            //                                      🡻    Obtener el primer registro si la condicion se cumple en el Where
            .Include( us => us.UsuarioDispositivo).FirstOrDefaultAsync();
            if(usuarios == null)
            {
                return NotFound();
            }
            //🡻Obtener un solo elemento del objeto var usuario    
            ViewData["ListaDispositivos"] = new SelectList(
                // 🡻Enviando el modelo Dispositivo, nos muestra todos los registros de la tabla Dispositivo
                //                      🡻Campo Value    🡻Campo que se mostrara
                //                                                      🡻Valor por default, lo que se muestra en el listBox, el valor guardado en la tabla 
                //                                                     🡻 objeto Usuario
                //                                                              🡻tabla UsuarioDispositivo      
                //                                                                              🡻 Dato almacenado en la funcion FirstOrDefaultAsync();
                _context.Dispositivo,"IdDispositivo", "Descripcion", usuarios.UsuarioDispositivo[0].IdDispositivo);

            return View(usuarios);
        }
        [HttpPost] 
         [ValidateAntiForgeryToken]                                                                      // clase        //Objeto       
        public async Task<IActionResult> Edit(int? id, [Bind("IdUsuario, Nombre, Apellido, Direccion, Telefono, Email")] Usuario usuario,int IdDispositivo)
        {

            if(id != usuario.IdUsuario)
            {
                return NotFound();
            }


            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                     await _context.SaveChangesAsync();


                     var usuarioDispositivo = await _context.UsuarioDispositivo
                     .FirstOrDefaultAsync(u => u.IdUsuario == id);

                     _context.Remove(usuarioDispositivo);
                    await _context.SaveChangesAsync();

                    usuarioDispositivo.IdDispositivo = IdDispositivo;

                    
                     _context.Add(usuarioDispositivo);
                     await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExist(usuario.IdUsuario))
                    {
                        return NotFound();
                    }
                    else
                    {
                       throw;      
                    }
                }
                
               
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }
//===============================================================================================================================================================
        private bool UsuarioExist(int idUsuario)
        {
            throw new NotImplementedException();
        }
//===============================================================================================================================================================         
        public async Task<IActionResult> Delete(int? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
            .Where(p => p.IdUsuario == id).Include(us => us.UsuarioDispositivo )
            .ThenInclude(d => d.Dispositivo).FirstOrDefaultAsync();
            

            if(usuario == null)
            {
               return NotFound(); 
            }
            return View(usuario);
        }

                   //Alias para poder acceder al DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioDispositivo = await _context.UsuarioDispositivo
            .FirstOrDefaultAsync(us => us.IdUsuario == id);

            
            _context.UsuarioDispositivo.Remove(usuarioDispositivo);  
            await _context.SaveChangesAsync();


            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
           await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}