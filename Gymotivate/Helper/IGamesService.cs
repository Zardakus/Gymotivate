using Gymotivate.Models;

namespace Gymotivate.Helper
{
    public interface IGamesService
    {
        void AtualizarAcertos(CadastreModel usuario, string grupoPerguntas, int acertos);
    }
}
