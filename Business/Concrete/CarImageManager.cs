using Business.Abstract;
using Business.Requests.CarImages;
using Business.Responses.CarImages;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public IResult Add(CreateCarImageRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteCarImageRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetCarImageResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListCarImageResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateCarImageRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
