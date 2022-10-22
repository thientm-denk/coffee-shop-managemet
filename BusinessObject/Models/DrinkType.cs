using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class DrinkType
    {
        public DrinkType()
        {
            Drinks = new HashSet<Drink>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Drink> Drinks { get; set; }
    }
}
