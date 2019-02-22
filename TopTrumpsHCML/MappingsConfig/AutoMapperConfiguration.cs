using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopTrumpsHCML.Entities;
using AutoMapper;
using TopTrumpsHCML.Mappings;

namespace TopTrumpsHCML
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                //mapping from data entities to viewmodel objects
                x.AddProfile<EntitiesToViewModelMappingProfile>();             
            });
        }
    }
}