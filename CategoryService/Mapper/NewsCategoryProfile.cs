
using AutoMapper;
using CategoryService.Dtos;
using CategoryService.Model;

namespace CategoryService.Mapper
{
    public class NewsCategoryProfile:Profile
    {
        public NewsCategoryProfile()
        {
            CreateMap<NewsCategoryCreate, NewsCategory>();
            CreateMap<NewsCategory, NewsCategoryRead>();
            CreateMap<NewsCategoryRead, NewsCategoryCreate>();
        }
    }
}
