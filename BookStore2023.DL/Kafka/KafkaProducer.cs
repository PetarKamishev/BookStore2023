using BookStore.Models.Models;
using Confluent.Kafka;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.DL.Kafka
{
    public class KafkaProducer
    {
        private static IProducer<Guid, Book> _producer;
 
        public KafkaProducer(string user)
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "sulky.srvs.cloudkafka.com:9094",
                SecurityProtocol = SecurityProtocol.SaslSsl,
                SaslUsername = "wrlgoryr",
                SaslPassword = "cfcSFJUaHz7tVE-wButfZIb51GTR-3lx",
                SaslMechanism = SaslMechanism.ScramSha512
            };

            _producer = new ProducerBuilder<Guid, Book>(config)
                .SetKeySerializer(new MsgPackSerializer<Guid>())
                .SetValueSerializer(new MsgPackSerializer<Book>())
            .Build();
        }
        public async Task ProduceBook(string topic, Message<Guid, Book> msg)
        {
            await _producer.ProduceAsync(topic, msg);
        }
    }
    }

