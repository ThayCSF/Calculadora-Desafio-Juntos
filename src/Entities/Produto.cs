
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.ProductSystem
{
    [Table("Produtos")]
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }

    }
}
