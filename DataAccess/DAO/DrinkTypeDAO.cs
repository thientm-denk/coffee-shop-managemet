using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class DrinkTypeDAO
    {
        private static DrinkTypeDAO instance = null;
        private static object instanceLook = new object();

        public static DrinkTypeDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new DrinkTypeDAO();
                    }
                    return instance;
                }
            }
        }

        public List<DrinkType> GetDrinkTypesList()
        {
            List<DrinkType> drinkTypes = null;

            try
            {
                var context = new CoffeeShopContext();
                // Get From Database
                drinkTypes = context.DrinkTypes.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return drinkTypes;
        }

        public DrinkType GetDrinkType(int drinkTypeId)
        {
            DrinkType drinkType = null;

            try
            {
                var context = new CoffeeShopContext();
                drinkType = context.DrinkTypes.SingleOrDefault(drT => drT.TypeId == drinkTypeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return drinkType;
        }

        public DrinkType GetDrinkType(string drinkTypeName)
        {
            DrinkType drinkType = null;

            try
            {
                var context = new CoffeeShopContext();
                drinkType = context.DrinkTypes.SingleOrDefault(drT => drT.Name.Equals(drinkTypeName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return drinkType;
        }

        public int GetNextDrinkTypeId()
        {
            int nextDrinkTypeId = -1;

            try
            {
                var context = new CoffeeShopContext();
                nextDrinkTypeId = context.DrinkTypes.Max(dr => dr.TypeId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nextDrinkTypeId;
        }

        public void AddDrinkType(DrinkType drinkType)
        {
            if (drinkType == null)
            {
                throw new Exception("Drink Type is undefined!!");
            }
            try
            {
                if (GetDrinkType(drinkType.TypeId) == null && GetDrinkType(drinkType.Name) == null)
                {
                    var context = new CoffeeShopContext();
                    context.DrinkTypes.Add(drinkType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink Type is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(DrinkType drinkType)
        {
            if (drinkType == null)
            {
                throw new Exception("Drink Type is undefined!!");
            }
            try
            {
                DrinkType drt = GetDrinkType(drinkType.TypeId);
                if (drt != null)
                {
                    var context = new CoffeeShopContext();
                    context.DrinkTypes.Update(drt);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink Type does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int drinkTypeId)
        {
            try
            {
                DrinkType drinkType = GetDrinkType(drinkTypeId);
                if (drinkType != null)
                {
                    var context = new CoffeeShopContext();
                    context.DrinkTypes.Remove(drinkType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink Type does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
