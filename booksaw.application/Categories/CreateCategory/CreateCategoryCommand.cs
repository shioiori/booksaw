﻿using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public string Name { get; set; }
    }
}
