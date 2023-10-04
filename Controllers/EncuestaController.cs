using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Productos.Models;

namespace Proyec1.Controllers
{
    public class EncuestaController : Controller
    {
        private readonly DefaultConnection _context;

        public EncuestaController(DefaultConnection context)
        {
            _context = context;
        }

        // GET: Encuesta
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'DefaultConnection.Products'  is null.");
        }

        // GET: Encuesta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Products
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (modeloProductos == null)
            {
                return NotFound();
            }

            return View(modeloProductos);
        }

        // GET: Encuesta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Encuesta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproducto,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ModeloProductos modeloProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloProductos);
        }

        // GET: Encuesta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Products.FindAsync(id);
            if (modeloProductos == null)
            {
                return NotFound();
            }
            return View(modeloProductos);
        }

        // POST: Encuesta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idproducto,Nombre,Marca,Modelo,Precio,descripcion,imgprincipal")] ModeloProductos modeloProductos)
        {
            if (id != modeloProductos.Idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloProductosExists(modeloProductos.Idproducto))
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
            return View(modeloProductos);
        }

        // GET: Encuesta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var modeloProductos = await _context.Products
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (modeloProductos == null)
            {
                return NotFound();
            }

            return View(modeloProductos);
        }

        // POST: Encuesta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'DefaultConnection.Products'  is null.");
            }
            var modeloProductos = await _context.Products.FindAsync(id);
            if (modeloProductos != null)
            {
                _context.Products.Remove(modeloProductos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloProductosExists(int id)
        {
          return (_context.Products?.Any(e => e.Idproducto == id)).GetValueOrDefault();
        }
    }
}
