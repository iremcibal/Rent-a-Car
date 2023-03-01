using AutoMapper;
using Business.Requests.Findeks;
using Business.Responses.Findeks;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class FindeksMapperProfiles :Profile
    {
        public FindeksMapperProfiles() {
            CreateMap<CreateFindeksRequest, Findeks>();
            CreateMap<UpdateFindeksRequest, Findeks>();
            CreateMap<DeleteFindeksRequest, Findeks>();
            CreateMap<Findeks, ListFindeksResponse>();
            CreateMap<Findeks, GetFindeksResponse>();
        }
    }
}
