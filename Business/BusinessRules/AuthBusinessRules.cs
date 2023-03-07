using Business.Constants;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class AuthBusinessRules
    {
        public void CheckIfPasswordMatch(string password, byte[] passwordHash,byte[] passwordSalt)
        {
           bool isPasswordMatch = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!isPasswordMatch) throw new System.Exception(Messages.PasswordError);
        }
    }
}
