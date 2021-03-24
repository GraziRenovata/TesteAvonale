using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiWeb.Models
{
    public class Compra
    {
        [Key]
        public int CompraId {get; set;}
        public int ProdutoId {get; set;}
        public Produto Produto {get; set;}
        public int QtdComprada {get; set;}
        public Cartao Cartao {get; set;}
    }
}