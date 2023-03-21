using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        public List<Car> getCarsByBrandId(Expression<Func<Car, bool>> predicate,
        Func<IQueryable<Car>, IIncludableQueryable<Car, object>> include = null, bool enableTracking = true);
        public List<Car> getCarsByColorId(Expression<Func<Car, bool>> predicate,
        Func<IQueryable<Car>, IIncludableQueryable<Car, object>> include = null, bool enableTracking = true);


    }
}
