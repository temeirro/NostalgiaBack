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

            CreateMap<TagDTO, Tag>().ReverseMap();
            CreateMap<TagCreateDTO, Tag>();

            CreateMap<PostDTO, Post>();
            CreateMap<PostCreateDTO, Post>();
            CreateMap<Post, PostDTO>().ForMember(dto => dto.ImagesPath, opt => opt.MapFrom(o => o.PostImages.Select(a => a.ImagePath)));

            CreateMap<PostImageDTO, PostImage>().ReverseMap();


        }
    }
}
