using AutoMapper;
using FIAP14NET.Receita.Core.Dominio.Entidades;
using FIAP14NET.Receita.Core.Dominio.ViewModels;

namespace FIAP14NET.Receita.Core.AutoMapper
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<Dominio.Entidades.Receita, ReceitaViewModel>();
            CreateMap<Ingrediente, IngredienteViewModel>();
        }
    }
}