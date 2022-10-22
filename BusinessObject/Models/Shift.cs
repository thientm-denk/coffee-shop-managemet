using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Shift
    {
        public Shift()
        {
            ShiftDetails = new HashSet<ShiftDetail>();
        }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; } = null!;

        public virtual ICollection<ShiftDetail> ShiftDetails { get; set; }
    }
}
