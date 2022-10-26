using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class DrinkTypeRepository: IDrinkTypeRepository
    {
        public void AddDrinkType(DrinkType drinkType) => DrinkTypeDAO.Instance.AddDrinkType(drinkType);

        public void Delete(int drinkTypeId) => DrinkTypeDAO.Instance.Delete(drinkTypeId);

        public DrinkType GetDrinkType(int drinkTypeId)
        {
            return DrinkTypeDAO.Instance.GetDrinkType(drinkTypeId);
        }

        public DrinkType GetDrinkType(string drinkTypeName)
        {
            return DrinkTypeDAO.Instance.GetDrinkType(drinkTypeName);
        }

        public List<DrinkType> GetDrinkTypesList()
        {
            return DrinkTypeDAO.Instance.GetDrinkTypesList();
        }

        public int GetNextDrinkTypeId()
        {
            throw new NotImplementedException();
        }

        public void Update(DrinkType drinkType)
        {
            throw new NotImplementedException();
        }
    }
}
