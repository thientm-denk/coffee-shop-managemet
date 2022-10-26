using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IVoucherRepository
    {
        public List<Voucher> GetVoucherList();
        public Voucher GetVoucher(int voucherId);
        public void AddVoucher(Voucher voucher);
        public void Update(Voucher voucher);
        public void DeleteVoucher(int voucherId);
        public List<Voucher> FilterVoucherByStatus(string status);
    }
}
