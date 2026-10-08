# FilaPersistente
RabbitMQ com Fila Persistente - .NET 10

Este projeto foi desenvolvido com o objetivo de estudar como funciona a persistência de filas e mensagens no RabbitMQ utilizando C# e .NET 10.

Diferente do projeto anterior, neste exemplo foquei em criar um Producer que publica mensagens em uma fila persistente, buscando entender como manter as mensagens disponíveis mesmo após uma reinicialização do RabbitMQ ou do Docker.

🚀 Tecnologias utilizadas
C#
.NET 10
RabbitMQ
Docker
📌 Como funciona?

A aplicação possui um Producer responsável por publicar mensagens em uma fila configurada como durável (durable).

A ideia é que a fila continue existindo após uma reinicialização do RabbitMQ. Para isso, também é importante que as mensagens sejam publicadas como persistentes e que o RabbitMQ tenha seu armazenamento devidamente configurado.

Dessa forma, o projeto ajuda a entender melhor como funciona a persistência de mensagens e como reduzir o risco de perder informações em caso de reinicializações.

🎯 Objetivo do projeto

Este é um projeto de estudos para praticar conceitos de mensageria e entender melhor os recursos de persistência do RabbitMQ, utilizando .NET 10.
