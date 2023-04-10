using AutoMapper;
using LearningSystem.WEB.ValidationModels;

namespace LearningSystem.WEB.Mapper
{
    public class MapperCourse : Profile
    {
        public MapperCourse()
        {
            CreateMap<Course, CourseModel>()
            .ForMember(dest => dest.Uploads, opt => opt.Ignore());
            CreateMap<CourseModel, Course>()
               .ForMember(dest => dest.Articles, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.ImagePath, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.User, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.UserId, opt => opt.UseDestinationValue())
               .ForMember(dest => dest.Created, opt => opt.UseDestinationValue());
        }
    }
}
