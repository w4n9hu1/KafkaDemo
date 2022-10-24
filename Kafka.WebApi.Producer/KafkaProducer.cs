using Confluent.Kafka;
using Newtonsoft.Json;

namespace Kafka.WebApi.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducer(IProducer<Null, string> producer)
        {
            _producer = producer;
        }

        public async Task ProduceAsync(Order order)
        {
            await _producer.ProduceAsync("order-topic",
               new Message<Null, string>
               {
                   Value = JsonConvert.SerializeObject(order)
               });
        }
    }
}
