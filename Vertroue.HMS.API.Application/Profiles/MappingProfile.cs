using AutoMapper;

using Vertroue.HMS.API.Application.Features.Categories.Commands.CreateCategory;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesList;
using Vertroue.HMS.API.Application.Features.Categories.Queries.GetCategoriesListWithProducts;
using Vertroue.HMS.API.Domain.Entities;

namespace Vertroue.HMS.API.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Product, CategoryProductDto>().ReverseMap();
            
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryProductListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

        }
    }
}
