using Gymotivate.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Gymotivate.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public CadastreModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("SessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<CadastreModel>(sessaoUsuario);
        }   

        public void CriarSessaoDoUsuario(CadastreModel cadastre)
        {
            string valor = JsonConvert.SerializeObject(cadastre);
            _httpContext.HttpContext.Session.SetString("SessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }
    }
}
