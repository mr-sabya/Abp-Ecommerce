using Ecommerce.Interface;
using Ecommerce.ModelDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Web.Pages.Categories
{
    public class EditCategoryModalModel : EcommercePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCategoryViewModel Category { get; set; }

        private readonly ICategoryAppService _categoryAppService;

        public EditCategoryModalModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }


        public async Task OnGetAsync()
        {
            var categoryDto = await _categoryAppService.GetAsync(Id);
            Category = ObjectMapper.Map<CategoryDto, CreateEditCategoryViewModel>(categoryDto);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            await _categoryAppService.UpdateAsync(Id,
            ObjectMapper.Map<CreateEditCategoryViewModel, CreateUpdateCategoryDto>(Category)
            );
            return NoContent();
        }

    }
}
