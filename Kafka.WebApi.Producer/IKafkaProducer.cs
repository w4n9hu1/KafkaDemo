namespace Kafka.WebApi.Producer
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(Order order);
    }
}