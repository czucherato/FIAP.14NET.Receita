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
using FIAP14NET.Receita.Core.Dominio.Interfaces;

namespace FIAP14NET.Receita.Site.Controllers
{
    public class ReceitasController : Controller
    {
        public IReceitaRepository _repository { get; set; }
        public IMapper _mapper;

        public ReceitasController(IReceitaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var receitas = _mapper.Map<IEnumerable<ReceitaViewModel>>(await _repository.ObterTodosAssincrono());

            return View(receitas);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.ObterPorIdAssincrono(id);

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

                _repository.Adicionar(receita);
                await _repository.SaveChangesAssincrono();
                return RedirectToAction(nameof(Index));
            }
            return View(receitaViewModel);
        }

        // GET: Receitas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.ObterPorIdAssincrono(id);
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
                    _repository.Editar(receita);
                    await _repository.SaveChangesAssincrono();
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
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.ObterPorIdAssincrono(id);
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
            var receita = await _repository.ObterPorIdAssincrono(id);
            if (receita == null)
                return NotFound();
            _repository.Apagar(receita);
            await _repository.SaveChangesAssincrono();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(Guid id)
        {
            return _repository.ObterTodos().Any(e => e.Id == id);
        }
    }
}
