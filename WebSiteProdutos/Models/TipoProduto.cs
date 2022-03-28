using System.ComponentModel.DataAnnotations;

namespace WebSiteProdutos.Models
{
    public class TipoProduto
    {
        [Key]
        public int CODTIPO { get; set; }
        public string TIPO { get; set; }
    }
}
