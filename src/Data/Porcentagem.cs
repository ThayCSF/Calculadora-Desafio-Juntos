using System;
using System.Linq;

namespace Calculator.ProductSystem
{
    public class Porcentagem
    {
        public decimal ValorCalculado { get; set; }
        public void CalculoPorcentagem(CalculatorContext context, int id, decimal porcentagem, string tipoOperacao)
        {
            var produtos = context.Produtos;

            var valorProduto = produtos.Single(p => p.Id == id);

            if (tipoOperacao == "desconto")
            {
                valorProduto.ValorUnitario = valorProduto.ValorUnitario - (valorProduto.ValorUnitario * porcentagem);
                ValorCalculado = valorProduto.ValorUnitario;
                Console.WriteLine($"Foi implementado um desconto de {(porcentagem * 100).ToString("#m##.##")}%.\n" +
                    $"O valor atualizado é  R${ValorCalculado.ToString("###.##")}");
            }
            else
            {
                valorProduto.ValorUnitario = valorProduto.ValorUnitario + (valorProduto.ValorUnitario * porcentagem);
                ValorCalculado = valorProduto.ValorUnitario;
                Console.WriteLine($"Foi implementado um acréscimo de {(porcentagem * 100).ToString("###.##")}%.\n" +
                    $"O valor atualizado é  R${ValorCalculado.ToString("###.##")}");
            }

            Console.WriteLine("Obrigada por usar nossa calculadora. Volte sempre!!");
        }
    }
}
