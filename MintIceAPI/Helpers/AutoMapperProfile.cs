using AutoMapper;
using MintIceAPI.Entities;
using MintIceAPI.Models.Recipes;

namespace MintIceAPI.Helpers
{


    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequest, Recipe>();
            CreateMap<UpdateRequest, Recipe>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        }
    }
}
