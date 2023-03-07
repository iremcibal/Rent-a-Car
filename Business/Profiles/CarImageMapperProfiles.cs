using AutoMapper;
using Business.Requests.CarImages;
using Business.Responses.CarImages;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CarImageMapperProfiles :Profile
    {
        public CarImageMapperProfiles()
        {
            //CreateMap<CreateCarImageRequest, CarImage>();
            //CreateMap<UpdateCarImageRequest, CarImage>();
            CreateMap<DeleteCarImageRequest, CarImage>();
            CreateMap<CarImage, ListCarImageResponse>();
            CreateMap<CarImage, GetCarImageResponse>();
        }
    }
}
