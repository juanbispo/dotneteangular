using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true);
                if (eventos == null)
                {
                    return NotFound("Nenhum Evento Encontrado");
                }
                return Ok(eventos);
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Eventos. Erro {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoService.GetEventoByIdAsync(id,true);
                if (evento == null)
                {
                    return NotFound($"Nenhum Evento com o Id {id} Encontrado");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Evento. Erro {e.Message}");
            }
        }
        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var evento = await _eventoService.GetAllEventosByTemaAsync(tema,true);
                if (evento == null)
                {
                    return NotFound($"Nenhum Evento com o tema {tema} Encontrado");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Evento. Erro {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if (evento == null)
                {
                    return BadRequest($"Erro ao adicionar Evento");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar Evento. Erro {e.Message}");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if (evento == null)
                {
                    return BadRequest($"Erro ao alterar Evento");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar Evento. Erro {e.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(await _eventoService.DeleteEvento(id))
                {
                    return Ok("Evento Excluido com Sucesso!");
                }
                else
                {
                    return BadRequest("Falha ao excluir Evento!");
                }
                
            }
            catch (Exception e)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir Evento. Erro {e.Message}");
            }

        }
    }
}
