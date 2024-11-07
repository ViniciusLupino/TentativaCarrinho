using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoImpulseWebSite.Data;
using EcoImpulseWebSite.Models;

namespace EcoImpulseWebSite.Controllers
{
    public class CategoriaProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProdutos.ToListAsync());
        }

        // GET: CategoriaProdutos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProdutos
                .FirstOrDefaultAsync(m => m.IdCategoriaProduto == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaProduto,Nome")] CategoriaProduto categoriaProduto)
        {
            if (ModelState.IsValid)
            {
                categoriaProduto.IdCategoriaProduto = Guid.NewGuid();
                _context.Add(categoriaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProdutos.FindAsync(id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }
            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCategoriaProduto,Nome")] CategoriaProduto categoriaProduto)
        {
            if (id != categoriaProduto.IdCategoriaProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdutoExists(categoriaProduto.IdCategoriaProduto))
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
            return View(categoriaProduto);
        }

        // GET: CategoriaProdutos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProduto = await _context.CategoriaProdutos
                .FirstOrDefaultAsync(m => m.IdCategoriaProduto == id);
            if (categoriaProduto == null)
            {
                return NotFound();
            }

            return View(categoriaProduto);
        }

        // POST: CategoriaProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaProduto = await _context.CategoriaProdutos.FindAsync(id);
            if (categoriaProduto != null)
            {
                _context.CategoriaProdutos.Remove(categoriaProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdutoExists(Guid id)
        {
            return _context.CategoriaProdutos.Any(e => e.IdCategoriaProduto == id);
        }
    }
}
