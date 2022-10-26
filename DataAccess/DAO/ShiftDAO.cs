using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ShiftDAO
    {
        private static ShiftDAO instance = null;
        private static object instanceLook = new object();

        public static ShiftDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new ShiftDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Shift> GetShiftsList()
        {
            List<Shift> shifts = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                shifts = context.Shifts.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shifts;
        }

        public Shift GetShift(int shiftId)
        {
            Shift shift = null;

            try
            {
                var context = new CoffeeShopContext();
                shift = context.Shifts.SingleOrDefault(s => s.ShiftId == shiftId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return shift;
        }

        public Shift GetShift(string shiftName)
        {
            Shift shift = null;

            try
            {
                var context = new CoffeeShopContext();
                shift = context.Shifts.SingleOrDefault(s => s.ShiftName == shiftName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return shift;
        }

        public void AddShift(Shift shift)
        {
            try
            {
                if (GetShift(shift.ShiftId) == null && GetShift(shift.ShiftName)==null)
                {
                    var context = new CoffeeShopContext();
                    context.Shifts.Add(shift);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Shift shift)
        {
            if (shift == null)
            {
                throw new Exception("Shift is undefined!!");
            }
            try
            {
                Shift sh = GetShift(shift.ShiftId);
                if (sh != null)
                {
                    var context = new CoffeeShopContext();
                    context.Shifts.Update(sh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Shift does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteShift(int shiftId)
        {
            try
            {
                Shift shift = GetShift(shiftId);
                if (shift != null)
                {
                    var context = new CoffeeShopContext();
                    context.Shifts.Remove(shift);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Shift does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
