using Business.Requests.Colors;
using Business.Responses.Colors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<GetColorResponse> GetById(int id);
        IDataResult<List<ListColorResponse>> GetAll();
        IResult Add(CreateColorRequest request);
        IResult Delete(DeleteColorRequest request);
        IResult Update(UpdateColorRequest request);
    }
}
