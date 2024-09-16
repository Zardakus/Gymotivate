using Gymotivate.Data;
using Gymotivate.Helper;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gymotivate.Controllers
{
    public class LoginController : Controller
    {
        private readonly BancoContext _context;
        private readonly ICadastreRepositorio _cadastreoRepositorio;
        private readonly ISessao _sessao;
        private readonly IConquistaService _conquistaService;

        public LoginController(BancoContext context,
                               ICadastreRepositorio cadastreoRepositorio,
                               ISessao sessao,
                               IConquistaService conquistaService)
        {
            _context = context;
            _cadastreoRepositorio = cadastreoRepositorio;
            _sessao = sessao;
            _conquistaService = conquistaService;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index", "Login");
        }


        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CadastreModel usuario = _cadastreoRepositorio.BuscarPorLogin(login.Name);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);

                            // Verifique se o usuário possui registros na tabela Conquistas.
                            // Você não precisa do _context aqui se já configurou a injeção de dependência corretamente.

                            bool usuarioPossuiConquistas = _conquistaService.UsuarioPossuiConquistas(usuario.Id);                           

                            if (!usuarioPossuiConquistas)
                            {
                                // O usuário não possui registros, vamos inserir as conquistas.
                                // Você não precisa do _context aqui para buscar as conquistas.

                                var conquistasName = _conquistaService.ObterTodasConquistasName();

                                foreach (var conquistaName in conquistasName)
                                {
                                    var novaConquista = new ConquistasModel
                                    {
                                        Usuario = usuario,
                                        NameConquistas = conquistaName,
                                        PossuiConquista = false
                                    };

                                    _conquistaService.AdicionarConquista(novaConquista);
                                }
                            }                           

                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Senha inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = "Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o seu login: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
