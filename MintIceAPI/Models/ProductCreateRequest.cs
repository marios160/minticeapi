using System.ComponentModel.DataAnnotations;

namespace MintIceAPI.Models
{
    public class ProductCreateRequest
    {
        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}
