namespace SimpleCrudApp.models{

  public class Products
    {
        public int Id { get; set; }  // ID do Produto
        public string NomeUser { get; set; } = string.Empty;  // Nome do Usuário
        public string ProdutoNome { get; set; } = string.Empty;   // Nome do Produto
        public string Descricao { get; set; } = string.Empty;  // Descrição do Produto
        public string Imagem { get; set; } = string.Empty;  // Imagem do Produto
        public decimal Preco { get; set; } = 0;  // Preço do Produto
        public decimal  Quantidade { get; set; } = 0;  // Quantidade do Produto
        public string Valor { get; set; } = "0,0";
    }
}