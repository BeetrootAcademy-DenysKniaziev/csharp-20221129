using AutoMapper;
using LearningSystem.WEB.ValidationModels;

namespace LearningSystem.WEB.Mapper
{
    public class MapperRegistration:Profile
    {
        public MapperRegistration()
        {
            CreateMap<RegistrationModel, User>();
        }
    }
}
