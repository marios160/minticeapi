using AutoMapper;
using MintIceAPI.Entities;
using MintIceAPI.Helpers;
using MintIceAPI.Models;

namespace MintIceAPI.Services
{
    public class IngredientService
    {
        private DataContext _context;
        private IMapper _mapper;
        public IngredientService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _context.Ingredients.ToList();
        }

        public IEnumerable<Ingredient> GetAllByRecipeId(int id)
        {
            return _context.Ingredients.Where(r => r.RecipeId == id).ToList();
        }

        public void Create(IngredientCreateRequest model)
        {
            // map model to new user object
            var ingredient = _mapper.Map<Ingredient>(model);

            // save user
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
        }


        public Ingredient GetById(int id)
        {
            return getIngredient(id);
        }


        public void Update(int id, IngredientUpdateRequest model)
        {
            var ingredient = getIngredient(id);

            // copy model to user and save
            _mapper.Map(model, ingredient);
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ingredient = getIngredient(id);
            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();
        }

        // helper methods

        private Ingredient getIngredient(int id)
        {
            var ingredient = _context.Ingredients.Find(id);
            if (ingredient == null) throw new KeyNotFoundException("Ingredient not found");
            return ingredient;
        }
    }
}
