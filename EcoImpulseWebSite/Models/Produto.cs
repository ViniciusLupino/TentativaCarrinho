namespace EcoImpulseWebSite.Models
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set;}
        public double Preco { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }

        public Guid CategoriaId { get; set; }
        public CategoriaProduto? Categoria { get; set;}

        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }


        public IEnumerable<Carrinho>? Carrinho { get; set; }

    }
}
