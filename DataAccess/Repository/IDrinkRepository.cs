using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IDrinkRepository
    {
        public List<Drink> GetDrinksList();
        public int GetNextDrinkId();
        public void AddDrink(Drink drink);
        public void UpdateDrink(Drink drink);
        public void DeleteDrink(int drinkId);
        public Drink GetDrink(int drinkId);
        public Drink GetDrink(string name);
        public List<Drink> SearchDrink(string name);
        public List<Drink> FilterDrinkByType(string name);
    }
}
