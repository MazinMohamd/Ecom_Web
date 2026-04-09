using AutoMapper;
using Ecom.API.DTOs;
using Ecom.Core.Entities.Product;

namespace Ecom.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
