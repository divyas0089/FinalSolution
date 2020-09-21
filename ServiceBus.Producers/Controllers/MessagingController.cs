using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Contracts;
using ServiceBus.Producers.Requests;
using ServiceBus.Producers.Services;
using Microsoft.Azure.Services;

namespace ServiceBus.Producers.Controllers
{
    public class MessagingController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;

        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish/text")]
        public async Task<IActionResult> PublishText()
        {
            using var reader = new StreamReader(Request.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            await _messagePublisher.Publish(bodyAsText);
            return Ok();
        }

        [HttpPost("publish/customer")]
        public async Task<IActionResult> PublishCustomer([FromBody] CreateCustomerRequest request)
        {
            //_customerService.CreateCustomer(request);
            var customerCreated = new CustomerCreated
            {
                Id = request.Id,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
            await _messagePublisher.Publish(customerCreated);
            return Ok();
        }

        [HttpPost("publish/order")]
        public async Task<IActionResult> PublishOrder([FromBody] CreateOrderRequest request)
        {
            //_orderService.CreateOrder(request);
            var orderCreated = new OrderCreated
            {
                Id = request.Id,
                ProductName = request.ProductName
            };
            await _messagePublisher.Publish(orderCreated);
            return Ok();
        }
    }
}

