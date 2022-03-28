using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSiteProdutos.Data;
using WebSiteProdutos.Models;
using WebSiteProdutos.ViewModel;

namespace WebSiteProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly DBDados _DBDados;

        public ProdutoController(DBDados dBDados)
        {
            _DBDados = dBDados;
        }

        public IActionResult Index()
        {
            //Aqui ele puxa do banco os dados dos produtos.
            var produtos = (from produto in _DBDados.TBPRODUTOS
                            join tipo in _DBDados.TBTIPOPRODUTO
                            on produto.CODTIPO equals tipo.CODTIPO
                            select new
                            {
                                CODPRODUTO = produto.CODPRODUTO,
                                NOME = produto.NOME,
                                PRECO = produto.PRECO,
                                QUANTIDADE = produto.QUANTIDADE,
                                TIPO = tipo.TIPO
                            }).ToList();

            return View(produtos);
        }

        public IActionResult CadastroProduto()
        {
            ProdutoViewModel objPVM = new ProdutoViewModel();

            objPVM.TipoProdutos = _DBDados.TBTIPOPRODUTO.ToList();

            return View(objPVM);
        }

        public IActionResult EditarProduto(int id)
        {
            //Puxa pelos dados do produto
            var produtos = (from produto in _DBDados.TBPRODUTOS
                            join tipo in _DBDados.TBTIPOPRODUTO
                            on produto.CODTIPO equals tipo.CODTIPO
                            where produto.CODPRODUTO == id
                            select new
                            {
                                CODPRODUTO = produto.CODPRODUTO,
                                NOME = produto.NOME,
                                PRECO = produto.PRECO,
                                QUANTIDADE = produto.QUANTIDADE,
                                TIPO = tipo.TIPO,
                                CODTIPO = tipo.CODTIPO
                            }).ToList();

            ProdutoViewModel objPVM = new ProdutoViewModel();

            foreach (var item in produtos)
            {
                objPVM.CODPRODUTO = item.CODPRODUTO;
                objPVM.NOME = item.NOME;
                objPVM.PRECO = item.PRECO;
                objPVM.QUANTIDADE = item.QUANTIDADE;
                objPVM.CODTIPO = item.CODTIPO;
                objPVM.TIPO = item.TIPO;
            }

            //Puxa pelos dados do tipos de produtos, para serem preenchidos no campo tipo
            objPVM.TipoProdutos = _DBDados.TBTIPOPRODUTO.ToList();
            

            return View(objPVM);
        }

        [HttpPost]
        public IActionResult CadastroProduto(ProdutoViewModel objProduto)
        {
            try
            {
                ProdutoModel objPM = new ProdutoModel();
                objPM.CODPRODUTO = objProduto.CODPRODUTO;
                objPM.NOME = objProduto.NOME;
                objPM.PRECO = objProduto.PRECO;
                objPM.QUANTIDADE = objProduto.QUANTIDADE;
                objPM.CODTIPO = objProduto.CODTIPO;

                //if (ModelState.IsValid)
                //{
                _DBDados.TBPRODUTOS.Add(objPM);
                _DBDados.SaveChanges();

                return RedirectToAction("Index");
                //}

                //return View(objProduto);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public IActionResult EditarProduto(ProdutoViewModel objProduto)
        {
            try
            {
                ProdutoModel objPM = new ProdutoModel();

                objPM.CODPRODUTO = objProduto.CODPRODUTO;
                objPM.NOME = objProduto.NOME;
                objPM.PRECO = objProduto.PRECO;
                objPM.QUANTIDADE = objProduto.QUANTIDADE;


                _DBDados.TBPRODUTOS.Update(objProduto);
                _DBDados.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            
        }

        [HttpPost]
        public IActionResult ExcluirProduto(int id)
        {
            try
            {
                ProdutoModel objPM = _DBDados.TBPRODUTOS.Find(id);

                _DBDados.TBPRODUTOS.Remove(objPM);
                _DBDados.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            try
            {
                ProdutoModel objPM = _DBDados.TBPRODUTOS.Find(id);

                _DBDados.TBPRODUTOS.Remove(objPM);
                _DBDados.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
            
        }

        public IActionResult TipoProduto()
        {
            ProdutoViewModel objPVM = new ProdutoViewModel();

            objPVM.TipoProdutos = _DBDados.TBTIPOPRODUTO.ToList();

            return View(objPVM);
        }

        [HttpPost]
        public IActionResult TipoProduto(int id)
        {
            try
            {
                TipoProduto objTipoProduto = _DBDados.TBTIPOPRODUTO.Find(id);

                _DBDados.TBTIPOPRODUTO.Remove(objTipoProduto);
                _DBDados.SaveChanges();

                return RedirectToAction("TipoProduto");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }


        }

        public IActionResult CadastroTipoProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroTipoProduto(ProdutoViewModel objPVM)
        {
            try
            {
                TipoProduto tipo = new TipoProduto();

                tipo.TIPO = objPVM.TIPO;

                //if (ModelState.IsValid)
                //{
                _DBDados.TBTIPOPRODUTO.Add(tipo);
                _DBDados.SaveChanges();

                return RedirectToAction("TipoProduto");
                //}

                //return View(objProduto);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
