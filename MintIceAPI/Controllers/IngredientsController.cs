using Microsoft.AspNetCore.Mvc;
using MintIceAPI.Models;
using MintIceAPI.Services;

namespace MintIceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {

        private readonly ILogger<IngredientsController> _logger;
        private readonly IngredientService _ingredientService;
        public IngredientsController(IngredientService ingredientService, ILogger<IngredientsController> logger)
        {
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ingredientService.GetAll());
        }

        [HttpGet("get-all-by-recipe-id/{id}")]
        public IActionResult GetAllByRecipeId(int id)
        {
            return Ok(_ingredientService.GetAllByRecipeId(id));
        }

        [HttpPost]
        public IActionResult Create(IngredientCreateRequest model)
        {
            _ingredientService.Create(model);
            return Ok(new { message = "Ingredient created" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            return Ok(ingredient);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, IngredientUpdateRequest model)
        {
            _ingredientService.Update(id, model);
            return Ok(new { message = "Ingredient updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ingredientService.Delete(id);
            return Ok(new { message = "Ingredient deleted" });
        }
    }
}
