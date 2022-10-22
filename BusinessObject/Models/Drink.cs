using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Drink
    {
        public Drink()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int DrinkId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; } = null!;
        public long Price { get; set; }

        public virtual DrinkType Type { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
