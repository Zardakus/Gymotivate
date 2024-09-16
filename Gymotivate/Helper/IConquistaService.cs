using Gymotivate.Models;

namespace Gymotivate.Helper
{
    public interface IConquistaService
    {
        bool UsuarioPossuiConquistas(int usuarioId);

        List<NameConquistasModel> ObterTodasConquistasName();

        void AdicionarConquista(ConquistasModel conquista);
    }
}
