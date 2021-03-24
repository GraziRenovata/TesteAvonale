using System.ComponentModel.DataAnnotations;

namespace ApiWeb.Models
{
    public class Cartao
    {
        [Key]
        public int CartaoId {get; set;}
        [CreditCard(ErrorMessage = "Cartão de Crédito Invalido")]
        public string Titular {get; set;}
        public string Numero {get; set;}
        public string DataExpiracao { get; set; }
        public string Bandeira { get; set; }
        public string Cvv {get; set;}
    }
}