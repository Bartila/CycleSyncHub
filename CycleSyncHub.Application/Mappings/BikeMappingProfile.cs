using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CycleSyncHub.Application.ApplicationUser;
using CycleSyncHub.Application.Bike;
using CycleSyncHub.Application.Bike.Commands.EditBike;
using CycleSyncHub.Application.BikeInfo;
using CycleSyncHub.Domain.Entities;

namespace CycleSyncHub.Application.Mappings
{
    public class BikeMappingProfile : Profile
    {
        public BikeMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<BikeDto, Domain.Entities.Bike>()
                .ForMember(e => e.BikesDetails, opt => opt.MapFrom(src => new BikeDetails()
                {
                    TypeOfBike = src.TypeOfBike,
                    Weight = src.Weight,
                    Size = src.Size,
                    GroupSet = src.GroupSet,
                }));

            CreateMap<Domain.Entities.Bike, BikeDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null 
                                                && (src.CreatedById == user.Id || user.IsInRole("Admin"))))
                .ForMember(dto => dto.TypeOfBike, opt => opt.MapFrom(src => src.BikesDetails.TypeOfBike))
                .ForMember(dto => dto.Weight, opt => opt.MapFrom(src => src.BikesDetails.Weight))
                .ForMember(dto => dto.Size, opt => opt.MapFrom(src => src.BikesDetails.Size))
                .ForMember(dto => dto.GroupSet, opt => opt.MapFrom(src => src.BikesDetails.GroupSet));

            CreateMap<BikeDto, EditBikeCommand>();

            CreateMap<BikeInfoDto, Domain.Entities.BikeInfo>()
                .ReverseMap();
		}
    }
}
