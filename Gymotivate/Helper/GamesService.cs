using Gymotivate.Data;
using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Helper
{
    public class GamesService : IGamesService
    {
        private readonly BancoContext _context;

        public GamesService(BancoContext context)
        {
            _context = context;
        }

        public void AtualizarAcertos(CadastreModel usuario, string grupoPerguntas, int acertos)
        {
            var acertosModel = _context.Acertos.FirstOrDefault(g => g.Usuario.Id == usuario.Id);

            if (acertosModel == null)
            {
                acertosModel = new GamesModel
                {
                    Usuario = usuario
                };
            }

            // Atualize os acertos com base no grupo de perguntas
            switch (grupoPerguntas)
            {
                case "peitos":
                    acertosModel.AcertosPeitos += acertos;
                    break;
                case "costas":
                    acertosModel.AcertosCostas += acertos;
                    break;
                case "pernas":
                    acertosModel.AcertosPernas += acertos;
                    break;
                case "bracos":
                    acertosModel.AcertosBracos += acertos;
                    break;
                default:
                    // Grupo de perguntas desconhecido
                    break;
            }

            if (acertosModel.GamesId == 0)
            {
                _context.Acertos.Add(acertosModel);
            }
            else
            {
                _context.Acertos.Update(acertosModel);
            }

            _context.SaveChanges();
        }
    }
}
