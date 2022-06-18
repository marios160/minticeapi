using AutoMapper;
using MintIceAPI.Entities;
using MintIceAPI.Helpers;
using MintIceAPI.Models.Recipes;

namespace MintIceAPI.Services
{
    public class RecipeService
    {
        private DataContext _context;
        private IMapper _mapper;
        public RecipeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _context.Recipes;
        }

        public void Create(CreateRequest model)
        {
            // map model to new user object
            var recipe = _mapper.Map<Recipe>(model);

            // save user
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }


        public Recipe GetById(int id)
        {
            return getRecipe(id);
        }


        public void Update(int id, UpdateRequest model)
        {
            var recipe = getRecipe(id);

            // copy model to user and save
            _mapper.Map(model, recipe);
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var recipe = getRecipe(id);
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }

        public IEnumerable<Recipe> GetByName(string name)
        {
            var recipe = _context.Recipes.Where<Recipe>(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
            if (recipe == null) throw new KeyNotFoundException("Recipe not found");
            return recipe;
        }

        // helper methods

        private Recipe getRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null) throw new KeyNotFoundException("Recipe not found");
            return recipe;
        }
    }
}
