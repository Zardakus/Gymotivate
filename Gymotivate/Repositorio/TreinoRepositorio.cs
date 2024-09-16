using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Repositorio
{
    public class TreinoRepositorio : ITreinoRepositorio
    {
        private readonly BancoContext _context;
        private readonly ICadastreRepositorio _cadastreoRepositorio;

        public TreinoRepositorio(BancoContext context, ICadastreRepositorio cadastreoRepositorio)
        {
            _context = context;
            _cadastreoRepositorio = cadastreoRepositorio;
        }

        public TreinoModel CriarNovoTreino(int userId, string nomeTreino)
        {
            CadastreModel usuario = _cadastreoRepositorio.BuscarPorId(userId);

            var novoTreino = new TreinoModel
            {
                User = usuario,
                Nome = nomeTreino
            };

            _context.Treino.Add(novoTreino);
            _context.SaveChanges();

            return novoTreino;
        }

        public void SalvaDiasSemanaDoTreino(int treinoId, Dictionary<string, List<string>> exerciciosPorDia)
        {
            // Consulta o treino pelo TreinoId
            var treino = _context.Treino
                .Include(t => t.TreinoDiaSemana)
                .ThenInclude(ts => ts.TreinoExercicio)
                .FirstOrDefault(t => t.TreinoId == treinoId);

            if (treino == null)
            {
                throw new InvalidOperationException("Treino não encontrado");
            }

            // Itera pelos dias da semana (segunda, terça, etc.)
            foreach (var diaSemana in exerciciosPorDia.Keys)
            {
                // Verifica se o dia da semana já existe no treino, caso contrário, cria um novo
                var treinoDiaSemana = treino.TreinoDiaSemana.FirstOrDefault(ts => ts.DiaSemana == diaSemana);

                if (treinoDiaSemana == null)
                {
                    treinoDiaSemana = new TreinoDiaSemanaModel
                    {
                        Treino = treino,
                        DiaSemana = diaSemana
                    };
                    treino.TreinoDiaSemana.Add(treinoDiaSemana);
                }

                // Itera pelos exercícios associados ao dia da semana
                foreach (var exercicioId in exerciciosPorDia[diaSemana])
                {
                    // Consulta o exercício pelo Id
                    var exercicio = _context.Exercicio.FirstOrDefault(e => e.Nome == exercicioId);

                    if (exercicio != null)
                    {
                        // Adiciona o exercício ao dia da semana do treino
                        var TreinoExercicio = new TreinoExercicioModel
                        {
                            TreinoDiaSemana = treinoDiaSemana,
                            Exercicio = exercicio                           
                        };
                        _context.TreinoExercicio.Add(TreinoExercicio);
                    }
                }                
            }
            // Salva as alterações no banco de dados
            _context.SaveChanges();
        }

        public List<TreinoModel> ObterTreinosDoUsuario(int userId)
        {
            // Consulta a tabela de Treino e filtra os resultados pelo ID do usuário logado.
            var treinosDoUsuario = _context.Treino
                .Where(t => t.User.Id == userId)
                .ToList();

            // Para cada treino, carregue as informações de TreinoDiaSemana.
            foreach (var treino in treinosDoUsuario)
            {
                _context.Entry(treino)
                    .Collection(t => t.TreinoDiaSemana)
                    .Load();

                // Para cada TreinoDiaSemana, carregue os exercícios da tabela TreinoExercicio.
                foreach (var treinoDiaSemana in treino.TreinoDiaSemana)
                {
                    _context.Entry(treinoDiaSemana)
                        .Collection(ts => ts.TreinoExercicio)
                        .Load();

                    // Para cada TreinoExercicio, armazene os valores da coluna ExercicioId.
                    foreach (var treinoExercicio in treinoDiaSemana.TreinoExercicio)
                    {
                        _context.Entry(treinoExercicio)
                            .Reference(te => te.Exercicio)
                            .Load();
                    }
                }
            }

            return treinosDoUsuario;
        }
    }
}