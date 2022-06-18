namespace MintIceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int RecipeId { get; set; }
    }
}
