using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public User()
        {
            ShiftDetails = new HashSet<ShiftDetail>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<ShiftDetail> ShiftDetails { get; set; }
    }
}
