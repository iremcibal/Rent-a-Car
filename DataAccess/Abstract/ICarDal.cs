using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        public Car getCarsByBrandId(int brandId);
        public Car getCarsByColorId(int colorId);


    }
}
