using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.ProductSystem
{
    [Table("FormasPagamento")]
    public class FormaPagamento
    {
        public int Id { get; set; }
        public string TipoPagamento { get; set; }
    }

}
