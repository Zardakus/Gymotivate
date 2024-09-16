using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Gymotivate.Controllers
{
    public class TreinosController : Controller
    {
        private readonly BancoContext _context;
        private readonly ICadastreRepositorio _cadastreoRepositorio;
        private readonly ISessao _sessao;
        private readonly ITreinoRepositorio _treinoRepositorio;

        public TreinosController(BancoContext context, 
                                 ICadastreRepositorio cadastreoRepositorio, 
                                 ISessao sessao,
                                 ITreinoRepositorio treinoRepositorio)
        {
            _context = context;
            _cadastreoRepositorio = cadastreoRepositorio;
            _sessao = sessao;
            _treinoRepositorio = treinoRepositorio;
        }

        public IActionResult Index()
        {
            // Recupere a lista de exercícios do banco de dados
            List<ExercicioModel> exercicios = _context.Exercicio.ToList();

            return View(exercicios);
        }
        
        public IActionResult TipoFicha()
        {
            return View();
        }

        public IActionResult FichaPadrao()
        {
            return View();
        }

        public IActionResult MinhasFichas()
        {
            // Verifica se o usuário está logado
            CadastreModel usuario = _sessao.BuscarSessaoUsuario();
            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Use o método do repositório para buscar os treinos do usuário.
            var treinos = _treinoRepositorio.ObterTreinosDoUsuario(usuario.Id);


            // Passe a lista de treinos para a view usando ViewBag
            ViewBag.Treinos = treinos;

            // Retorne os treinos para a view ou faça o que for necessário com eles.
            return View();
        }

        [HttpPost]
        public IActionResult SalvarTreino(string nomeTreino, [FromForm] string exerciciosPorDia)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o usuário está logado
                CadastreModel usuario = _sessao.BuscarSessaoUsuario();
                if (usuario == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                TreinoModel treino = _treinoRepositorio.CriarNovoTreino(usuario.Id, nomeTreino);

                // Você pode converter a string JSON em objetos C# aqui
                // Exemplo de conversão de JSON para dicionário:
                Dictionary<string, List<string>> exercicios =
                    JsonSerializer.Deserialize<Dictionary<string, List<string>>>(exerciciosPorDia);

                // Agora, chame o método SalvaDiasSemanaDoTreino para salvar os exercícios por dia
                _treinoRepositorio.SalvaDiasSemanaDoTreino(treino.TreinoId, exercicios);

                TempData["MensagemSucesso"] = "Treino salvo com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao salvar o treino. Verifique os dados informados.";
            }

            return RedirectToAction("Index");
        }
    }
}
