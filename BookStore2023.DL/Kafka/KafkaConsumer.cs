using BookStore.DL.Kafka;
using BookStore.Models.Models;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace BookStore.Kafka
{
    public class KafkaConsumer : BackgroundService
    {
        private static IConsumer<Guid, Book> _consumer;       
        private bool _running = true;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var cfg = new ConsumerConfig()
            {
                BootstrapServers = "pkc-7xoy1.eu-central-1.aws.confluent.cloud:9092",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "YWULFRPB3FUBKXZ6",
                SaslPassword = "3xYVjpimzsKS+XK5lYUYpG2kkQx7SIUTMFtMUdqwBJuocQWa4BzyCBbEOJroNVBf",
                SaslMechanism = SaslMechanism.Plain,
                GroupId = $"Petar.{Guid.NewGuid()}",
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            _consumer = new ConsumerBuilder<Guid, Book>(cfg)
                .SetKeyDeserializer(new MsgPackDeserializer<Guid>())
                .SetValueDeserializer(new MsgPackDeserializer<Book>())
                .Build();

            var topics = new List<string>()
            {
                "pu-chat"
            };

            _consumer.Subscribe(topics);
            
            while(!stoppingToken.IsCancellationRequested)
            {
               Console.WriteLine($"{_consumer.Consume()}");
            }
            return Task.CompletedTask;
        }
    }
}
