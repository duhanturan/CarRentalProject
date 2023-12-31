﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<Car>> GetAllById(int id)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.Id == id), true, Messages.CarsListedById);
		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		IDataResult<List<Car>> ICarService.GetAll()
		{
			return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarsListed);
		}

		IDataResult<List<Car>> ICarService.GetAllByBrandId(int brandId)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),true,Messages.CarsListedByBrandId);
		}

		IDataResult<List<Car>> ICarService.GetAllByColorId(int colorId)
		{
			return new DataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == colorId), true,Messages.CarsListedByColorId);
		}

		IDataResult<List<CarDetailDto>> ICarService.GetCarDetails()
		{
			return new DataResult<List<CarDetailDto>> (_carDal.GetCarDetails(),true,Messages.CarDetailsListed);
		}
	}
}
