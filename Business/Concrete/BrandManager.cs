using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Brands;
using Business.Responses.Brands;
using Business.Responses.Cars;
using Business.ValidationRules;
using Core.Aspects;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        IMapper _mapper;
        BrandBusinessRules _brandBusinessRules;

        public BrandManager(IBrandDal brandDal, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandDal = brandDal;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }
        [ValidationAspect(typeof(BrandRequestValidator))]
        public IResult Add(CreateBrandRequest request)
        {
            Brand brand = _mapper.Map<Brand>(request);
            _brandBusinessRules.CheckIfBrandNotExist(brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteBrandRequest request)
        {
            Brand brand = _mapper.Map<Brand>(request);
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetBrandResponse> GetById(int id)
        {
            Brand brand = _brandDal.Get(b=>b.Id == id);
            var response = _mapper.Map<GetBrandResponse>(brand);
            return new SuccessDataResult<GetBrandResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListBrandResponse>> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();
            List<ListBrandResponse> responses = _mapper.Map<List<ListBrandResponse>>(brands); 
            return new SuccessDataResult<List<ListBrandResponse>>(responses,Messages.ListData);
        }

        public IResult Update(UpdateBrandRequest request)
        {
            Brand brand = _mapper.Map<Brand>(request);
            _brandBusinessRules.CheckIfBrandNotExist(brand);
            _brandDal.Update(brand);
            return new SuccessResult(Messages.UpdateData);
        }

    }
}
