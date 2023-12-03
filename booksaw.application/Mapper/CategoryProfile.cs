using AutoMapper;
using booksaw.application.Categories.CreateCategory;
using booksaw.application.Response;
using booksaw.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() { 
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        }
    }
}
