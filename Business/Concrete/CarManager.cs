using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Cars;
using Business.Responses.Brands;
using Business.Responses.Cars;
using Business.ValidationRules;
using Core.Aspects;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IMapper _mapper;
        CarBusinessRules _carBusinessRules;
        public CarManager(ICarDal carDal, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carDal = carDal;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }
        [ValidationAspect(typeof(CarRequestValidator))]
        public IResult Add(CreateCarRequest request)
        {
            Car car = _mapper.Map<Car>(request);
            _carBusinessRules.CheckIfCarNotExist(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteCarRequest request)
        {
            Car car = _mapper.Map<Car>(request);
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<List<ListCarResponse>> GetAll()
        {
            List<Car> cars = _carDal.GetAll(include: c => c.Include(ci => ci.Brand)
            .Include(c => c.CarImage).Include(c => c.Color));
            List<ListCarResponse> responses = _mapper.Map<List<ListCarResponse>>(cars);
            return new SuccessDataResult<List<ListCarResponse>>(responses);
        }

        public IDataResult<GetCarResponse> GetById(int id)
        {
            Car car = _carDal.Get(c => c.Id == id, include: c => c.Include(c => c.Color)
            .Include(c => c.Brand).Include(c => c.CarImage));
            var response = _mapper.Map<GetCarResponse>(car);
            return new SuccessDataResult<GetCarResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListCarResponse>> GetCarsByBrandId(int brandId)
        {
            List<Car> cars = _carDal.getCarsByBrandId(c=>c.BrandId== brandId,include:c=>c.Include(c=>c.Color)
            .Include(c=>c.Brand).Include(c=>c.CarImage));
            var response = _mapper.Map<List<ListCarResponse>>(cars);
            return new SuccessDataResult<List<ListCarResponse>>(response,Messages.GetData);
        }

        public IDataResult<List<ListCarResponse>> GetCarsByColorId(int colorId)
        {
            List<Car> cars = _carDal.getCarsByColorId(c => c.ColorId == colorId, include: c => c.Include(c => c.Color)
            .Include(c => c.Brand).Include(c => c.CarImage));
            var response = _mapper.Map<List<ListCarResponse>>(cars);
            return new SuccessDataResult<List<ListCarResponse>>(response, Messages.GetData);
        }

        public PaginateListCarResponse GetList(PageRequest request)
        {
            IPaginate<Car> cars = _carDal.GetList(index: request.Index,
                                                    size: request.Size,include:
                                                    c => c.Include(ci => ci.Brand));

            PaginateListCarResponse response = _mapper.Map<PaginateListCarResponse>(cars);

            return response;
        }

        public IResult Update(UpdateCarRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
