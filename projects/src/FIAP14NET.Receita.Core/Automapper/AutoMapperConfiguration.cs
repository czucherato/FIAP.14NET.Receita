using AutoMapper;
using FIAP14NET.Receita.Core.AutoMapper;

namespace LocalChat.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                //ps.AddProfile(new EntityToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToEntityMappingProfile());
            });
        }
    }
}
