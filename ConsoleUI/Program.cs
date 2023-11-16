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
			BrandTest();
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

	
	}
}

