using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Models;

//Scaffolding- fue creado el controlador Administrador a partir del modelo Aministrador
//dotnet aspnet-codegenerator controller -name AdministradorController -actions -m Administrador -dc ProyectoIntegradorContext -outDir Controllers

namespace ProyectoIntegrador.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ProyectoIntegradorContext _context;

        public AdministradorController(ProyectoIntegradorContext context)
        {
            _context = context;
        }
//===============================================================================================================================================================
        // GET: Administrador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrador.ToListAsync());
        }
//===============================================================================================================================================================
        // GET: Administrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
            .Where(p => p.IdAdministrador == id).Include(us => us.AdministradorRol )
            .ThenInclude(d => d.Rol).FirstOrDefaultAsync();

            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }
//===============================================================================================================================================================
        // GET: Administrador/Create
        public IActionResult Create()
        {  
             ViewData["ListaDispositivos"] = new SelectList(_context.Rol,"IdRol","Descripcion");
            return View();
        }

        // POST: Administrador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdministrador,Nombre,Apellido,Direccion,Telefono,Email")] Administrador administrador, int IdRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();

                
                var administradorRol = new AdministradorRol();
        
                administradorRol.IdAdministrador = administrador.IdAdministrador;
                administradorRol.IdRol = IdRol;
            
                _context.Add(administradorRol);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
//===============================================================================================================================================================
        // GET: Administrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.Where(u => u.IdAdministrador == id)
            //                                      🡻    Obtener el primer registro si la condicion se cumple en el Where
            .Include( us => us.AdministradorRol).FirstOrDefaultAsync();
            if (administrador == null)
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
                _context.Rol,"IdRol", "Descripcion", administrador.AdministradorRol[0].IdRol);



            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdministrador,Nombre,Apellido,Direccion,Telefono,Email")] Administrador administrador, int IdRol)
        {
            if (id != administrador.IdAdministrador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();

                    var administradorRol = await _context.AdministradorRol
                     .FirstOrDefaultAsync(u => u.IdAdministrador == id);

                     _context.Remove(administradorRol);
                    await _context.SaveChangesAsync();

                    administradorRol.IdRol = IdRol;

                    
                     _context.Add(administradorRol);
                     await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.IdAdministrador))
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
            return View(administrador);
        }


         private bool AdministradorExists(int id)
        {
             throw new NotImplementedException();
        }
//===============================================================================================================================================================
        // GET: Administrador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .FirstOrDefaultAsync(m => m.IdAdministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administradorRol = await _context.Administrador
            .FirstOrDefaultAsync(us => us.IdAdministrador == id);

            _context.Administrador.Remove(administradorRol);
            await _context.SaveChangesAsync();

            var administrador = await _context.Administrador.FindAsync(id);
            _context.Administrador.Remove(administrador);
           await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            
        }

       
    }
}
