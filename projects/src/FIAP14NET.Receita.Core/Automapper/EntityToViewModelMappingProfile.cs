//using AutoMapper;
//using LocalChat.Application.Automapper;
//using LocalChat.Application.ViewModels;
//using LocalChat.CrossCutting.ACL.GoogleAPI;
//using LocalChat.Domain.Groups;
//using System;

//namespace FIAP14NET.Receita.Core.AutoMapper
//{
//    public class EntityToViewModelMappingProfile : Profile
//    {
//        public DomainToViewModelMappingProfile()
//        {
//            CreateMap<Group, GroupViewModel>();
//            CreateMap<Place, PlaceViewModel>();

//            CreateMap<Result, PlaceViewModel>()
//                //.ForMember(dest => dest.DateAdded, m => m.MapFrom(src => DateTime.Now))
//                .IgnoreAllNonExisting();
//                //.ForAllOtherMembers(opts => opts.Ignore());
//                //.ForMember(prop => x.Property, opt => opt.MapFrom(src => src.OtherProperty))
                
//                //.ForMember(e => e.LocationId, opt => opt.Ignore())
//                //.ForMember(e => e.CategoryId, opt => opt.Ignore())
//                //.ForMember(e => e.DateAdded, opt => opt.Ignore())
//                //.ForMember(e => e.DateUpdated, opt => opt.Ignore());
//                //.Ignore(q => q.LocationId)
//                //.Ignore(q => q.CategoryId)
//                //.Ignore(q => q.DateAdded)
//                //.Ignore(q => q.DateUpdated);
//        }
//    }
//}