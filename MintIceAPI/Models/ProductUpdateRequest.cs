namespace MintIceAPI.Models
{
    public class ProductUpdateRequest
    {
        public decimal Quantity { get; set; }

        public string Name { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int RecipeId { get; set; }
    }
}
