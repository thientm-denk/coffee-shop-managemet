using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static object instanceLook = new object();

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<OrderDetail> GetOrderDetailsList()
        {
            List<OrderDetail> orderDetails = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                orderDetails = context.OrderDetails.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetail GetOrderDetail(int orderDetailId)
        {
            OrderDetail orderDetail = null;

            try
            {
                var context = new CoffeeShopContext();
                orderDetail = context.OrderDetails.SingleOrDefault(orD => orD.OrderDetailsId == orderDetailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return orderDetail;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                if (GetOrderDetail(orderDetail.OrderDetailsId) == null)
                {
                    var context = new CoffeeShopContext();
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public decimal GetOrderTotal(int orderId)
        {
            decimal orderTotal = 0;

            try
            {
                var context = new CoffeeShopContext();
                List<OrderDetail> orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                foreach (var orderDetail in orderDetails)
                {
                    if (orderDetail.VocherId != null)
                    {
                        orderTotal += orderDetail.Quantity * (100 - Convert.ToDecimal(orderDetail.Vocher.SaleRate));
                    }
                    else
                    {
                        orderTotal += orderDetail.Quantity;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Math.Round(orderTotal, 2);
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            List<OrderDetail> orderDetails = null;

            try
            {
                var context = new CoffeeShopContext();
                orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public void DeleteOrderDetails(int orderId)
        {
            try
            {
                var context = new CoffeeShopContext();
                List<OrderDetail> orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                foreach (var orderDetail in orderDetails)
                {
                    context.Remove(orderDetail);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
