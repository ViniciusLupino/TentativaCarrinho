using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcoImpulseWebSite.Data;
using EcoImpulseWebSite.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoImpulseWebSite.Controllers
{
    public class CarrinhosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public CarrinhosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Carrinhos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carrinhos.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Carrinhos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCarrinho == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinhos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Carrinhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCarrinho,UsuarioId,ProdutosId")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                carrinho.IdCarrinho = Guid.NewGuid();
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", carrinho.UsuarioId);
            return View(carrinho);
        }

        // GET: Carrinhos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", carrinho.UsuarioId);
            return View(carrinho);
        }

        // POST: Carrinhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCarrinho,UsuarioId,ProdutosId")] Carrinho carrinho)
        {
            if (id != carrinho.IdCarrinho)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinho.IdCarrinho))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", carrinho.UsuarioId);
            return View(carrinho);
        }

        // GET: Carrinhos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCarrinho == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho != null)
            {
                _context.Carrinhos.Remove(carrinho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(Guid id)
        {
            return _context.Carrinhos.Any(e => e.IdCarrinho == id);
        }

        public async Task<IActionResult> AdicionarProduto(Guid id)
        {
            if (!Guid.TryParse(_userManager.GetUserId(User), out var userGuid))
                return BadRequest("ID de usuário inválido.");

            var carrinho = _context.Carrinhos.FirstOrDefault(a => a.UsuarioId == userGuid) ?? new Carrinho
            {
                UsuarioId = userGuid,
                ProdutosId = new List<Guid>()
            };

            // Adiciona o produto ao carrinho, mesmo que já exista
            carrinho.ProdutosId.Add(id);

            // Se o carrinho era novo, adicionamos; caso contrário, atualizamos
            if (_context.Entry(carrinho).State == EntityState.Detached)
                _context.Carrinhos.Add(carrinho);
            else
                _context.Carrinhos.Update(carrinho);

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Produto adicionado ao carrinho com sucesso." });
        }

    }
}
