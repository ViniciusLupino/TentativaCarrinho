namespace EcoImpulseWebSite.Models
{
    public class CategoriaProduto
    {
        public Guid IdCategoriaProduto { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Produto>? Produto { get; set; }


    }
}
