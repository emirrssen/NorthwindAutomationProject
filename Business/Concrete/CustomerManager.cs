﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<List<Customer>> GetAllCustomers()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result, Messages.CustomersListed);
        }

        public IDataResult<Customer> GetCustomerById(string customerId)
        {
            var result = _customerDal.Get(x => x.CustomerId.Equals(customerId));
            return new SuccessDataResult<Customer>(result, Messages.CustomerListed);
        }
    }
}