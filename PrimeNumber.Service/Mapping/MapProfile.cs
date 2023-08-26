using AutoMapper;
using PrimeNumber.Core.DTOs;
using PrimeNumber.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CalculatedSet,CalculatedSetDto>().ReverseMap();
        }
    }
}
