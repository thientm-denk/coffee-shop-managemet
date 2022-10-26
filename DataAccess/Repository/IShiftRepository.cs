using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IShiftRepository
    {
        public List<Shift> GetShiftsList();
        public Shift GetShift(int shiftId);
        public Shift GetShift(string shiftName);
        public void AddShift(Shift shift);
        public void Update(Shift shift);
        public void DeleteShift(int shiftId);
    }
}
