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
    public class FindeksBusinessRules
    {
        IFindeksDal _findeksDal;
        public FindeksBusinessRules(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public void CheckIfFindeksNotExist(Findeks? findeks)
        {
            if (findeks == null) throw new Exception(Messages.NotBeExist);

        }

        public void CheckIfFindeksExist(Findeks? findeks)
        {
            if (findeks != null) throw new Exception(Messages.AlreadyExist);
        }

        public void CheckIfFindeksNotExist(int findeksId)
        {
            Findeks findeks = _findeksDal.Get(a => a.Id == findeksId);
            CheckIfFindeksNotExist(findeks);
        }
    }
}
