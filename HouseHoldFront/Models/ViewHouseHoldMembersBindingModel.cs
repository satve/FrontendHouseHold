using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseHoldFront.Models
{
    public class ViewHouseHoldMembersBindingModel
    {
        [Required]
        public int HouseHoldId { get; set; }
    }
}