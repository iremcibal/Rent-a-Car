using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>,IUserDal
    {
        public List<OperationClaims> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaims in context.OperationsClaims
                             join userOperationClaims in context.UserOperationClaims
                                 on operationClaims.Id equals userOperationClaims.OperationClaimId
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaims { Id = operationClaims.Id, Name = operationClaims.Name };
                return result.ToList();

            }
        }
    }
}
