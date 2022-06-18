using Microsoft.AspNetCore.Mvc;
using MintIceAPI.Entities;
using MintIceAPI.Helpers;
using MintIceAPI.Models.Recipes;
using MintIceAPI.Services;

namespace MintIceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        
        private readonly ILogger<RecipesController> _logger;
        private readonly RecipeService _recipeService;
        public RecipesController(RecipeService recipeService, ILogger<RecipesController> logger)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_recipeService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _recipeService.Create(model);
            return Ok(new { message = "Recipe created" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var recipe = _recipeService.GetById(id);
            return Ok(recipe);
        }

        [HttpGet("get-by-name/{name}")]
        public IActionResult GetByName(string name)
        {
            var recipes = _recipeService.GetByName(name);
            return Ok(recipes);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _recipeService.Update(id, model);
            return Ok(new { message = "Recipe updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _recipeService.Delete(id);
            return Ok(new { message = "Recipe deleted" });
        }
    }
}