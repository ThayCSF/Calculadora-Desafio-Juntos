using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.ProductSystem
{
    [Table("Operacoes")]
    public class Operacao
    {
        public Operacao()
        {
            Id = Id++;
        }
        public int Id { get; private set; }
        public int IdProduto { get; set; }
        public int IdFormaPagamento { get; set; }
        public decimal ValorCalculo { get; set; }
        public DateTime DataRealizacao { get; set; }

        
    }
}
