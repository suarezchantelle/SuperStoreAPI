using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SuperStoreAPI.SQL.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;
using SuperStoreAPI.SQL.Models;

namespace SuperStoreAPI
{
    public class GetProducts
    {
        private readonly ILogger<GetProducts> _logger;
        private readonly IProductsRepository _productsRepository;

        public  GetProducts(ILogger<GetProducts> logger, IProductsRepository productsRepository) {
            _logger = logger;
            _productsRepository = productsRepository;
        }
        [FunctionName("GetProducts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            List<Product> products =  _productsRepository.GetAll().ToList();
            return new OkObjectResult(products);
        }
    }
}
