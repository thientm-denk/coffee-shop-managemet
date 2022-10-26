using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class ShiftDetailRepository : IShiftDetailRepository
    {
        public void AddShiftDetail(ShiftDetail shiftDetail) => ShiftDetailDAO.Instance.AddShiftDetail(shiftDetail); 

        public void DeleteShiftDetail(int shiftDetailId) => ShiftDetailDAO.Instance.DeleteShiftDetail(shiftDetailId);   
 
        public List<ShiftDetail> FilterShiftDetailByShift(string shiftName)
        {
            return ShiftDetailDAO.Instance.FilterShiftDetailByShift(shiftName);
        }

        public List<ShiftDetail> FilterVoucherByUser(string userName)
        {
            return ShiftDetailDAO.Instance.FilterVoucherByUser(userName);
        }

        public ShiftDetail GetShiftDetail(int shiftDetailId)
        {
            return ShiftDetailDAO.Instance.GetShiftDetail(shiftDetailId);
        }

        public List<ShiftDetail> GetShiftDetailList()
        {
            return ShiftDetailDAO.Instance.GetShiftDetailList();
        }

        public void Update(ShiftDetail shiftDetail) => ShiftDetailDAO.Instance.Update(shiftDetail);
    }
}
