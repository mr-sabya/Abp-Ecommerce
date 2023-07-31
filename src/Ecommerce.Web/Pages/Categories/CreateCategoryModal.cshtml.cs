
using Ecommerce.Interface;
using Ecommerce.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Ecommerce.Web.Pages.Categories
{
    public class CreateCategoryModalModel : EcommercePageModel
    {
        [BindProperty]
        public CreateEditCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        public CreateCategoryModalModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryAppService.CreateAsync(
                ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(Category));

            return NoContent();
        }

    }
}
