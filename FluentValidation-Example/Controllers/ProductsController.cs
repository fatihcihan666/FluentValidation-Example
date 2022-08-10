using FluentValidation_Example.Context;
using FluentValidation_Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        EfContext context = new EfContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int productId)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == productId);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int productId)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == productId);
            context.Remove(product);
            context.SaveChanges();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok(product);
        }

    }
}
