using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<GetUserResponse> GetById(int id);
        IDataResult<List<ListUserResponse>> GetAll();
        IResult Add(CreateUserRequest request);
        IResult Delete(DeleteUserRequest request);
        IResult Update(UpdateUserRequest request);

        List<OperationClaims> GetClaims(User user);
        User GetUserByMail(string email);
        GetUserResponse GetByMail(string email);
    }
}
