using System.ComponentModel.DataAnnotations.Schema;

namespace MintIceAPI.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(5, 4)")]
        public decimal Quantity { get; set; }
    }
}
