using AutoMapper;
using Ecommerce.ModelDtos;
using Ecommerce.Web.Pages.Categories;

namespace Ecommerce.Web;

public class EcommerceWebAutoMapperProfile : Profile
{
    public EcommerceWebAutoMapperProfile()
    {
        CreateMap<CreateEditCategoryViewModel, CreateUpdateCategoryDto>();
        CreateMap<CategoryDto, CreateEditCategoryViewModel>();
    }
}
