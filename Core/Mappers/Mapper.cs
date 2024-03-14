using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mappers
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>();

        }
    }
}
