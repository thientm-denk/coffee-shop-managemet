using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public List<Order> GetOrdersList();
        public Order GetOrder(int orderId);
        public int GetNextOrderId();
        public void Add(Order order);
        public void Update(Order order);
        public void Delete(int order);
        public List<Order> FilterOrderByShiftDetail(int shiftDetailId);
    }
}
