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
using SuperStoreAPI.SQL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperStoreAPI.Functions
{
    public class GetProductByID
    {
        private readonly ILogger<GetProductByID> _logger;
        private readonly IProductsRepository _productsRepository;

        public GetProductByID(ILogger<GetProductByID> logger, IProductsRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }
        [FunctionName("GetProductByID")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "GetProductByID/{id}")] HttpRequest req, int id)
        {
            Product? product = _productsRepository.GetSingle(x => x.Id == id);
            return new OkObjectResult(product);
        }
    }
}
