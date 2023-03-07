using AutoMapper;
using Business.Requests.Auth;
using Business.Requests.Brands;
using Business.Requests.Users;
using Business.Responses.Brands;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class BrandMapperProfiles : Profile
    {
        public BrandMapperProfiles()
        {
            CreateMap<CreateBrandRequest, Brand>();
            CreateMap<UpdateBrandRequest, Brand>();
            CreateMap<DeleteBrandRequest, Brand>();
            CreateMap<Brand, ListBrandResponse>();
            CreateMap<Brand, GetBrandResponse>();
        }
    }
}
