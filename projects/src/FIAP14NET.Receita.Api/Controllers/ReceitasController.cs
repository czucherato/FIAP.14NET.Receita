using System;
using System.Collections.Generic;
using FIAP14NET.Receita.Core.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP14NET.Receita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : Controller
    {
        public IReceitaRepository _repository { get; set; }
        
        public ReceitasController(IReceitaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Core.Dominio.Entidades.Receita> Get()
        {
            try
            {
                var receitas = _repository.ObterTodos();

                if (receitas == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StatusCode(StatusCodes.Status200OK, receitas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema no sistema!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Core.Dominio.Entidades.Receita>> Get(string id)
        {
            try
            {
                var receitas = _repository.ObterPorId(id);

                if (receitas == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StatusCode(StatusCodes.Status200OK, receitas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema no sistema!");
            }
        }
    }
}
