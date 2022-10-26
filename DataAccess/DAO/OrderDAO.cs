using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static object instanceLook = new object();

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetOrderList()
        {
            List<Order> orders = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                orders = context.Orders.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrder(int orderId)
        {
            Order order = null;

            try
            {
                var context = new CoffeeShopContext();
                order = context.Orders.SingleOrDefault(o => o.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return order;
        }

        public int GetNextOrderId()
        {
            int nextOrderId = -1;

            try
            {
                var context = new CoffeeShopContext();
                nextOrderId = context.Orders.Max(o => o.OrderId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nextOrderId;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception("Order is undefined!!");
            }
            try
            {
                if (GetOrder(order.OrderId) == null)
                {
                    var context = new CoffeeShopContext();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Order order)
        {
            if (order == null)
            {
                throw new Exception("Order is undefined!!");
            }
            try
            {
                Order o = GetOrder(order.OrderId);
                if (o != null)
                {
                    var context = new CoffeeShopContext();
                    context.Orders.Update(o);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int orderId)
        {
            try
            {
                Order order = GetOrder(orderId);
                if (orderId != null)
                {
                    var context = new CoffeeShopContext();
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Order does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Order> FilterOrderByShiftDetail(int shiftDetailId)
        {
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                List<Order> orders = context.Orders.Where(or => or.ShiftId==shiftDetailId).ToList();
                return orders;
            }
        }
    }
}
