using AutoMapper;
using LearningSystem.WEB.ValidationModels;

namespace LearningSystem.WEB.Mapper
{
  
    public class MapperLesson : Profile
    {
        public MapperLesson()
        {
            CreateMap<Article, LessonModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ArticleName));
            CreateMap<LessonModel, Article>()
               .ForMember(dest => dest.ArticleName, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Course, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.ContentHTML, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.Likes, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.Comments, opt => opt.UseDestinationValue());
        }
    }
}
