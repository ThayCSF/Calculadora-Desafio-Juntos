#Projeto de Calculadora de Produtos

O projeto consiste em uma calculadora de produtos para calcular e armazenar os c�lculos anteriormente realizados, 
permitindo a sele��o de produtos e a escolha da forma de pagamento, sendo esta a op��o que levar� a regra 
de neg�cio correta para c�lculo.

Entidades
    Produto:
    Operacao:
    FormaPagamento:

##Infraestrutura

Para erguer o ambiente de base de dados na maquina com o docker basta executar a linha abaixo no terminal:

    docker-compose up -d

Para acessar a base de dados, abra a interface no browser pelo link abaixo:

http://localhost:9000

Configure a conex�o conforme abaixo:

    Sistema: PostgreSQL
    Servidor: postgres
    Usuario: postgres
    Senha: admin

Obs: pode acontecer de a base de dados demorar alguns segundos a mais para estar apta a receber conex�es.

Para desfazer o ambiente executar a linha de comando abaixo:

    docker-compose down
