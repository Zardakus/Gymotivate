using System.ComponentModel.DataAnnotations;

namespace Gymotivate.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Usuário correto")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite a Senha correta")]
        public string Senha { get; set; }
    }
}
