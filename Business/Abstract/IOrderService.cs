using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult AddOrder(Order order);
        IResult UpdateOrder(Order order);
        IResult DeleteOrder(Order order);
        IDataResult<Order> GetOrderById(int orderId);
        IDataResult<List<Order>> GetAllOrders();
    }
}
