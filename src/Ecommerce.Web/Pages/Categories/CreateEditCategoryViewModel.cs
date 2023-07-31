using Ecommerce.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Web.Pages.Categories
{
    public class CreateEditCategoryViewModel
    {
        [Required]
        [StringLength(CategoryConsts.MaxNameLenght)]
        public string Name { get; set; }

    }
}
