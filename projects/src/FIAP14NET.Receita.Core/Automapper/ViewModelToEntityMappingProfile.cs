﻿using AutoMapper;
using FIAP14NET.Receita.Core.Dominio.ViewModels;

namespace FIAP14NET.Receita.Core.AutoMapper
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<ReceitaViewModel, Dominio.Entidades.Receita>();
        }
    }
}