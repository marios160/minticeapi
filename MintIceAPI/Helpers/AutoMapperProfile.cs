using AutoMapper;
using MintIceAPI.Entities;
using MintIceAPI.Models;

namespace MintIceAPI.Helpers
{


    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<DateTime?, DateTime>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<decimal?, decimal>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<RecipeCreateRequest, Recipe>();
            CreateMap<RecipeUpdateRequest, Recipe>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<ProductUpdateRequest, Product>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
            CreateMap<IngredientCreateRequest, Ingredient>();
            CreateMap<IngredientUpdateRequest, Ingredient>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) => {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        }
    }
}
