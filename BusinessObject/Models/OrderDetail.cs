using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int DrinkId { get; set; }
        public int Quantity { get; set; }
        public int? VocherId { get; set; }

        public virtual Drink Drink { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual Voucher Vocher { get; set; }
    }
}
