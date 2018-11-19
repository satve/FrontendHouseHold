using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseHoldFront.Models
{
    public class HouseHolds
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatorId { get; set; }
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<ApplicationUser> UsersInHouseHold { get; set; }
        
    }
}