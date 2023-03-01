using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<GetCarResponse> GetById(int id);
        IDataResult<List<ListCarResponse>> GetList();
        IResult Add(CreateCarRequest request);
        IResult Delete(DeleteCarRequest request);
        IResult Update(UpdateCarRequest request);
    }
}
