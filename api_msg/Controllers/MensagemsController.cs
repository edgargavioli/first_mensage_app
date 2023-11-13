using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_msg.Context;
using api_msg.Models;
using api_msg.Services;
using api_msg.View;

namespace api_msg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagemsController : ControllerBase
    {
        private readonly MensagemService _mensagem;

        public MensagemsController(MensagemService mensagem)
        {
            _mensagem = mensagem;
        }

        // GET: api/Mensagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagems()
        {
          var mensagens = await _mensagem.GetMensagems();

          if (mensagens == null)
          {
              return NotFound();
          }
            return mensagens;
        }

        // POST: api/Mensagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mensagem>> CreateMensagem(MensagemView mensagemView)
        {
            Mensagem mensagem = new Mensagem(mensagemView.Msg, mensagemView.IdUser);

            _mensagem.CreateMensagem(mensagem);

            return Ok(mensagem);
        }
    }
}
