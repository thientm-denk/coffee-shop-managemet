using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int VoucherId { get; set; }
        public int SaleRate { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
