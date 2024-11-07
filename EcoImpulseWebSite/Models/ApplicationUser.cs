using Microsoft.AspNetCore.Identity;

namespace EcoImpulseWebSite.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //PARA TODOS
        public string? Foto { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }

        //PARA PESSOAL
        public string? CPF { get; set; }

        //PARA EMPRESA
        public string? Sobre { get; set; }
        public string? CNPJ { get; set; }

        public IEnumerable<Produto>? Produto { get; set; }
        public IEnumerable<Carrinho>? Carrinho { get; set; }

    }
}
