using System.Threading.Tasks;
using Microsoft.Azure.Services;
namespace ServiceBus.Producers.Services

{
    public class IMessagePublisher
    {
        Task Publish<T>(T obj);

        Task Publish(string raw);
    }
}
