using Business.Constants;
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
            if (rental == null) throw new Exception(Messages.NotBeExist);

        }

        public void CheckIfRentalExist(Rental? rental)
        {
            if (rental != null) throw new Exception(Messages.AlreadyExist);
        }

        public void CheckIfRentalNotExist(int rentalId)
        {
            Rental rental = _rentalDal.Get(a => a.Id == rentalId);
            CheckIfRentalNotExist(rental);
        }
    }
}
