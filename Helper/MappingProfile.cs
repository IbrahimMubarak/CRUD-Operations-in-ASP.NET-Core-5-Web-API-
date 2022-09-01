using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DTO;
using WEBAPI.Models;

namespace WEBAPI.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Genrie,GenrieDTO>().ReverseMap();

        }
    }
}
