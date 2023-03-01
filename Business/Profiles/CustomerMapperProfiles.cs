using AutoMapper;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CustomerMapperProfiles :Profile
    {
        public CustomerMapperProfiles()
        {
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<DeleteCustomerRequest, Customer>();
            CreateMap<Customer, ListCustomerResponse>();
            CreateMap<Customer, GetCustomerResponse>();
        }
    }
}
