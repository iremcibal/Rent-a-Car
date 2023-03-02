using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public Car getCarsByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Cars.Include(c => c.Brand).FirstOrDefault(c => c.Brand.Id == brandId);
            }
        }

        public Car getCarsByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Cars.Include(c => c.Color).FirstOrDefault(c => c.Color.Id == colorId);
            }
        }
    }
}
