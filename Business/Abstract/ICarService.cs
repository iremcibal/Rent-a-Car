using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Business.Requests;
using Core.Utilities.Results;
using Entities.Concrete;
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
        PaginateListCarResponse GetList(PageRequest request);
        IDataResult<List<ListCarResponse>> GetAll();
        IResult Add(CreateCarRequest request);
        IResult Delete(DeleteCarRequest request);
        IResult Update(UpdateCarRequest request);
        IDataResult<List<ListCarResponse>> GetCarsByColorId(int colorId);
        IDataResult<List<ListCarResponse>> GetCarsByBrandId(int brandId);
    }
}
