using Gymotivate.Data;
using Gymotivate.Models;
using Gymotivate.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Gymotivate.Controllers
{
    public class CadastreController : Controller
    {
        private readonly ICadastreRepositorio _cadastreRepositorio;
        public CadastreController(ICadastreRepositorio cadastreRepositorio, BancoContext context)
        {
            _cadastreRepositorio = cadastreRepositorio;
        }

        //Leva para tela de cadastro
        public IActionResult Cadastrar()
        {
            return View();
        }


        //Post \/

        //Cadastra uma pessoa
        [HttpPost]
        public IActionResult Cadastrar(CadastreModel cadastre)
        {
            if (ModelState.IsValid)
            {
                // Verifique se o nome de usuário já existe
                var existingUser = _cadastreRepositorio.BuscarPorLogin(cadastre.Name);

                if (existingUser != null)
                {
                    ModelState.AddModelError("Name", "Nome de usuário já existe.");
                    return View(cadastre);
                }

                _cadastreRepositorio.Adicionar(cadastre);
                return RedirectToAction("Index", "Login");
            }

            return View(cadastre);
        }
    }
}
