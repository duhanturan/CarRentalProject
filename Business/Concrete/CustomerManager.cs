using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		CustomerManager _customerManager;

		public CustomerManager(CustomerManager customerManager)
		{
			_customerManager = customerManager;
		}

		public IResult Add(Customer customer)
		{
			_customerManager.Add(customer);
			return new SuccessResult(Messages.CustomerAdded);
		}

		public IResult Delete(Customer customer)
		{
			_customerManager.Delete(customer);
			return new SuccessResult(Messages.CustomerDeleted);
		}

		public IResult Update(Customer customer)
		{
			_customerManager.Update(customer);
			return new SuccessResult(Messages.CustomerUpdated);
		}
	}
}
