using BookStore.DL.Kafka;
using BookStore.Models.Models;
using BookStore.Models.Models.Configurations;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookStore.BL.BackgroundJobs
{
    public class BookConsumerService : IHostedService
    {
        private IConsumer<Guid, Book> _consumer;
        static List<Book> _books = new List<Book>();
        public BookConsumerService()
        {
            var config = new ConsumerConfig()
            {
                BootstrapServers = "sulky.srvs.cloudkafka.com:9094",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "wrlgoryr",
                SaslPassword = "cfcSFJUaHz7tVE-wButfZIb51GTR-3lx",
                SaslMechanism = SaslMechanism.ScramSha512,
                GroupId = $"Petar.{Guid.NewGuid()}",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Guid, Book>(config)
                .SetKeyDeserializer(new MsgPackDeserializer<Guid>())
                .SetValueDeserializer(new MsgPackDeserializer<Book>())
                .Build() ;       
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                _consumer.Subscribe("wrlgoryr-books");
                while(!cancellationToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume();
                    if(result == null)
                    {
                        continue;
                    }
                    _books.Add(result.Value);
                }
            });
            
           
            return Task.CompletedTask;
        }
    
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

  
