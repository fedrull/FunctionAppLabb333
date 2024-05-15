using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionAppLabb333
{
    public class CrudApi
    {
        public AppDbContext myDb;
        private readonly ILogger<CrudApi> _logger;

        public CrudApi(ILogger<CrudApi> logger, AppDbContext db)
        {
            _logger = logger;
            myDb = db; // Corrected the assignment
        }

        [Function("GetProducts")]
        public async Task<IActionResult> GetProductsAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Products")] HttpRequest req)
        {
      
            _logger.LogInformation("Getting product list");
            var products = await myDb.Products.ToListAsync();
            return new OkObjectResult(products);
        }



        [Function("CreateProduct")]
        public async Task<IActionResult> CreateProduct(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Products")] HttpRequest req)
        {
            _logger.LogInformation("Creating a new product");

            string requestData = await new StreamReader(req.Body).ReadToEndAsync();
            var creatingProduct = JsonConvert.DeserializeObject<Product>(requestData);


            myDb.Products.Add(creatingProduct);
            await myDb.SaveChangesAsync();
            return new OkObjectResult(creatingProduct);

        }
    }
}
