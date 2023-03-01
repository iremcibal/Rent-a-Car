using Business.Abstract;
using Business.Requests.Colors;
using Business.Responses.Colors;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public IResult Add(CreateColorRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteColorRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetColorResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListColorResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateColorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
