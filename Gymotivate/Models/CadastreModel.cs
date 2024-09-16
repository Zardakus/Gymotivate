using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Gymotivate.Models
{
    public class CadastreModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o seu nome de Usuário")]
        [Remote("IsUsernameAvailable", "Cadastre", ErrorMessage = "Este nome de usuário já está em uso.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o seu e-mail de Usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a sua senha")]
        public string Senha { get; set; }

        public virtual List<ConquistasModel>? Conquistas { get; set; }

        public virtual List<GamesModel>? Games { get; set; }

        public virtual List<TreinoModel>? Treino { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
