using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailsList();
        public OrderDetail GetOrderDetail(int orderDetailId);
        public void AddOrderDetail(OrderDetail orderDetail);
        public decimal GetOrderTotal(int orderId);
        public List<OrderDetail> GetOrderDetails(int orderId);
        public void DeleteOrderDetails(int orderId);
    }
}
