using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<Car> getCarsByBrandId(Expression<Func<Car, bool>> predicate,
                        Func<IQueryable<Car>, IIncludableQueryable<Car, object>> include = null, bool enableTracking = true)
        {
            using (RentACarContext context = new RentACarContext())
            {

                IQueryable<Car> queryable = context.Set<Car>();
                if (!enableTracking) queryable.AsNoTracking();
                if (include is not null) queryable = include(queryable);
                if (predicate is not null) queryable = queryable.Where(predicate);
                return queryable.ToList();
            }
        }

        public List<Car> getCarsByColorId(Expression<Func<Car, bool>> predicate,
                        Func<IQueryable<Car>, IIncludableQueryable<Car, object>> include = null, bool enableTracking = true)
        {
            using (RentACarContext context = new RentACarContext())
            {
                IQueryable<Car> queryable = context.Set<Car>();
                if (!enableTracking) queryable.AsNoTracking();
                if (include is not null) queryable = include(queryable);
                if (predicate is not null) queryable = queryable.Where(predicate);
                return queryable.ToList();
            }
        }
    }
}
