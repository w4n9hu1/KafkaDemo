using Confluent.Kafka;
using Kafka.Consumer;
using Newtonsoft.Json;

var config = new ConsumerConfig
{
    GroupId = "order-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
{
    consumer.Subscribe("order-topic");
    CancellationTokenSource token = new CancellationTokenSource();
    try
    {
        while (true)
        {
            var response = consumer.Consume(token.Token);
            if (response.Message != null)
            {
                var order = JsonConvert.DeserializeObject<Order>(response.Message.Value);
                Console.WriteLine($"OrderId: {order.OrderId} OrderCode: {order.OrderCode}");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message); ;
    }
}