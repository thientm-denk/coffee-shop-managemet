using BusinessObject.Models;

namespace DataAccess.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instance = null;
        private static object instanceLook = new object();

        public static DrinkDAO Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new DrinkDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Drink> GetDrinksList()
        {
            List<Drink> drinks = null;

            try
            {
                CoffeeShopContext context = new CoffeeShopContext();
                // Get From Database
                drinks = context.Drinks.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return drinks;
        }

        public Drink GetDrink(int drinkId)
        {
            Drink drink = null;

            try
            {
                var context = new CoffeeShopContext();
                drink = context.Drinks.SingleOrDefault(dr => dr.DrinkId == drinkId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return drink;
        }

        public Drink GetDrink(string drinkName)
        {
            Drink drink = null;

            try
            {
                var context = new CoffeeShopContext();
                drink = context.Drinks.SingleOrDefault(dr => dr.Name.Equals(drinkName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return drink;
        }

        public int GetNextDrinkId()
        {
            int nextDrinkId = -1;

            try
            {
                var context = new CoffeeShopContext();
                nextDrinkId = context.Drinks.Max(dr => dr.DrinkId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nextDrinkId;
        }

        public void AddDrink(Drink drink)
        {
            if (drink == null)
            {
                throw new Exception("Drink is undefined!!");
            }
            try
            {
                if (GetDrink(drink.DrinkId) == null && GetDrink(drink.Name) == null)
                {
                    var context = new CoffeeShopContext();
                    context.Drinks.Add(drink);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Drink drink)
        {
            if (drink == null)
            {
                throw new Exception("Drink is undefined!!");
            }
            try
            {
                Drink dr = GetDrink(drink.DrinkId);
                if (dr != null)
                {
                    var context = new CoffeeShopContext();
                    dr = drink;
                    context.Drinks.Update(dr);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int drinkId)
        {
            try
            {
                Drink drink = GetDrink(drinkId);
                if (drink != null)
                {
                    var context = new CoffeeShopContext();
                    context.Drinks.Remove(drink);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Drink does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Drink> SearchDrink(string name)
        {
            List<Drink> searchResult = new List<Drink>();

            List<Drink> drinks = null;

            try
            {
                CoffeeShopContext context = new CoffeeShopContext();
                drinks = context.Drinks.ToList();

                foreach(Drink drink in drinks)
                {
                    if (drink.Name.ToLower().Contains(name.ToLower()))
                    {
                        searchResult.Add(drink);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return searchResult;


        }

        public List<Drink> FilterDrinkByType(string name)
        {
            using (CoffeeShopContext context = new CoffeeShopContext())
            {
                DrinkType drType = context.DrinkTypes.Where(t => t.Name.Equals(name)).ToList()[0];
                return context.Drinks.Where(dr => dr.TypeId.Equals(drType.TypeId)).ToList();
                }                
        }
    }
}
