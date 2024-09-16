using Gymotivate.Models;

namespace Gymotivate.Repositorio
{
    public interface ICadastreRepositorio
    {
        CadastreModel BuscarPorLogin(string username);
        CadastreModel BuscarPorId(int id);
        List<CadastreModel> BuscarTodos(int usuarioId);
        CadastreModel Adicionar(CadastreModel cadastre);
    }
}
