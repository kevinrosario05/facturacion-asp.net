using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class ServiciosController : Controller
    {
        ClienteContext _context;


        public ServiciosController()
        {

            _context = new ClienteContext();

        }

        // GET: Servicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicios.ToListAsync());
        }



        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Servicio());
            else
                return View(_context.Servicios.Find(id));
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdServicio,Nombre_Servic,Precio,Descripcion,Contador")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                servicio.Contador = 0;
                if (servicio.IdServicio == 0)
                    _context.Add(servicio);
                else
                    _context.Update(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicio);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var servicios = await _context.Servicios.FindAsync(id);
            _context.Servicios.Remove(servicios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
