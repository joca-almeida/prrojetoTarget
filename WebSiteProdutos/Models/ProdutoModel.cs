using System.ComponentModel.DataAnnotations;

namespace WebSiteProdutos.Models
{
    public class ProdutoModel
    {
        [Key]
        public int CODPRODUTO { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string NOME { get; set; }
        [Required(ErrorMessage = "Informe o precço do produto.")]
        public double PRECO { get; set; }
        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int QUANTIDADE { get; set; }
        [Required(ErrorMessage = "Informe o tipo do produto.")]
        public int CODTIPO { get; set; }
        //public string TIPO { get; set; }

    }
}
