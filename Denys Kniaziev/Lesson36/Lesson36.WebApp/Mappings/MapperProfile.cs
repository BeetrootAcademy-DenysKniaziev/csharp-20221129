using AutoMapper;
using Lesson36.Contracts;
using Lesson36.WebApp.Models.Api;

namespace Lesson36.WebApp.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreatePersonRequest, Person>()
                .ForMember(dist => dist.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dist => dist.CreatedAt, opt => opt.Ignore());

            CreateMap<Lesson36.Contracts.Person, Lesson36.WebApp.Models.Person>();
        }
    }
}
