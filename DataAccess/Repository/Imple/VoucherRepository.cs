using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Imple
{
    public class VoucherRepository : IVoucherRepository
    {
        public void AddVoucher(Voucher voucher) => VoucherDAO.Instance.AddVoucher(voucher);

        public void DeleteVoucher(int voucherId) => VoucherDAO.Instance.DeleteVoucher(voucherId);

        public List<Voucher> FilterVoucherByStatus(string status)
        {
            return VoucherDAO.Instance.FilterVoucherByStatus(status);
        }

        public Voucher GetVoucher(int voucherId)
        {
            return VoucherDAO.Instance.GetVoucher(voucherId);
        }

        public List<Voucher> GetVoucherList()
        {
            return VoucherDAO.Instance.GetVoucherList();
        }

        public void Update(Voucher voucher) => VoucherDAO.Instance.Update(voucher);
    }
}
