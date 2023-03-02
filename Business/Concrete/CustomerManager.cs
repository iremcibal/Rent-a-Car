using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        CustomerBusinessRules _customerBusinessRules;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules customerBusinessRules)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _customerBusinessRules = customerBusinessRules;
        }

        public IResult Add(CreateCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);
            _customerBusinessRules.CheckIfCustomerExist(customer);
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetCustomerResponse> GetById(int id)
        {
            Customer customer = _customerDal.Get(c=>c.Id== id);
            var response = _mapper.Map<GetCustomerResponse>(customer);
            return new SuccessDataResult<GetCustomerResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListCustomerResponse>> GetList()
        {
            List<Customer> customers = _customerDal.GetAll();
            List<ListCustomerResponse> responses = _mapper.Map<List<ListCustomerResponse>>(customers);
            return new SuccessDataResult<List<ListCustomerResponse>>(responses,Messages.ListData);
        }

        public IResult Update(UpdateCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);
            _customerBusinessRules.CheckIfCustomerNotExist(customer);
            _customerDal.Update(customer);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
