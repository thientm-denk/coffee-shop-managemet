using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class OrderRepository : IOrderRepository
    {
        public void Add(Order order) => OrderDAO.Instance.AddOrder(order);  

        public void Delete(int order) => OrderDAO.Instance.Delete(order);

        public Order GetOrder(int orderId)
        {
            return OrderDAO.Instance.GetOrder(orderId);
        }

        public int GetNextOrderId()
        {
            return OrderDAO.Instance.GetNextOrderId();
        }

        public List<Order> GetOrdersList()
        {
            return OrderDAO.Instance.GetOrderList();
        }

        public void Update(Order order) => OrderDAO.Instance.Update(order);

        public List<Order> FilterOrderByShiftDetail(int shiftDetailId)
        {
            return OrderDAO.Instance.FilterOrderByShiftDetail(shiftDetailId);
        }
    }
}
