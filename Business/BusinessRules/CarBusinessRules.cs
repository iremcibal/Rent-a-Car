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
    public class CarBusinessRules
    {
        ICarDal _carDal;

        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CheckIfCarNotExist(Car? car)
        {
            if (car == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfCarExist(Car? car)
        {
            if (car != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfCarNotExist(int carId)
        {
            Car car = _carDal.Get(a => a.Id == carId);
            CheckIfCarNotExist(car);
        }
    }
}
