using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class ShiftRepository : IShiftRepository
    {
        public void AddShift(Shift shift) => ShiftDAO.Instance.AddShift(shift);

        public void DeleteShift(int shiftId) => ShiftDAO.Instance.DeleteShift(shiftId);

        public Shift GetShift(int shiftId)
        {
            return ShiftDAO.Instance.GetShift(shiftId);
        }

        public Shift GetShift(string shiftName)
        {
            return ShiftDAO.Instance.GetShift(shiftName);
        }

        public List<Shift> GetShiftsList()
        {
            return ShiftDAO.Instance.GetShiftsList();
        }

        public void Update(Shift shift) => ShiftDAO.Instance.Update(shift);
    }
}
