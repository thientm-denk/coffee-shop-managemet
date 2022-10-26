using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IDrinkTypeRepository
    {
        public List<DrinkType> GetDrinkTypesList();
        public DrinkType GetDrinkType(int drinkTypeId);
        public DrinkType GetDrinkType(string drinkTypeName);
        public int GetNextDrinkTypeId();
        public void AddDrinkType(DrinkType drinkType);
        public void Update(DrinkType drinkType);
        public void Delete(int drinkTypeId);
    }
}
