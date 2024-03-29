﻿using Business.Constants;
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
    public class UserBusinessRules
    {
        IUserDal _userDal;

        public void CheckIfUserNotExist(User? user)
        {
            if (user == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfUserExist(User? user)
        {
            if (user != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfUserNotExist(int userId)
        {
            User user = _userDal.Get(a => a.Id == userId);
            CheckIfUserNotExist(user);
        }
    }
}
