using Business.Abstract;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(CreateBrandRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteBrandRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetBrandResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListBrandResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateBrandRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
