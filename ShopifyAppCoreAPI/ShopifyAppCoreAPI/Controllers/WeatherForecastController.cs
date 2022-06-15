using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopifyAppCoreAPI.Classes;
using ShopifySharp;
using ShopifySharp.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopifyAppCoreAPI.Controllers
{
    [ApiController]
    [Route("Shopify/")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Route("allOrders/{myShopifyUrl}/{privateAppPassword}")]
        [HttpGet]
        public ListResult<Order> allOrders(string myShopifyUrl,string privateAppPassword)
        {
            var service = new OrderService(myShopifyUrl, privateAppPassword);

            var allOrder = service.ListAsync().Result;

            //after result deserlize the result in your product class

            return allOrder;
        }
    }
}
