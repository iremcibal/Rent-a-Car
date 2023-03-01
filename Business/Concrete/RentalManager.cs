using Business.Abstract;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult Add(CreateRentalRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteRentalRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetRentalResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListRentalResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateRentalRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
