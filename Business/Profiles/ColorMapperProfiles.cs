﻿using AutoMapper;
using Business.Requests.Colors;
using Business.Responses.Colors;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ColorMapperProfiles : Profile
    {
        public ColorMapperProfiles()
        {
            CreateMap<CreateColorRequest, Color>();
            CreateMap<UpdateColorRequest, Color>();
            CreateMap<DeleteColorRequest, Color>();
            CreateMap<Color, ListColorResponse>();
            CreateMap<Color, GetColorResponse>();
        }
    }
}
