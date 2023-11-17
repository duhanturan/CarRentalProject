using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<List<Car>> GetAllById(int id);
		IDataResult<List<Car>> GetAllByBrandId(int brandId);
		IDataResult<List<Car>> GetAllByColorId(int colorId);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IResult Add(Car car);
		IResult Update(Car car);
		IResult Delete(Car car);

	}
}
