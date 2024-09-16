using Gymotivate.Data;
using Gymotivate.Models;

namespace Gymotivate.Repositorio
{
    public class AcertosRepositorio : IAcertosRepositorio
    {
        private readonly BancoContext _context;
        private readonly ICadastreRepositorio _cadastreoRepositorio;

        public AcertosRepositorio(BancoContext context, ICadastreRepositorio cadastreoRepositorio)
        {
            _context = context;
            _cadastreoRepositorio = cadastreoRepositorio;
        }

        public GamesModel ObterAcertosDoUsuario(int userId)
        {
            return _context.Acertos.FirstOrDefault(a => a.Usuario.Id == userId);
        }

        public GamesModel CriarRegistroPadrao(int userId)
        {
            CadastreModel usuario = _cadastreoRepositorio.BuscarPorId(userId);

            var novoRegistro = new GamesModel
            {
                Usuario = usuario,
                AcertosPeitos = 0,
                AcertosCostas = 0,
                AcertosPernas = 0,
                AcertosBracos = 0
            };

            _context.Acertos.Add(novoRegistro);
            _context.SaveChanges();

            return novoRegistro;
        }
    }
}
