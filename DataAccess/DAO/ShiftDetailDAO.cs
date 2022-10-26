using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ShiftDetailDAO
    {
        private static ShiftDetailDAO instance = null;
        private static object instanceLook = new object();

        public static ShiftDetailDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new ShiftDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<ShiftDetail> GetShiftDetailList()
        {
            List<ShiftDetail> shiftDetails = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                shiftDetails = context.ShiftDetails.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shiftDetails;
        }

        public ShiftDetail GetShiftDetail(int shiftDetailId)
        {
            ShiftDetail shiftDetail = null;

            try
            {
                var context = new CoffeeShopContext();
                shiftDetail = context.ShiftDetails.SingleOrDefault(v => v.ShiftDetailsId == shiftDetailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return shiftDetail;
        }

        public void AddShiftDetail(ShiftDetail shiftDetail)
        {
            try
            {
                if (GetShiftDetail(shiftDetail.ShiftDetailsId) == null)
                {
                    var context = new CoffeeShopContext();
                    context.ShiftDetails.Add(shiftDetail);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ShiftDetail shiftDetail)
        {
            if (shiftDetail == null)
            {
                throw new Exception("ShiftDetail is undefined!!");
            }
            try
            {
                ShiftDetail shD = GetShiftDetail(shiftDetail.ShiftDetailsId);
                if (shD != null)
                {
                    var context = new CoffeeShopContext();
                    context.ShiftDetails.Update(shD);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ShiftDetail does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteShiftDetail(int shiftDetailId)
        {
            try
            {
                ShiftDetail shiftDetail = GetShiftDetail(shiftDetailId);
                if (shiftDetail != null)
                {
                    var context = new CoffeeShopContext();
                    context.ShiftDetails.Remove(shiftDetail);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ShiftDetail does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ShiftDetail> FilterShiftDetailByShift(string shiftName)
        {
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                List<ShiftDetail> shiftDetails = context.ShiftDetails.Where(shD => shD.Shift.ShiftName.Equals(shiftName)).ToList();
                return shiftDetails;
            }
        }

        public List<ShiftDetail> FilterVoucherByUser(string userName)
        {
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                List<ShiftDetail> shiftDetails = context.ShiftDetails.Where(shD => shD.User.Name.Equals(userName)).ToList();
                return shiftDetails;
            }
        }
    }
}
