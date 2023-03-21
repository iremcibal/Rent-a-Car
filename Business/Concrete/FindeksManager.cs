using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Findeks;
using Business.Responses.Findeks;
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
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;
        IMapper _mapper;
        FindeksBusinessRules _findeksBusinessRules;

        public FindeksManager(IFindeksDal findeksDal, IMapper mapper, FindeksBusinessRules findeksBusinessRules)
        {
            _findeksDal = findeksDal;
            _mapper = mapper;
            _findeksBusinessRules = findeksBusinessRules;
        }

        public IResult Add(CreateFindeksRequest request)
        {
            Findeks findeks = _mapper.Map<Findeks>(request);
            _findeksBusinessRules.CheckIfFindeksNotExist(findeks);
            _findeksDal.Add(findeks);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteFindeksRequest request)
        {
            Findeks findeks = _mapper.Map<Findeks>(request);
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetFindeksResponse> GetById(int id)
        {
            Findeks findeks = _findeksDal.Get(f=>f.Id == id);
            var response = _mapper.Map<GetFindeksResponse>(findeks);
            return new SuccessDataResult<GetFindeksResponse>(response,Messages.GetData);
        }

        

        public IDataResult<List<ListFindeksResponse>> GetAll()
        {
            List<Findeks> listFindeks = _findeksDal.GetAll();
            List<ListFindeksResponse> responses = _mapper.Map<List<ListFindeksResponse>>(listFindeks);
           return new SuccessDataResult<List<ListFindeksResponse>>(responses,Messages.ListData);
        }

        public IResult Update(UpdateFindeksRequest request)
        {
            Findeks findeks = _mapper.Map<Findeks>(request);
            _findeksBusinessRules.CheckIfFindeksNotExist(findeks);
            _findeksDal.Update(findeks);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
