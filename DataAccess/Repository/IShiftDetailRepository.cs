using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IShiftDetailRepository
    {
        public List<ShiftDetail> GetShiftDetailList();
        public ShiftDetail GetShiftDetail(int shiftDetailId);
        public void AddShiftDetail(ShiftDetail shiftDetail);
        public void Update(ShiftDetail shiftDetail);
        public void DeleteShiftDetail(int shiftDetailId);
        public List<ShiftDetail> FilterShiftDetailByShift(string shiftName);
        public List<ShiftDetail> FilterVoucherByUser(string userName);
    }
}
