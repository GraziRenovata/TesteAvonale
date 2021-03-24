using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWeb.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }
        public DateTime? DataUltimaVenda { get; private set; }
        public decimal? ValorUltimaVenda {get; private set; }

        public void SetValorUltimaVenda(decimal valorUltimaVenda)
        {
            this.ValorUltimaVenda = valorUltimaVenda;
        }

        public void SetDataUltimaVenda(DateTime dataUltimaVenda)
        {
            this.DataUltimaVenda = dataUltimaVenda;
        }
    }
}