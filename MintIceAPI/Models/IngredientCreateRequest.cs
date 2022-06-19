using System.ComponentModel.DataAnnotations;

namespace MintIceAPI.Models
{
    public class IngredientCreateRequest
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Quantity { get; set; }
    }
}
