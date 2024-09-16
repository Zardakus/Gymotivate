using Gymotivate.Data;
using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Helper
{
    public class ConquistaService : IConquistaService
    {
        private readonly BancoContext _context;

        public ConquistaService(BancoContext context)
        {
            _context = context;
        }

        public bool UsuarioPossuiConquistas(int usuarioId)
        {
            return _context.Conquistas.Any(c => c.Usuario.Id == usuarioId);
        }

        public List<NameConquistasModel> ObterTodasConquistasName()
        {
            return _context.NameConquistas.ToList();
        }

        public void AdicionarConquista(ConquistasModel conquista)
        {
            _context.Conquistas.Add(conquista);
            _context.SaveChanges();
        }
    }
}
