﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Ecommerce.ModelDtos
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
