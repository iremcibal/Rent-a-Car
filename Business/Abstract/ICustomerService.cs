using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<GetCustomerResponse> GetById(int id);
        IDataResult<List<ListCustomerResponse>> GetList();
        IResult Add(CreateCustomerRequest request);
        IResult Delete(DeleteCustomerRequest request);
        IResult Update(UpdateCustomerRequest request);
    }
}
