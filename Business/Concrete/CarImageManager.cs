using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.CarImages;
using Business.Responses.CarImages;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        CarImageBusinessRules _carImageBusinessRules;
        IMapper _mapper;
        public CarImageManager(ICarImageDal carImageDal, CarImageBusinessRules carImageBusinessRules, IMapper mapper)
        {
            _carImageDal = carImageDal;
            _carImageBusinessRules = carImageBusinessRules;
            _mapper = mapper;
        }

        public IResult Add(CreateCarImageRequest request)
        {
            CarImage carImage = _mapper.Map<CarImage>(request);
            _carImageBusinessRules.CheckIfCarImageExist(carImage);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteCarImageRequest request)
        {
            CarImage carImage = _mapper.Map<CarImage>(request);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetCarImageResponse> GetById(int id)
        {
            CarImage carImage = _carImageDal.Get(c=>c.Id == id);
            var response = _mapper.Map<GetCarImageResponse>(carImage);
            return new SuccessDataResult<GetCarImageResponse>(response);
        }

        public IDataResult<List<ListCarImageResponse>> GetList()
        {
            List<CarImage> carimages = _carImageDal.GetAll();
            List<ListCarImageResponse> responses = _mapper.Map<List<ListCarImageResponse>>(carimages);
            return new SuccessDataResult<List<ListCarImageResponse>>(responses);
        }

        public IResult Update(UpdateCarImageRequest request)
        {
            CarImage carImage = _mapper.Map<CarImage>(request);
            _carImageBusinessRules.CheckIfCarImageNotExist(carImage);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
