using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FIAP14NET.Receita.Core.Persistencia.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP14NET.Receita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : Controller
    {
        public ReceitaContexto _context { get; set; }

        public ReceitasController(ReceitaContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Core.Dominio.Entidades.Receita> Get()
        {
            try
            {
                var receitas = _context.Receita.ToList();

                if (receitas?.Count <= 0)
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
                var receitas = _context.Receita.FirstOrDefault(a => a.Id.Equals(id));

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
