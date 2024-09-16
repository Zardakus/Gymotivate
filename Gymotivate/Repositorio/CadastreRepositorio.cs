using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;

namespace Gymotivate.Repositorio
{
    public class CadastreRepositorio : ICadastreRepositorio
    {
        private readonly BancoContext _context;
        public CadastreRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public CadastreModel Adicionar(CadastreModel cadastre)
        {
            _context.Cadastre.Add(cadastre);
            _context.SaveChanges();

            return cadastre;
        }

        public List<CadastreModel> BuscarTodos(int usuarioId)
        {
            return _context.Cadastre.Where(x => x.Id == usuarioId).ToList();
        }

        public CadastreModel BuscarPorId(int id)
        {
            return _context.Cadastre.FirstOrDefault(x => x.Id == id);
        }

        public CadastreModel BuscarPorLogin(string username)
        {
            return _context.Cadastre.FirstOrDefault(x => x.Name.ToUpper() == username.ToUpper());
        }
    }
}
