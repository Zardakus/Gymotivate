using Gymotivate.Helper;
using Gymotivate.Migrations;
using Gymotivate.Models;

namespace Gymotivate.Repositorio
{
    public interface ITreinoRepositorio
    {
        TreinoModel CriarNovoTreino(int userId, string nomeTreino);
        void SalvaDiasSemanaDoTreino(int treinoId, Dictionary<string, List<string>> exerciciosPorDia);
        List<TreinoModel> ObterTreinosDoUsuario(int userId);
    }
}