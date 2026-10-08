using RabbitMQ.Client;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    VirtualHost = "/",
    AutomaticRecoveryEnabled = true, //Reconecção automática habilitada;
    NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
};

await using var connection = await factory.CreateConnectionAsync();// Cria uma conexão com o RabbitMQ;
await using var channel = await connection.CreateChannelAsync(); // Cria um canal de comunicação com o RabbitMQ;

await channel.QueueDeclareAsync(
    queue: "fila_persistente", // Nome da fila;
    durable: true, // A fila será persistente;(Sem este parâmetro = true, não se torna uma fila persistente)
    exclusive: false, // A fila não será exclusiva para esta conexão;
    autoDelete: false, // A fila não será deletada automaticamente quando não houver consumidores;
    arguments: null); // Sem argumentos adicionais;

string mensagem = "Mensagem persistente"; // Mensagem de exemplo a ser enviada para a fila;
var body = System.Text.Encoding.UTF8.GetBytes(mensagem); // Converte a mensagem para um array de bytes;

var properties = new BasicProperties
{
    Persistent = true // Define a mensagem como persistente;(gravada em disco e não somente na memória)
};

await channel.BasicPublishAsync(
    exchange: "", // Exchange padrão;
    routingKey: "fila_persistente", // Roteio para a fila persistente;
    mandatory: false, // Não requer confirmação de entrega;
    basicProperties: properties, // Propriedades da mensagem;
    body: body); // Conteúdo da mensagem;

Console.WriteLine($"Mensagem enviada para a fila persistente: {mensagem}"); // Exibe no console a mensagem enviada;