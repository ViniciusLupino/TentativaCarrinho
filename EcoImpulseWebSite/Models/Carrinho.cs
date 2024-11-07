namespace EcoImpulseWebSite.Models
{
    public class Carrinho
    {
        public Guid IdCarrinho { get; set; }
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public List<Guid>? ProdutosId { get; set;}

    }
}
