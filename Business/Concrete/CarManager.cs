using Business.Abstract;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        public IResult Add(CreateCarRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteCarRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetCarResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListCarResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateCarRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
