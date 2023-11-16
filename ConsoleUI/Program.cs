using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
	CarTest();
	//BrandTest();
		}

		private static void BrandTest()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());

			foreach (var brand in
				brandManager.GetAll())
			{
				Console.WriteLine(brand.BrandName);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			carManager.Add(new Car { BrandId = 1, ColorId = 1, Id = 1, Name = "BMW", ModelYear = 2022, DailyPrice = 2000 });
			carManager.Add(new Car { BrandId = 1, ColorId = 1, Id = 2, Name = "tyt", ModelYear = 2022, DailyPrice = 2000 });
			carManager.Delete(new Car { Id = 2 });
		}
	}
}

