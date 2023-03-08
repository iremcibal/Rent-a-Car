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
    public class CustomerBusinessRules
    {
        ICustomerDal _customerDal;

        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void CheckIfCustomerNotExist(Customer? customer)
        {
            if (customer == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfCustomerExist(Customer? customer)
        {
            if (customer != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfCustomerNotExist(int customerId)
        {
            Customer customer = _customerDal.Get(a => a.Id == customerId);
            CheckIfCustomerNotExist(customer);
        }
    }
}
