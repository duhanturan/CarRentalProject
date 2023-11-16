using Core.DataAccess.EntityrFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands
							 on c.BrandId equals b.BrandId
							 select new CarDetailDto
							 {
								 CarId = c.Id,
								 CarName = c.Name,
								 BrandName = b.BrandName
							 };
				return result.ToList();
			}
		}
	}
}
