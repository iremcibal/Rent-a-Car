using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Cars;
using Business.Responses.Cars;
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

        public IDataResult<GetCarResponse> GetById(int id)
        {
            Car car = _carDal.Get(c=>c.Id== id);
            var response = _mapper.Map<GetCarResponse>(car);
            return new SuccessDataResult<GetCarResponse>(response,Messages.GetData);
        }

        public IDataResult<GetCarResponse> GetCarsByBrandId(int brandId)
        {
            Car car = _carDal.getCarsByBrandId(brandId);
            var response = _mapper.Map<GetCarResponse>(car);
            return new SuccessDataResult<GetCarResponse>(response,Messages.GetData);
        }

        public IDataResult<GetCarResponse> GetCarsByColorId(int colorId)
        {
            Car car = _carDal.getCarsByColorId(colorId);
            var response = _mapper.Map<GetCarResponse>(car);
            return new SuccessDataResult<GetCarResponse>(response, Messages.GetData);
        }

        public IDataResult<List<ListCarResponse>> GetList()
        {
            List<Car> cars = _carDal.GetAll();
            List<ListCarResponse> responses = _mapper.Map<List<ListCarResponse>>(cars);
            return new SuccessDataResult<List<ListCarResponse>>(responses, Messages.ListData);
        }

        public IResult Update(UpdateCarRequest request)
        {
            Car car = _mapper.Map<Car>(request);
            _carBusinessRules.CheckIfCarNotExist(car);
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
