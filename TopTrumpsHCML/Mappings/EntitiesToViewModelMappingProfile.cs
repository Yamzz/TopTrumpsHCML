using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopTrumpsHCML.Entities;
using TopTrumpsHCML.Models;

namespace TopTrumpsHCML.Mappings
{
    public class EntitiesToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// Create mapping in constructor of entities to View-Model  
        /// </summary>
        public EntitiesToViewModelMappingProfile()
        {
            //.ForMember(dest => dest.baz, opt => opt.Condition(src => (src.baz >= 0)); 
            CreateMap<Starship, CardViewModel>()
                .ForMember(cardVm => cardVm.Credits, map => map.MapFrom(startShip => startShip.cost_in_credits))
                .ForMember(cardVm => cardVm.Ratings, map => map.MapFrom(startShip => startShip.hyperdrive_rating))
                .ForMember(cardVm => cardVm.Speed, map => map.MapFrom(startShip => startShip.MGLT))
                .ForMember(cardVm => cardVm.Films, map => map.MapFrom(startShip => startShip.films.Count.ToString()))
                .ForMember(cardVm => cardVm.Crew, map => map.MapFrom(startShip => startShip.crew))
                .ForMember(cardVm => cardVm.Model, map => map.MapFrom(startShip => startShip.model))
                .ForMember(cardVm => cardVm.Manufacturer, map => map.MapFrom(startShip => startShip.manufacturer))
                .ForMember(cardVm => cardVm.Pilot, map => map.MapFrom((starShip => starShip.pilots.Count > 0 ? starShip.pilots.Count.ToString() : "0"))); 
                //map the first pilot if starship has any pilot  or you could make a heept request to get the pilot name 
        }
    }
}