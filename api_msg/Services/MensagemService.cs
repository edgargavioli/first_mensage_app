using api_msg.Context;
using api_msg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_msg.Services
{
    public class MensagemService
    {
        private readonly ApiContext _context;

        public MensagemService(ApiContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagems()
        {
            return await _context.Mensagems.ToListAsync();
        }

        public void CreateMensagem(Mensagem newMensagem)
        {
            _context.Mensagems.Add(newMensagem);
            _context.SaveChanges();
        }
    }
}
