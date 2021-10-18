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
    public class NotaFiscalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotaFiscalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NotaFiscal
        public async Task<IActionResult> Index()
        {
            return View(await _context.NotaFiscal.ToListAsync());
        }

        // GET: NotaFiscal/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }

        // GET: NotaFiscal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotaFiscal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario,ValorTotal,DataEmissao")] NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                notaFiscal.Id = Guid.NewGuid();
                _context.Add(notaFiscal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaFiscal);
        }

        // GET: NotaFiscal/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        // POST: NotaFiscal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Usuario,ValorTotal,DataEmissao")] NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaFiscal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaFiscalExists(notaFiscal.Id))
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
            return View(notaFiscal);
        }

        // GET: NotaFiscal/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }

        // POST: NotaFiscal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            _context.NotaFiscal.Remove(notaFiscal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaFiscalExists(Guid id)
        {
            return _context.NotaFiscal.Any(e => e.Id == id);
        }

        [HttpPost, ActionName("EnviaNotas")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnviaNotas()
        {
            var notas = _context.NotaFiscal.ToList();

            foreach(var nota in notas)
            {
                _context.NotaFiscal.Remove(nota);
                
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
