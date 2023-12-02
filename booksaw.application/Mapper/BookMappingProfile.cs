using AutoMapper;
using booksaw_api.application.Commands.Book;
using booksaw_api.application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw_api.application.Mapper
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() { 
            CreateMap<Book, BookResponse>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, EditBookCommand>().ReverseMap();
        }
    }
}
