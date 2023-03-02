using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Colors;
using Business.Responses.Colors;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        IMapper _mapper;
        ColorBusinessRules _colorBusinessRules;

        public ColorManager(IColorDal colorDal, IMapper mapper, ColorBusinessRules colorBusinessRules)
        {
            _colorDal = colorDal;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
        }

        public IResult Add(CreateColorRequest request)
        {
            Color color = _mapper.Map<Color>(request);
            _colorBusinessRules.CheckIfColorExist(color);
            _colorDal.Add(color);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteColorRequest request)
        {
            Color color = _mapper.Map<Color>(request);
            _colorDal.Delete(color);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetColorResponse> GetById(int id)
        {
            Color color = _colorDal.Get(c=>c.Id == id);
            var response = _mapper.Map<GetColorResponse>(color);
            return new SuccessDataResult<GetColorResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListColorResponse>> GetList()
        {
            List<Color> colors = _colorDal.GetAll();
            List<ListColorResponse> responses = _mapper.Map<List<ListColorResponse>>(colors);
            return new SuccessDataResult<List<ListColorResponse>>(responses, Messages.ListData);
        }

        public IResult Update(UpdateColorRequest request)
        {
            Color color = _mapper.Map<Color>(request);
            _colorBusinessRules.CheckIfColorNotExist(color);
            _colorDal.Update(color);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
