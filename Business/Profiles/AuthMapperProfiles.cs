using AutoMapper;
using Business.Requests.Auth;
using Business.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<RegisterUserRequest, CreateUserRequest>().ReverseMap();
            
        }
    }
}
