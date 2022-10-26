using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class DrinkRepository : IDrinkRepository
    {
        public void AddDrink(Drink drink) => DrinkDAO.Instance.AddDrink(drink);

        public void DeleteDrink(int drinkId) => DrinkDAO.Instance.Delete(drinkId);
        public Drink GetDrink(int drinkId)
        {
            return DrinkDAO.Instance.GetDrink(drinkId);
        }

        public Drink GetDrink(string name)
        {
            return DrinkDAO.Instance.GetDrink(name);
        }

        public List<Drink> GetDrinksList()
        {
            return DrinkDAO.Instance.GetDrinksList();
        }

        public int GetNextDrinkId()
        {
            return DrinkDAO.Instance.GetNextDrinkId();
        }

        public List<Drink> SearchDrink(string name)
        {
            return DrinkDAO.Instance.SearchDrink(name);
        }

        public void UpdateDrink(Drink drink) => DrinkDAO.Instance.Update(drink);

        public List<Drink> FilterDrinkByType(string name)
        {
            return DrinkDAO.Instance.FilterDrinkByType(name);
        }
    }
}
