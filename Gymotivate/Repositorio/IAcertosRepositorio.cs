using Gymotivate.Models;

namespace Gymotivate.Repositorio
{
    public interface IAcertosRepositorio
    {
        GamesModel ObterAcertosDoUsuario(int userId);
        GamesModel CriarRegistroPadrao(int userId);

    }
}
