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
    public class RentalBusinessRules
    {
        IRentalDal _rentalDal;
        public RentalBusinessRules(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public void CheckIfRentalNotExist(Rental? rental)
        {
            if (rental == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfRentalExist(Rental? rental)
        {
            if (rental != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfRentalNotExist(int rentalId)
        {
            Rental rental = _rentalDal.Get(a => a.Id == rentalId);
            CheckIfRentalNotExist(rental);
        }

        public void CheckIfCarExist(int carId)
        {
            Rental rental = _rentalDal.Get(r=>r.CarId == carId);
            if (rental.ReturnDate==null) throw new BusinessException(Messages.CarAtCustomer);
        }
    }
}
