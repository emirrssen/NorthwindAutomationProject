using Business.Abstract;
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
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult AddOrder(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult DeleteOrder(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IResult UpdateOrder(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        public IDataResult<List<Order>> GetAllOrders()
        {
            var result = _orderDal.GetAll();
            return new SuccessDataResult<List<Order>>(result, Messages.OrdersListed);
        }

        public IDataResult<Order> GetOrderById(int orderId)
        {
            var result = _orderDal.Get(x => x.OrderId == orderId);
            return new SuccessDataResult<Order>(result, Messages.OrderListed);
        }
    }
}
