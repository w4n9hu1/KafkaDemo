using Microsoft.AspNetCore.Mvc;

namespace Kafka.WebApi.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IKafkaProducer _producer;

        public OrderController(IKafkaProducer producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public async void Create(Order order)
        {
            await _producer.ProduceAsync(order);
        }
    }
}
