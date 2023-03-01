using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<GetRentalResponse> GetById(int id);
        IDataResult<List<ListRentalResponse>> GetList();
        IResult Add(CreateRentalRequest request);
        IResult Delete(DeleteRentalRequest request);
        IResult Update(UpdateRentalRequest request);
    }
}
