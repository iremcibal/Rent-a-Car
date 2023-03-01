using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        public IResult Add(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(DeleteUserRequest request)
        {
            throw new NotImplementedException();
        }

        public IDataResult<GetUserResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ListUserResponse>> GetList()
        {
            throw new NotImplementedException();
        }

        public IResult Update(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
