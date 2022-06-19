namespace MintIceAPI.Models
{
    public class IngredientUpdateRequest
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
