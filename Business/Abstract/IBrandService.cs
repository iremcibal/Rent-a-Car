using Business.Requests.Brands;
using Business.Responses.Brands;
using Business.Responses.Cars;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<GetBrandResponse> GetById(int id);
        IDataResult<List<ListBrandResponse>> GetAll();
        IResult Add(CreateBrandRequest request);
        IResult Delete(DeleteBrandRequest request);
        IResult Update(UpdateBrandRequest request);
    }
}
