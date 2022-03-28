using System.ComponentModel.DataAnnotations;
using WebSiteProdutos.Models;

namespace WebSiteProdutos.ViewModel
{
    public class ProdutoViewModel : ProdutoModel
    {     
        public List<TipoProduto> TipoProdutos { get; set; }

        public ProdutoModel ObjProduto { get; set; }

        public string TIPO { get; set; }

    }
}
