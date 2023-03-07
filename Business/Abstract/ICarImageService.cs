using Business.Requests.CarImages;
using Business.Responses.CarImages;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file);
        IResult Update(IFormFile file, CarImage image);
        IResult Delete(DeleteCarImageRequest request);
        IDataResult<List<ListCarImageResponse>> GetAll();
        IDataResult<GetCarImageResponse> GetByImageId(int imageId);
    }
}
