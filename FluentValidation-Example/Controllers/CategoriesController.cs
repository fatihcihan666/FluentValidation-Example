using FluentValidation_Example.Context;
using FluentValidation_Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FluentValidation_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        EfContext context = new EfContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int categoryId)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int categoryId)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            context.Remove(category);
            context.SaveChanges();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int categoryId, Category category)
        {
            var editCategory = context.Categories.FirstOrDefault(x => x.Id == categoryId);
            editCategory.Name = category.Name;
            editCategory.Description = category.Description;
            context.Update(editCategory);
            return Ok(editCategory);
        }
    }
}
