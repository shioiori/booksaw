using AutoMapper;
using booksaw.application.Response;
using booksaw.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Mapper
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile() {
            CreateMap<Publisher, PublisherResponse>().ReverseMap();
        }
    }
}
