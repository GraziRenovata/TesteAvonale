using System.Collections.Generic;
using System.Linq;
using ApiWeb.Models;

namespace WebApi.Contracts.Models.Produtos
{
    public class ProdutoSimplificado
    {
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }

        public Produto ProdutoSimplificadoParaProduto()
        {
            var produto = new Produto
            {
                Nome = this.Nome,
                ValorUnitario = this.ValorUnitario,
                QtdEstoque = this.QtdEstoque
            };

            return produto;
        }
        public static ProdutoSimplificado ProdutoParaProdutoSimplificado(Produto produto)
        {
            var produtoSimplificado = new ProdutoSimplificado
            {
                Nome = produto.Nome,
                ValorUnitario = produto.ValorUnitario,
                QtdEstoque = produto.QtdEstoque
            };

            return produtoSimplificado;
        }

        public static List<ProdutoSimplificado> ProdutoParaProdutoSimplificado(List<Produto> produtos)
        {
            var produtosSimplificado = produtos.Select(p => ProdutoParaProdutoSimplificado(p)).ToList();
            return produtosSimplificado;
        }
    }
}