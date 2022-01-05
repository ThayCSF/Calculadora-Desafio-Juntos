using System;
using System.Linq;

namespace Calculator.ProductSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalculatorContext _context = new CalculatorContext();

        //************************Cadastro produtos**************************************

        /*var cimento = new Produto
        {
            Id = 1,
            Nome = "Cimento",
            ValorUnitario = Convert.ToDecimal("10,50")
        };
        _context.Produtos.Add(cimento);
        _context.SaveChanges();

        var tubos = new Produto
        {
            Id = 2,
            Nome = "Tubos e conexões",
            ValorUnitario = Convert.ToDecimal("5,00")
        };
        _context.Produtos.Add(tubos);
        _context.SaveChanges();

        var vigas = new Produto
        {
            Id = 3,
            Nome = "Vigas de aço",
            ValorUnitario = Convert.ToDecimal("100,40")
        };
        _context.Produtos.Add(vigas);
        _context.SaveChanges();*/
        //************************Cadastro formas de pagamento**************************************
        /* var boleto = new FormaPagamento
         {
             Id = 1,
             TipoPagamento = "Boleto"
         };
         _context.FormasPagamento.Add(boleto);
         _context.SaveChanges();

         var credito = new FormaPagamento
         {
             Id = 2,
             TipoPagamento = "Cartão de crédito"
         };
         _context.FormasPagamento.Add(credito);
         _context.SaveChanges();

         var cartaoJuntos = new FormaPagamento
         {
             Id = 3,
             TipoPagamento = "Cartão Juntos Somos Mais"
         };
         _context.FormasPagamento.Add(cartaoJuntos);
         _context.SaveChanges();

         var pix = new FormaPagamento
         {
             Id = 4,
             TipoPagamento = "Pix"
         };
         _context.FormasPagamento.Add(pix);
         _context.SaveChanges();*/
        //**************************************************************

        start:

            Console.Clear();

            Console.WriteLine("Bem vinde à Calculadora de Produtos!");
            Console.WriteLine("A seguir, estão os produtos cadastrados. " +
                "Selecione o produto que deseja calcular, digitando o seu código:");

            _context.Produtos.ToList().ForEach
                (p => Console.WriteLine($"CÓDIGO => {p.Id} - PRODUTO => {p.Nome} - VALOR UNITÁRIO => {p.ValorUnitario}"));

            var selecaoProduto = Console.ReadLine();

            if (selecaoProduto.Trim() != "1" && selecaoProduto.Trim() != "2" && selecaoProduto.Trim() != "3")
            {
            validation1:

                Console.WriteLine("Valor incorreto. Deseja digitar novamente? (Digite sim ou não)");
                var escolha = Console.ReadLine();

                if (escolha.ToLower().Trim() == "sim")
                {
                    goto start;
                }
                else if (escolha.ToLower().Trim() == "não")
                {
                    Console.WriteLine("Obrigada por usar nossa calculadora. Volte sempre!!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    goto validation1;
                }
            }

        operation:

            Console.Clear();

            Console.WriteLine("Agora, selecione o que deseja fazer a seguir, digitando o código correspondente:\n");
            Console.WriteLine("Digite 1 caso queira calcular o valor de um novo produto por forma de pagamento.");
            Console.WriteLine("Digite 2 caso queira listar os últimos valores calculados do produto selecionado.");

            var selecaoOperacao = Console.ReadLine();

            if (selecaoOperacao.Trim() != "1" && selecaoOperacao.Trim() != "2")
            {
            validation2:

                Console.WriteLine("Valor incorreto. Deseja digitar novamente? (Digite sim ou não)");

                var escolha = Console.ReadLine();

                if (escolha.ToLower().Trim() == "sim")
                {
                    goto operation;
                }
                else if (escolha.ToLower().Trim() == "não")
                {
                    Console.WriteLine("Obrigada por usar nossa calculadora. Volte sempre!!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else
                {
                    goto validation2;
                }
            }

            if (selecaoOperacao.Trim() == "1")
            {
            payment:

                Console.Clear();

                Console.WriteLine("Selecione a forma de pagamento que deseja consultar, digitando o seu código:");

                _context.FormasPagamento.ToList().ForEach
               (f => Console.WriteLine($"CÓDIGO => {f.Id} - FORMA DE PAGAMENTO => {f.TipoPagamento}"));

                var selecaoPagamento = Console.ReadLine();

                if (selecaoPagamento.Trim() != "1" && selecaoPagamento.Trim() != "2" &&
                    selecaoPagamento.Trim() != "3" && selecaoPagamento.Trim() != "4")
                {
                validation3:

                    Console.WriteLine("Valor incorreto. Deseja digitar novamente? (Digite sim ou não)");

                    var escolha = Console.ReadLine();

                    if (escolha.ToLower().Trim() == "sim")
                    {
                        goto payment;
                    }
                    else if (escolha.ToLower().Trim() == "não")
                    {
                        Console.WriteLine("Obrigada por usar nossa calculadora. Volte sempre!!");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        goto validation3;
                    }
                }

                Porcentagem porcentagem = new Porcentagem();

                switch (Convert.ToInt32(selecaoPagamento))
                {
                    case 1:
                        porcentagem.CalculoPorcentagem(_context, Convert.ToInt32(selecaoProduto), 0.008M, "desconto");
                        break;
                    case 2:
                        porcentagem.CalculoPorcentagem(_context, Convert.ToInt32(selecaoProduto), 0.03M, "acréscimo");
                        break;
                    case 3:
                        porcentagem.CalculoPorcentagem(_context, Convert.ToInt32(selecaoProduto), 0.03M, "desconto");
                        break;
                    case 4:
                        porcentagem.CalculoPorcentagem(_context, Convert.ToInt32(selecaoProduto), 0.015M, "desconto");
                        break;
                }

                Operacao operacao = new Operacao
                {
                    IdProduto = Convert.ToInt32(selecaoProduto),
                    IdFormaPagamento = Convert.ToInt32(selecaoPagamento),
                    ValorCalculo = porcentagem.ValorCalculado,
                    DataRealizacao = DateTime.Now
                };
                _context.Operacoes.Add(operacao);
                _context.SaveChanges();

            }
            else if (selecaoOperacao.Trim() == "2")
            {
                var historico = _context.Operacoes.Single(p => p.IdProduto == Convert.ToInt32(selecaoProduto));
                
                Console.WriteLine($"CÓDIGO DO PRODUTO=> {historico.IdProduto} " +
                $"- CÓDIGO FORMA DE PAGAMENTO => {historico.IdFormaPagamento} " +
                $"- DATA DA OPERAÇÃO => {historico.DataRealizacao} - VALOR CALCULADO => R${historico.ValorCalculo}");

                Console.WriteLine("\nObrigada por usar nossa calculadora. Volte sempre!!");

                Console.ReadKey();

            }
        }
    }
}
