using System.Data.Entity;

namespace Calculator.ProductSystem
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext() : base("CalculatorProductDb")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
    }
}
