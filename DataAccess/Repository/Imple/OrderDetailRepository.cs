using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail);

        public void DeleteOrderDetails(int orderId) => OrderDetailDAO.Instance.DeleteOrderDetails(orderId);

        public OrderDetail GetOrderDetail(int orderDetailId)
        {
            return OrderDetailDAO.Instance.GetOrderDetail(orderDetailId);   
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderDetails(orderId);
        }

        public List<OrderDetail> GetOrderDetailsList()
        {
            return OrderDetailDAO.Instance.GetOrderDetailsList();
        }

        public decimal GetOrderTotal(int orderId)
        {
            return OrderDetailDAO.Instance.GetOrderTotal(orderId);
        }

    }
}
