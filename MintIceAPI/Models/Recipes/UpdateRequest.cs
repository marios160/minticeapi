

namespace MintIceAPI.Models.Recipes
{
    public class UpdateRequest
    {
        public string? Name { get; set; }

        public string? Note { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Favourite { get; set; }
    }
}
