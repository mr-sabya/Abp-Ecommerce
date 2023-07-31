using Ecommerce.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.ModelDtos
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(CategoryConsts.MaxNameLenght)]
        public string Name { get; set; }

    }
}
