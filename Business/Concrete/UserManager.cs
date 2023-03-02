using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _userBusinessRules;

        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules userBusinessRules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public IResult Add(CreateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userBusinessRules.CheckIfUserExist(user);
            _userDal.Add(user);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userDal.Delete(user);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetUserResponse> GetById(int id)
        {
            User user = _userDal.Get(u=>u.Id== id);
            var response = _mapper.Map<GetUserResponse>(user);
            return new SuccessDataResult<GetUserResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListUserResponse>> GetList()
        {
            List<User> users = _userDal.GetAll();
            List<ListUserResponse> responses = _mapper.Map<List<ListUserResponse>>(users);
            return new SuccessDataResult<List<ListUserResponse>>(responses,Messages.ListData);
        }

        public IResult Update(UpdateUserRequest request)
        {
            User user = _mapper.Map<User>(request);
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
