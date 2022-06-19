using System.ComponentModel.DataAnnotations.Schema;

namespace MintIceAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Quantity { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int RecipeId { get; set; }
    }
}
