using Business.Abstract;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        public IResult Add(CreateCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetCustomerResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListCustomerResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateCustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
