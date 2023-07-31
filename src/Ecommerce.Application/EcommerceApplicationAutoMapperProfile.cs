using AutoMapper;
using Ecommerce.ModelDtos;
using Ecommerce.Models;

namespace Ecommerce;

public class EcommerceApplicationAutoMapperProfile : Profile
{
    public EcommerceApplicationAutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
    }
}
