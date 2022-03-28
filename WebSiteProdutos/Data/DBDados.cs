using Microsoft.EntityFrameworkCore;
using WebSiteProdutos.Models;

namespace WebSiteProdutos.Data
{
    public class DBDados : DbContext
    {
        //Utilizado apenas na comunicação com o banco, se um dia for add mais uma tabela no banco, é preciso utilizar o migrations
        public DBDados(DbContextOptions<DBDados> dbContextOptions) : base(dbContextOptions)
        {

        }

        //Diz para o sistema o nome da tabela no banco
        public DbSet<ProdutoModel> TBPRODUTOS { get; set; }

        public DbSet<TipoProduto> TBTIPOPRODUTO { get; set; } 
    }
}
