using Gymotivate.Models;

namespace Gymotivate.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(CadastreModel cadastre);

        void RemoverSessaoDoUsuario();

        CadastreModel BuscarSessaoUsuario();
    }
}
