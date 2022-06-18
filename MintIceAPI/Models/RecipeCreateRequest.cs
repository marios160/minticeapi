using System.ComponentModel.DataAnnotations;

namespace MintIceAPI.Models
{
    public class RecipeCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Note { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public bool Favourite { get; set; }
    }
}
