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
    public class ColorBusinessRules
    {
        IColorDal _colorDal;
        public ColorBusinessRules(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void CheckIfColorNotExist(Color? color)
        {
            if (color == null) throw new BusinessException(Messages.NotBeExist);

        }

        public void CheckIfColorExist(Color? color)
        {
            if (color != null) throw new BusinessException(Messages.AlreadyExist);
        }

        public void CheckIfColorNotExist(int colorId)
        {
            Color color = _colorDal.Get(a => a.Id == colorId);
            CheckIfColorNotExist(color);
        }
    }
}
