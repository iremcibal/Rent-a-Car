using Business.Constants;
using Core.Business.Exceptions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CarImageBusinessRules
    {
        ICarImageDal _carImageDal;
        public CarImageBusinessRules(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public void CheckIfCarImageNotExist(CarImage? carImage)
        {
            if (carImage == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfCarImageExist(CarImage? carImage)
        {
            if (carImage != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfCarImageNotExist(int carImageId)
        {
            CarImage carImage = _carImageDal.Get(a => a.Id == carImageId);
            CheckIfCarImageNotExist(carImageId);
        }

    }
}
