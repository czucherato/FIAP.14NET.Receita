using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FIAP14NET.Receita.Core.Persistencia.Contexto;
using AutoMapper;
using FIAP14NET.Receita.Core.Dominio.ViewModels;
using FIAP14NET.Receita.Core.Dominio.ObjetosDeValor;

namespace FIAP14NET.Receita.Site.Controllers
{
    public class ReceitasController : Controller
    {
        private readonly ReceitaContexto _context;
        public IMapper _mapper;

        public ReceitasController(ReceitaContexto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var receitas = _mapper.Map<IEnumerable<ReceitaViewModel>>(await _context.Receita.ToListAsync());

            return View(receitas);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FirstOrDefaultAsync(m => m.Id == id);

            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        public IActionResult Create()
        {
            return View(new ReceitaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceitaViewModel receitaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(receitaViewModel);
            }

            if (ModelState.IsValid)
            {
                var receita = _mapper.Map<Core.Dominio.Entidades.Receita>(receitaViewModel);

                receita.Id = Guid.NewGuid();
                receita.CriadoEm = DateTime.Now;
                receita.AlteradoEm = DateTime.Now;
                receita.Status = Status.Ativo;

                _context.Add(receita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receitaViewModel);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ReceitaViewModel receitaViewModel)
        {
            var receita = _mapper.Map<Core.Dominio.Entidades.Receita>(receitaViewModel);

            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {    
                    _context.Update(receita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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

            return View(receita);
        }

        // GET: Receitas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _context.Receita
                .FirstOrDefaultAsync(m => m.Id == id);
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var receita = await _context.Receita.FindAsync(id);
            _context.Receita.Remove(receita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(Guid id)
        {
            return _context.Receita.Any(e => e.Id == id);
        }
    }
}
