#Projeto de Calculadora de Produtos

O projeto consiste em uma calculadora de produtos para calcular e armazenar os cálculos anteriormente realizados, 
permitindo a seleção de produtos e a escolha da forma de pagamento, sendo esta a opção que levará a regra 
de negócio correta para cálculo.

Entidades
    Produto:
    Operacao:
    FormaPagamento:

##Infraestrutura

Para erguer o ambiente de base de dados na máquina com o docker basta executar a linha abaixo no terminal:

    docker-compose up -d

Para acessar a base de dados, abra a interface no browser pelo link abaixo:

http://localhost:9000

Configure a conexão conforme abaixo:

    Sistema: PostgreSQL
    Servidor: postgres
    Usuario: postgres
    Senha: admin

Obs: pode acontecer de a base de dados demorar alguns segundos a mais para estar apta a receber conex�es.

Para desfazer o ambiente executar a linha de comando abaixo:

    docker-compose down
