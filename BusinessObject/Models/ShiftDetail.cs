using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class ShiftDetail
    {
        public ShiftDetail()
        {
            Orders = new HashSet<Order>();
        }

        public int ShiftDetailsId { get; set; }
        public int UserId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public long OpenWallet { get; set; }
        public long CloseWallet { get; set; }

        public virtual Shift Shift { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
