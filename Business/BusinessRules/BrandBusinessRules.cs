using Business.Constants;
using Core.Business.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BrandBusinessRules
    {
        IBrandDal _brandDal;
        public BrandBusinessRules(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void CheckIfBrandNotExist(Brand? brand)
        {
            if (brand == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfBrandExist(Brand? brand)
        {
            if (brand != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfBrandNotExist(int brandId)
        {
            Brand brand = _brandDal.Get(a => a.Id == brandId);
            CheckIfBrandNotExist(brand);
        }
    }
}
