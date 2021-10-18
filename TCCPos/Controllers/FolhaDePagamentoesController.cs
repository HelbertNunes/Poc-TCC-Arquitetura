using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCCPos.Data;
using TCCPos.Models;

namespace TCCPos.Controllers
{
    public class FolhaDePagamentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FolhaDePagamentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FolhaDePagamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FolhaDePagamento.ToListAsync());
        }

        // GET: FolhaDePagamentoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folhaDePagamento = await _context.FolhaDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folhaDePagamento == null)
            {
                return NotFound();
            }

            return View(folhaDePagamento);
        }

        // GET: FolhaDePagamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FolhaDePagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MesReferente,Valor,UltimaAlteracao")] FolhaDePagamento folhaDePagamento)
        {
            if (ModelState.IsValid)
            {
                folhaDePagamento.Id = Guid.NewGuid();
                _context.Add(folhaDePagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(folhaDePagamento);
        }

        // GET: FolhaDePagamentoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folhaDePagamento = await _context.FolhaDePagamento.FindAsync(id);
            if (folhaDePagamento == null)
            {
                return NotFound();
            }
            return View(folhaDePagamento);
        }

        // POST: FolhaDePagamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MesReferente,Valor,UltimaAlteracao")] FolhaDePagamento folhaDePagamento)
        {
            if (id != folhaDePagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(folhaDePagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FolhaDePagamentoExists(folhaDePagamento.Id))
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
            return View(folhaDePagamento);
        }

        // GET: FolhaDePagamentoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folhaDePagamento = await _context.FolhaDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folhaDePagamento == null)
            {
                return NotFound();
            }

            return View(folhaDePagamento);
        }

        // POST: FolhaDePagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var folhaDePagamento = await _context.FolhaDePagamento.FindAsync(id);
            _context.FolhaDePagamento.Remove(folhaDePagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FolhaDePagamentoExists(Guid id)
        {
            return _context.FolhaDePagamento.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("IniciarPagamento")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IniciarPagamento()
        {
            var folhasDePagamento = _context.FolhaDePagamento.ToList();

            foreach (var folha in folhasDePagamento)
            {
                _context.FolhaDePagamento.Remove(folha);

            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
