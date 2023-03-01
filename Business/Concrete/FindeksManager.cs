using Business.Abstract;
using Business.Requests.Findeks;
using Business.Responses.Findeks;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        public IResult Add(CreateFindeksRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteFindeksRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetFindeksResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListFindeksResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateFindeksRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
