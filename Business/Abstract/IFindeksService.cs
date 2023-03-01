using Business.Requests.Findeks;
using Business.Responses.Findeks;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<GetFindeksResponse> GetById(int id);
        IDataResult<List<ListFindeksResponse>> GetList();
        IResult Add(CreateFindeksRequest request);
        IResult Delete(DeleteFindeksRequest request);
        IResult Update(UpdateFindeksRequest request);
    }
}
