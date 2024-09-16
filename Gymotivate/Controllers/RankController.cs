using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Controllers
{
    public class RankController : Controller
    {
        private readonly BancoContext _context;
        private readonly ICadastreRepositorio _cadastreRepositorio;

        public RankController(BancoContext context,
                              ICadastreRepositorio cadastreRepositorio)
        {
            _context = context;
            _cadastreRepositorio = cadastreRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var highestScoringUser = await GetTopScoringUsersAsync();

            return View(highestScoringUser);
        }

        private async Task<List<RankModel>> GetTopScoringUsersAsync()
        {
            // Consulta SQL para obter os 10 usuários com a maior soma de acertos
            string sqlQuery = "SELECT Cadastre.Id, Cadastre.Name, " +
                              "SUM(Games.AcertosPeitos + Games.AcertosCostas + Games.AcertosPernas + Games.AcertosBracos) AS TotalAcertos, " +
                              "SUM(CASE WHEN Conquistas.PossuiConquista = 1 THEN 1 ELSE 0 END) AS Conquistas " +
                              "FROM Cadastre " +
                              "JOIN Games ON Cadastre.Id = Games.UsuarioId " +
                              "LEFT JOIN Conquistas ON Cadastre.Id = Conquistas.UsuarioId " +
                              "GROUP BY Cadastre.Id, Cadastre.Name " +
                              "ORDER BY TotalAcertos DESC " +
                              "LIMIT 10";

            // Execute a consulta SQL usando o Entity Framework
            var results = await _context.Cadastre
                .Include(c => c.Games)
                .Include(c => c.Conquistas)
                .OrderByDescending(c => c.Games.Sum(g => g.AcertosPeitos + g.AcertosCostas + g.AcertosPernas + g.AcertosBracos))
                .Take(10)
                .ToListAsync();

            var rankModels = new List<RankModel>();

            foreach (var result in results)
            {
                int userId = result.Id;

                int totalExp = CalculateTotalExp(userId);

                rankModels.Add(new RankModel
                {
                    UserId = userId,
                    UserName = result.Name,
                    HighestScore = result.Games.Sum(g => g.AcertosPeitos + g.AcertosCostas + g.AcertosPernas + g.AcertosBracos),
                    Conquistas = result.Conquistas.Count(c => c.PossuiConquista),
                    TotalExp = totalExp
                });
            }

            return rankModels;
        }

        private int CalculateTotalExp(int userId)
        {
            int totalExp = 0;

            totalExp += CalculateExpGroup(_context.NameConquistas, _context.Conquistas, userId, 1);
            totalExp += CalculateExpGroup(_context.NameConquistas, _context.Conquistas, userId, 2);
            totalExp += CalculateExpGroup(_context.NameConquistas, _context.Conquistas, userId, 3);
            totalExp += CalculateExpGroup(_context.NameConquistas, _context.Conquistas, userId, 4);

            return totalExp;
        }

        private int CalculateExpGroup(DbSet<NameConquistasModel> nameConquistas, DbSet<ConquistasModel> conquistas, int userId, int idGrupo)
        {
            int exp = 0;

            for (int tier = 1; tier <= 4; tier++)
            {
                int idConquista = nameConquistas
                    .Where(nc => nc.GrupoConquistas.GroupId == idGrupo && nc.Tier == tier)
                    .Select(nc => nc.NameConquistasId)
                    .FirstOrDefault();

                if (idConquista != 0)
                {
                    ConquistasModel conquista = conquistas
                        .Where(c => c.Usuario.Id == userId && c.NameConquistas.NameConquistasId == idConquista)
                        .FirstOrDefault();
                    if (conquista.PossuiConquista)
                    {
                        exp += nameConquistas
                            .Where(nc => nc.GrupoConquistas.GroupId == idGrupo && nc.Tier == tier)
                            .Select(nc => nc.ConquistaExp)
                            .FirstOrDefault();
                    }
                }
            }

            return exp;
        }

    }
}
