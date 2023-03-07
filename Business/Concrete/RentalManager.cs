using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Constants;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IMapper _mapper;
        RentalBusinessRules _rentalBusinessRules;

        public RentalManager(IRentalDal rentalDal, IMapper mapper, RentalBusinessRules rentalBusinessRules)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public IResult Add(CreateRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);
            _rentalBusinessRules.CheckIfRentalNotExist(rental);
            _rentalBusinessRules.CheckIfCarExist(rental.CarId);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.AddData);
        }

        public IResult Delete(DeleteRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteData);
        }

        public IDataResult<GetRentalResponse> GetById(int id)
        {
            Rental rental = _rentalDal.Get(r=>r.Id== id);
            var response = _mapper.Map<GetRentalResponse>(rental);
            return new SuccessDataResult<GetRentalResponse>(response,Messages.GetData);
        }

        public IDataResult<List<ListRentalResponse>> GetList()
        {
            List<Rental> rentals = _rentalDal.GetAll();
            List<ListRentalResponse> responses = _mapper.Map<List<ListRentalResponse>>(rentals);
            return new SuccessDataResult<List<ListRentalResponse>>(responses,Messages.ListData);
        }

        public IResult Update(UpdateRentalRequest request)
        {
            Rental rental = _mapper.Map<Rental>(request);
            _rentalBusinessRules.CheckIfRentalNotExist(rental);
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdateData);
        }
    }
}
