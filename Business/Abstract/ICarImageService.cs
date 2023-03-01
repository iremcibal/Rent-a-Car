using Business.Requests.CarImages;
using Business.Responses.CarImages;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<GetCarImageResponse> GetById(int id);
        IDataResult<List<ListCarImageResponse>> GetList();
        IResult Add(CreateCarImageRequest request);
        IResult Delete(DeleteCarImageRequest request);
        IResult Update(UpdateCarImageRequest request);
    }
}
