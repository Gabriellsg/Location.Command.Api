# Location.Command.Api
# Instruções

•	A aplicação foi construída com .Net 8 utilizando C#.

•	Utilizado Postgress para bancos de dados(utilizado RDS/AWS). Não necessita instalação local.

•	RabbitMq foi utilizado para mensageria.

### Executar o escript abaixo para iniciar um contêiner RabbitMQ:

1- **docker run -d --hostname rabbitserver --name rabbitmq-server -p 15672:15672 -p 5672:5672 rabbitmq:3-management**

2- Acesse o RabbitMQ na URL http://127.0.0.1:15672/ com usuario e senha padrao **guest** / **guest**

Obs: Se desejar poderá instalar o Docker Desktop para visualizar a vistualização da imagem.


# Aplicação desenvolvida

Seu objetivo é gerenciar aluguel de motos e entregadores.

# Requisitos não funcionais

•	A aplicação foi construída com .Net 8 utilizando C#.
•	Utilizado Postgress para bancos de dados.
•	RabbitMq foi utilizado para mensageria.
