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
    public class ProductosController : Controller
    {
        ClienteContext _Context;


        public ProductosController()
        {

            _Context = new ClienteContext();

        }
        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Productos.ToListAsync());
        }


      
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Productos());
            else
                return View(_Context.Productos.Find(id));
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("IdProducto,Nombre_Produc,Precio,Cantidad,Contador")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                productos.Contador = 0;
                if (productos.IdProducto == 0)
                    _Context.Add(productos);
                else
                    _Context.Update(productos);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productos);
        }


        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var productos = await _Context.Productos.FindAsync(id);
            _Context.Productos.Remove(productos);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
