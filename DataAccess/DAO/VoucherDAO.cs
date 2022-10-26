using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class VoucherDAO
    {
        private static VoucherDAO instance = null;
        private static object instanceLook = new object();

        public static VoucherDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new VoucherDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Voucher> GetVoucherList()
        {
            List<Voucher> vouchers = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                vouchers = context.Vouchers.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return vouchers;
        }

        public Voucher GetVoucher(int voucherId)
        {
            Voucher voucher = null;

            try
            {
                var context = new CoffeeShopContext();
                voucher = context.Vouchers.SingleOrDefault(v => v.VoucherId == voucherId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return voucher;
        }

        public void AddVoucher(Voucher voucher)
        {
            try
            {
                if (GetVoucher(voucher.VoucherId) == null)
                {
                    var context = new CoffeeShopContext();
                    context.Vouchers.Add(voucher);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Voucher voucher)
        {
            if (voucher == null)
            {
                throw new Exception("Voucher is undefined!!");
            }
            try
            {
                Voucher v = GetVoucher(voucher.VoucherId);
                if (v != null)
                {
                    var context = new CoffeeShopContext();
                    context.Vouchers.Update(v);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Voucher does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteVoucher(int voucherId)
        {
            try
            {
                Voucher voucher = GetVoucher(voucherId);
                if (voucher != null)
                {
                    var context = new CoffeeShopContext();
                    context.Vouchers.Remove(voucher);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Voucher does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Voucher> FilterVoucherByStatus(string status)
        {
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                List<Voucher> vouchers = context.Vouchers.Where(v => v.Status.Equals(status)).ToList();
                return vouchers;
            }
        }
    }
}
