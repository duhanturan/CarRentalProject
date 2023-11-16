using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
        public InMemoryCarDal()
        {
			_cars = new List<Car>
			{
				new Car {
				Id = 1,
				BrandId = 1,
				ColorId = 1,
				DailyPrice = 1000,
				Description = "Günlük Kiralık Araç",
				ModelYear = 2022,
				Name = "BMW"
				},
				new Car {
				Id = 2,
				BrandId = 2,
				ColorId = 1,
				DailyPrice = 1500,
				Description = "Günlük Kiralık Araç",
				ModelYear = 2023,
				Name = "Mercedes"
				},
				new Car {
				Id = 3,
				BrandId = 1,
				ColorId = 1,
				DailyPrice = 1000,
				Description = "Günlük Kiralık Araç",
				ModelYear = 2022,
				Name = "BMW"
				}
			};
        }
        public void Add(Car car)
		{
			_cars.Add(car);	
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
			_cars.Remove(carToDelete);	
        }

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAllByBrand(int brandId)
		{
			return _cars.Where(c=>c.BrandId == brandId).ToList();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c=>c.Id==car.Id);
			carToUpdate.Name=car.Name;
			carToUpdate.Description=car.Description;	
			carToUpdate.ModelYear=car.ModelYear;	
			carToUpdate.BrandId=car.BrandId;
		}
	}
}
