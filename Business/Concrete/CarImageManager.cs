using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.CarImages;
using Business.Responses.CarImages;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        CarImageBusinessRules _carImageBusinessRules;
        IMapper _mapper;
        public CarImageManager(ICarImageDal carImageDal, CarImageBusinessRules carImageBusinessRules, IMapper mapper, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _carImageBusinessRules = carImageBusinessRules;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file)
        {
            CarImage image= new CarImage();
            image.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            image.Date = DateTime.Now;
            _carImageDal.Add(image);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteCarImageRequest request)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + request.ImagePath);
            CarImage carImage = _mapper.Map<CarImage>(request);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<List<ListCarImageResponse>> GetAll()
        {
            List<CarImage> carimages = _carImageDal.GetAll();
            List<ListCarImageResponse> responses = _mapper.Map<List<ListCarImageResponse>>(carimages);
            return new SuccessDataResult<List<ListCarImageResponse>>(responses);
        }

        public IDataResult<GetCarImageResponse> GetByImageId(int imageId)
        {
            CarImage carImage = _carImageDal.Get(ci => ci.Id == imageId);
            GetCarImageResponse response = _mapper.Map<GetCarImageResponse>(carImage);
            return new SuccessDataResult<GetCarImageResponse>(response, Messages.GetData);
        }

        public IResult Update(IFormFile file, CarImage image)
        {
            _fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(image);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
